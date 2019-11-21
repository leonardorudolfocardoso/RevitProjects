#region Namespaces
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using View = Autodesk.Revit.DB.View;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
#endregion

namespace FreezeDrawing
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        String _setupName = "BFS";
        String _dwgName = "temp";
        
        private String Directory { get; set; }

        public Result Execute(
          ExternalCommandData commandData,
          ref string message,
          ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Autodesk.Revit.ApplicationServices.Application app = uiapp.Application;
            Document doc = uidoc.Document;

            // Working with directory
            List<String> splittedDirectory = doc.PathName.Split('\\').ToList();
            this.Directory = String.Join("\\", splittedDirectory
                                              .GetRange(0, splittedDirectory.Count - 1)
                                              .ToArray());

            // Creating main form
            MainForm mainForm = new MainForm(doc);
            DialogResult dialogResult = mainForm.ShowDialog();

            if (dialogResult == DialogResult.Cancel)
            {
                return Result.Cancelled;
            }

            // Opening a transaction
            Transaction tx = new Transaction(doc, "Congelar desenho");
            tx.Start();

            foreach (View view in mainForm.SelectedViews)
            {
                View viewCopy = doc.GetElement(view.Duplicate(ViewDuplicateOption.Duplicate)) as View;
                FreezeDrawing(doc, viewCopy);
                doc.Delete(viewCopy.Id);
            }

            tx.Commit();

            return Result.Succeeded;
        }

        private ViewSheet CreateViewSheetToExport(Document doc)
        {
            // Gets a TitleBlock to create tempViewSheet
            ElementId titleBlockId = new List<ElementId>(new FilteredElementCollector(doc)
                                                            .OfCategory(BuiltInCategory.OST_TitleBlocks)
                                                            .ToElementIds())[0];



            // Creates tempViewSheet to export to DWG
            ViewSheet tempViewSheet = ViewSheet.Create(doc, titleBlockId);

            // Collects TitleBlock in tempViewSheet to delete it
            titleBlockId = new List<ElementId>(new FilteredElementCollector(doc)
                                                  .OfCategory(BuiltInCategory.OST_TitleBlocks)
                                                  .OwnedByView(tempViewSheet.Id)
                                                  .ToElementIds())[0];
            doc.Delete(titleBlockId);

            return tempViewSheet;
        }

        private DWGExportOptions GetDWGExportOptions(Document doc)
        {
            // Gets the predefined setup names
            List<string> setupNames = BaseExportOptions.GetPredefinedSetupNames(doc).ToList();

            if (!(from name in setupNames select name.ToLower()).Contains(_setupName.ToLower()))
            {
                System.Windows.Forms.MessageBox.Show(String.Format("Não há configuração de exportação." +
                    "Crie uma configuração com nome {0}, que será utilizada para exportar.", _setupName));
                return null;
            }
            DWGExportOptions dWGExportOptions = DWGExportOptions.GetPredefinedOptions(doc, _setupName);

            return dWGExportOptions;
        }

        private void FreezeDrawing(Document doc, View view)
        {
            //try
            //{
            // Create the ViewSheetToExport
            ViewSheet tempViewSheet = CreateViewSheetToExport(doc);
            doc.Regenerate();

            // Create the viewport with the view on tempViewSheet
            _ = Viewport.Create(doc, tempViewSheet.Id, view.Id, new XYZ());
            doc.Regenerate();

            // Get dwg export options
            DWGExportOptions dWGExportOptions = GetDWGExportOptions(doc);

            // Create a list, because the method export needs it
            List<ElementId> viewSheets = new List<ElementId> { tempViewSheet.Id };

            // Export
            doc.Export(this.Directory, this._dwgName, viewSheets, dWGExportOptions);

            // Creating view
            ViewFamilyType viewFamilyType = (from element in (new List<Element>
                                                            (new FilteredElementCollector(doc)
                                                                    .OfClass(typeof(ViewFamilyType))
                                                                    .ToElements()).ToList())
                                                where (element as ViewFamilyType).ViewFamily.Equals(ViewFamily.Drafting)
                                                select (element as ViewFamilyType))
                                            .First();
            View draftingView = ViewDrafting.Create(doc, viewFamilyType.Id);

            // Import
            ElementId elementId;
            doc.Import(this.Directory + "\\" + this._dwgName + ".dwg", new DWGImportOptions(), draftingView, out elementId);

            // Deleting aux ViewSheet and DWG
            doc.Delete(tempViewSheet.Id);
            File.Delete(this.Directory + "\\" + this._dwgName + ".dwg");
            //}
            //catch
            //{
            //    MessageBox.Show(String.Format("Houve um erro ao congelar a vista {0}. " +
            //        "Verifique se ela possui algum elemento visual.", view.Name),
            //        "Congelar vistas");
            //}
        }
    }
}
