#region Namespaces
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
#endregion

namespace CreatePlateDetail
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        char[] _Separators = { '[', ',', '\\', '-', '!', '?', ':', '.', ']', '+', ';' };
        public Result Execute(
          ExternalCommandData commandData,
          ref string message,
          ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;

            // get view types
            FilteredElementCollector viewCol
                = new FilteredElementCollector(doc)
                  .WhereElementIsElementType()
                  .OfClass(typeof(ViewFamilyType));

            ViewFamilyType viewFamilyTypeFP = null;
            ViewFamilyType viewFamilyTypeS = null;
            ViewFamilyType viewFamilyTypeD = null;

            foreach (ViewFamilyType view in viewCol)
            {
                if (view.ViewFamily == ViewFamily.FloorPlan)
                {
                    viewFamilyTypeFP = view;
                }
                if (view.ViewFamily == ViewFamily.Section)
                {
                    viewFamilyTypeS = view;
                }
                if (view.ViewFamily == ViewFamily.Detail)
                {
                    viewFamilyTypeD = view;
                }
            }

            // collecting categories which must be visible (structural stiffener, structural column and text note
            List<ElementId> categoriesToShow = new List<ElementId>();
            categoriesToShow.Add(new FilteredElementCollector(doc)
                                    .OfCategory(BuiltInCategory.OST_StructuralStiffener)
                                    .ToElements()
                                    .First().Category.Id);
            categoriesToShow.Add(new FilteredElementCollector(doc)
                                    .OfCategory(BuiltInCategory.OST_StructuralColumns)
                                    .ToElements()
                                    .First().Category.Id);
            categoriesToShow.Add(new FilteredElementCollector(doc)
                                    .OfCategory(BuiltInCategory.OST_TextNotes)
                                    .ToElements()
                                    .First().Category.Id);
            categoriesToShow.Add(new FilteredElementCollector(doc)
                                    .OfCategory(BuiltInCategory.OST_Dimensions)
                                    .ToElements()
                                    .First().Category.Id);

            // declaring elementsCol and elementsToHide variables
            Categories categories = doc.Settings.Categories;
            TextNote textNote;
            Leader leader;
            ElementId defaultTextNoteTypeId = doc.GetDefaultElementTypeId(ElementTypeGroup.TextNoteType);


            // retrieve elements from database
            FilteredElementCollector col
              = new FilteredElementCollector(doc)
                .WhereElementIsNotElementType()
                .OfCategory(BuiltInCategory.OST_StructuralStiffener);

            // create a list to save the types already handled
            List<string> typesHandled = new List<string>();

            // modify document within a transaction
            using (Transaction tx = new Transaction(doc))
            {
                bool warningKey = true;
                tx.Start("Criar detalhe das chapas");
                // get first element for tests
                foreach (Element e in col)
                {

                    // handling plate type with comment
                    Parameter commentParam = e.get_Parameter(BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS);

                    // checking comment param
                    if (commentParam.AsString() == null)
                    {
                        if (warningKey)
                        {
                            System.Windows.Forms.MessageBox.Show("Foi encontrada uma chapa sem indicação de tipo, " +
                                "ela será ignorada pelo add-in.", "Aviso");
                            warningKey = false;
                        }
                        continue;
                    }

                    string[] splittedParam = (from str in commentParam.AsString().Split(_Separators)
                                              select str.ToLower())
                                              .ToArray();

                    int plateType = 0;
                    try
                    {
                        plateType = int.Parse(splittedParam.Last().Split(' ').Last());
                    }
                    catch (Exception)
                    {
                        System.Windows.Forms.MessageBox.Show("Problemas ao identificar o tipo da chapa. " +
                            splittedParam.Last(), "Erro");
                        tx.RollBack();
                        return Result.Failed;
                    }

                    if (typesHandled.ToArray().Intersect(splittedParam).Any())
                    {
                        continue;
                    }

                    List<View> existingViews = new List<View>();
                    if (!CheckNameAvailability(doc, plateType, ref existingViews))
                    {
                        switch (AskOverwriteDetailView(plateType))
                        {
                            case System.Windows.Forms.DialogResult.Yes:
                                doc.Delete((from view in existingViews select view.Id).ToList());
                                break;
                            case System.Windows.Forms.DialogResult.No:
                                tx.RollBack();
                                return Result.Cancelled;
                            case System.Windows.Forms.DialogResult.Cancel:
                                tx.RollBack();
                                return Result.Cancelled;
                        }
                    }

                    // get boundingbox of element
                    BoundingBoxXYZ ebbox = e.get_BoundingBox(null);
                    double w = ebbox.Max.X - ebbox.Min.X;
                    double d = ebbox.Max.Y - ebbox.Min.Y;
                    double h = ebbox.Max.Z - ebbox.Min.Z;

                    // creating boundingbox for vertical view section
                    BoundingBoxXYZ vBbox = new BoundingBoxXYZ();
                    vBbox.Enabled = true;
                    vBbox.Max = new XYZ(w + 0.2, h + 2, d + 0.2);
                    vBbox.Min = new XYZ(-w - 0.2, -h - 0.2, -d - 0.2);

                    // creating boundingbox for horizontal view section
                    BoundingBoxXYZ hBbox = new BoundingBoxXYZ();
                    hBbox.Enabled = true;
                    hBbox.Max = new XYZ(w + 0.2, d + 0.2, h + 0.2); 
                    hBbox.Min = new XYZ(-w - 0.2, -d - 0.2, -h - 0.2);

                    // set the transform
                    Transform vTrans = Transform.Identity;
                    Transform hTrans = Transform.Identity;

                    // find the element mid point
                    XYZ midPt = 0.5 * (ebbox.Max + ebbox.Min);

                    // set it as origin
                    vTrans.Origin = midPt;
                    hTrans.Origin = midPt;

                    // determine view direction for vView
                    vTrans.BasisX = XYZ.BasisX;
                    vTrans.BasisY = XYZ.BasisZ;
                    vTrans.BasisZ = -XYZ.BasisY;

                    // determine view direction for hView
                    hTrans.BasisX = -XYZ.BasisX;
                    hTrans.BasisY =  XYZ.BasisY;
                    hTrans.BasisZ = -XYZ.BasisZ;

                    // transforming
                    vBbox.Transform = vTrans;
                    hBbox.Transform = hTrans;

                    // creating vertical view section
                    ViewSection vView = ViewSection.CreateDetail(doc, viewFamilyTypeD.Id, vBbox);

                    // hidding categories in vertical view section
                    foreach (Category category in categories)
                    {
                        if (!categoriesToShow.Contains(category.Id)
                            && vView.CanCategoryBeHidden(category.Id))
                        {
                            vView.SetCategoryHidden(category.Id, true);
                        }
                    }

                    // scale
                    int scaleValue = 20;

                    // configuring vertical view properties
                    vView.Name = MakeViewNames(plateType)[0];
                    vView.DetailLevel = ViewDetailLevel.Fine;
                    vView.DisplayStyle = DisplayStyle.FlatColors;
                    vView.CropBoxVisible = false;
                    vView.Scale = scaleValue;

                    // creating textNotes
                    String text0 = "LIGAÇÃO COLUNA X CHAPA \nFEITA ATRAVÉS DE SOLDA";
                    textNote = TextNote.Create(doc, vView.Id, vBbox.Transform.Origin + new XYZ(0, 12, 3), text0, defaultTextNoteTypeId);
                    //leader = textNote.AddLeader(TextNoteLeaderTypes.TNLT_STRAIGHT_R);
                    //leader.End = vBbox.Transform.Origin + new XYZ(0, -5, 0);
                    
                    String text1 = "CHUMBAR CHAPA COM ADESIVO \nEPOXI SIKADUR 32 OU SIMILAR" +
                                   "\nVERIFICAR MODO DE UTILIZAÇÃO \nJUNTO AO FORNECEDOR";
                    textNote = TextNote.Create(doc, vView.Id, vBbox.Transform.Origin + new XYZ(0, 12, 3), text1, defaultTextNoteTypeId);
                    //leader = textNote.AddLeader(TextNoteLeaderTypes.TNLT_STRAIGHT_L);
                    //leader.End = vBbox.Transform.Origin + new XYZ(0, -50, 0);

                    String text2 = "PREENCHER COM EPS";
                    textNote = TextNote.Create(doc, vView.Id, vBbox.Transform.Origin + new XYZ(0, 12, 3), text2, defaultTextNoteTypeId);

                    String text3 = "CHUMBAR CHAPA \nCOM ADESIVO EPOXI";
                    textNote = TextNote.Create(doc, vView.Id, vBbox.Transform.Origin + new XYZ(0, 12, 3), text3, defaultTextNoteTypeId);

                    // creating horizontal view section
                    ViewSection hView = ViewSection.CreateDetail(doc, viewFamilyTypeD.Id, hBbox);

                    // hidding categories in horizontal view section
                    foreach (Category category in categories)
                    {
                        if (!categoriesToShow.Contains(category.Id)
                            && hView.CanCategoryBeHidden(category.Id))
                        {
                            hView.SetCategoryHidden(category.Id, true);
                        }
                    }

                    // configuring hView properties
                    hView.Name = MakeViewNames(plateType)[1];
                    hView.DetailLevel = ViewDetailLevel.Fine;
                    hView.DisplayStyle = DisplayStyle.HLR;
                    hView.CropBoxVisible = false;
                    hView.Scale = scaleValue;

                    // adding type handled to list
                    typesHandled.Add(String.Format("tipo {0}", (plateType).ToString()));
                }
                tx.Commit();
            }

            return Result.Succeeded;
        }

        private System.Windows.Forms.DialogResult AskOverwriteDetailView(int i)
        {
            // asking via default messagebox
            System.Windows.Forms.DialogResult dialogResult = System.Windows.Forms.MessageBox.Show(
                "Foi encontrado vistas com os nomes: " + 
                MakeViewNames(i)[0] + ", "
                + MakeViewNames(i)[1] + ". "
                + "Deseja substituir?", "Vistas existentes", 
                System.Windows.Forms.MessageBoxButtons.YesNoCancel);

            // returning its result
            return dialogResult;
        }

        private bool CheckNameAvailability(Document doc, int plateType, ref List<View> existingViews)
        {
            // collects all the views in doc
            FilteredElementCollector viewCol = new FilteredElementCollector(doc)
                                                  .OfCategory(BuiltInCategory.OST_Views);

            // select the ones which are of detail type
            List<View> detailViews = (from view in viewCol
                                      where (view as View).ViewType.Equals(ViewType.Detail)
                                      select (view as View)).ToList();

            List<string> viewNamesToWrite = MakeViewNames(plateType);

            // checking name vailability
            foreach (View view in detailViews)
            {
                if (viewNamesToWrite.Contains(view.Name))
                {
                    existingViews.Add(view);
                }
            }
            return !existingViews.Any();
        }

        private List<string> MakeViewNames(int plateType)
        {
            List<string> names = new List<string>();
            names.Add("PE-DET - Chapa Tipo " + (plateType).ToString() + " - Detalhe corte");
            names.Add("PE-DET - Chapa Tipo " + (plateType).ToString() + " - Detalhe planta");
            return names;
        }
    }
}
