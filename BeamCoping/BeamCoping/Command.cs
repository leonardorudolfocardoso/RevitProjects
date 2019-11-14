#region Namespaces
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Diagnostics;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Structure;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
#endregion

namespace BeamCoping
{

    public class SelectionFilter : ISelectionFilter
    {
        ElementId AllowedCategoryId { get; set; }
        public SelectionFilter(ElementId allowedCategoryId)
        {
            AllowedCategoryId = allowedCategoryId;
        }
        public bool AllowElement(Element element)
        {
            Category elementCategory = element.Category;
            if (elementCategory.Id.IntegerValue.Equals(AllowedCategoryId.IntegerValue))
            {
                return true;
            }
            return false;
        }
        public bool AllowReference(Reference reference, XYZ position)
        {
            return true;
        }
    }

    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        const double _COPE_DISTANCE = 0.02;

        public Result Execute(
          ExternalCommandData commandData,
          ref string message,
          ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Autodesk.Revit.ApplicationServices.Application app = uiapp.Application;
            Document doc = uidoc.Document;

            // Access current selection

            Selection sel = uidoc.Selection;

            // Retrieve elements from database

            FilteredElementCollector col
              = new FilteredElementCollector(doc)
                .WhereElementIsNotElementType()
                .OfCategory(BuiltInCategory.OST_StructuralFraming)
                .OfClass(typeof(FamilyInstance));
            IList<Element> beams = col.ToElements();

            ElementId beamCategoryId = beams[0].Category.Id;
            SelectionFilter selFilter = new SelectionFilter(beamCategoryId);

            // counters
            int count_ok = 0;

            using (Transaction tx = new Transaction(doc))
            {
                while (true) {
                    tx.Start("Corte de viga");
                    try
                    {
                        // getting elements and family instances
                        Element beam0 = doc.GetElement(sel.PickObject(ObjectType.Element,
                                                                      selFilter,
                                                                      "Selecione a viga primária")
                                                       .ElementId);
                        Element beam1 = doc.GetElement(sel.PickObject(ObjectType.Element,
                                                                      selFilter,
                                                                      "Selecione a viga secundária"));
                        FamilyInstance beam0FamInst = beam0 as FamilyInstance;
                        FamilyInstance beam1FamInst = beam1 as FamilyInstance;

                        // assert selected beams are not the same
                        if (beam0.Id.IntegerValue == beam1.Id.IntegerValue)
                        {
                            _ = System.Windows.Forms.MessageBox.Show("Cortar vigas",
                                                                     "Selecione duas vigas diferentes");
                            _ = System.Windows.Forms.MessageBox.Show("Cortar vigas - Cortes finalizados", 
                                count_ok + " cortes finalizados com sucesso.");
                            break;
                        }

                        Reference reference;

                        reference = beam0FamInst.GetReferenceByName("Centro (Frente/Trás)");
                        if (reference == null)
                        {
                            reference = beam0FamInst.GetReferenceByName("Center (Frente/Trás)");
                        }
                        if (reference == null)
                        {
                            _ = System.Windows.Forms.MessageBox.Show("Não foi encontrada referência central da viga", 
                                                                     "Cortar vigas");
                            _ = System.Windows.Forms.MessageBox.Show(count_ok + " cortes finalizados com sucesso.",
                                             "Cortar vigas - Cortes finalizados");
                        }

                        (beam1 as FamilyInstance).AddCoping(beam0 as FamilyInstance);

                        if (StructuralFramingUtils.IsEndReferenceValid(beam1FamInst, 0, reference))
                        {
                            StructuralFramingUtils.SetEndReference(beam1FamInst, 0, reference);
                        }
                        else if (StructuralFramingUtils.IsEndReferenceValid(beam1FamInst, 1, reference))
                        {
                            StructuralFramingUtils.SetEndReference(beam1FamInst, 1, reference);
                        }
                        else
                        {
                            _ = System.Windows.Forms.MessageBox.Show(
                            "Não há conexão entre as vigas, ou a ordem da conexão não está conforme selecionado.",
                            "Cortar vigas");
                            _ = System.Windows.Forms.MessageBox.Show(count_ok + " cortes finalizados com sucesso.",
                                             "Cortar vigas - Cortes finalizados");
                            break;
                        }

                        beam1.get_Parameter(BuiltInParameter.STRUCTURAL_COPING_DISTANCE).Set(_COPE_DISTANCE);

                        Parameter start_join_cutback = beam1.get_Parameter(BuiltInParameter.START_JOIN_CUTBACK);
                        if (start_join_cutback != null)
                        {
                            start_join_cutback.Set(0);
                        }
                        Parameter end_join_cutback = beam1.get_Parameter(BuiltInParameter.END_JOIN_CUTBACK);
                        if (end_join_cutback != null)
                        {
                            end_join_cutback.Set(0);
                        }
                        tx.Commit();
                        count_ok++;
                    }
                    catch (Exception)
                    {
                        tx.RollBack();
                        _ = System.Windows.Forms.MessageBox.Show(count_ok + " cortes finalizados com sucesso.",
                                                                 "Cortar vigas - Cortes finalizados");
                        break;
                    }
                }
            }
            return Result.Succeeded;
        }
    }
}
