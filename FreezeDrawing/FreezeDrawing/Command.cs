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

            try
            {
                foreach (View view in mainForm.SelectedViews)
                {
                    View viewCopy = doc.GetElement(view.Duplicate(ViewDuplicateOption.Duplicate)) as View;
                    FreezeDrawing(doc, viewCopy, mainForm.OptionsForm, view.Name);
                    doc.Delete(viewCopy.Id);

                    // delete view if in options form
                    if (mainForm.OptionsForm.DeleteView)
                    {
                        try
                        {
                            doc.Delete(view.Id);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Aviso");
                        }
                    }
                }

                tx.Commit();
            }
            catch (Exception ex)
            {
                tx.RollBack();
                MessageBox.Show(ex.Message, "Erro");
                return Result.Failed;
            }

            if (mainForm.OptionsForm.CopyDWGToFolder)
            {
                ProcessStartInfo processStartInfo = new ProcessStartInfo()
                {
                    Arguments = mainForm.OptionsForm.FolderToSave,
                    FileName = "explorer.exe",
                };
                Process.Start(processStartInfo);
            }

            return Result.Succeeded;
        }

        private ViewSheet CreateViewSheetToExport(Document doc)
        {
            // Gets a TitleBlock to create tempViewSheet
            Element titleBlock = new List<Element>(new FilteredElementCollector(doc)
                                                            .OfCategory(BuiltInCategory.OST_TitleBlocks)
                                                            .WhereElementIsElementType()
                                                            .ToElements())[0];



            // Creates tempViewSheet to export to DWG
            ViewSheet tempViewSheet = ViewSheet.Create(doc, titleBlock.Id);

            // Collects TitleBlock in tempViewSheet to delete it
            ElementId titleBlockId = new List<ElementId>(new FilteredElementCollector(doc)
                                                  .OfCategory(BuiltInCategory.OST_TitleBlocks)
                                                  .OwnedByView(tempViewSheet.Id)
                                                  .ToElementIds())[0];
            doc.Delete(titleBlockId);

            return tempViewSheet;
        }


        private void FreezeDrawing(Document doc, View view, OptionsForm optionsForm, String viewName)
        {
            // Create the ViewSheetToExport
            ViewSheet tempViewSheet = CreateViewSheetToExport(doc);

            // Create the viewport with the view on tempViewSheet
            _ = Viewport.Create(doc, tempViewSheet.Id, view.Id, new XYZ());


            // Create a list, because the method export needs it
            List<ElementId> viewSheets = new List<ElementId> { tempViewSheet.Id };

            // Export
            doc.Export(this.Directory, this._dwgName, viewSheets, 
                DWGExportOptions.GetPredefinedOptions(doc, optionsForm.DWGExportOptionsName));

            // Copying file according to optionsForm
            if (optionsForm.CopyDWGToFolder)
            {
                // try to copy
                try
                {
                    File.Copy(this.Directory + "\\" + this._dwgName + ".dwg",
                        String.Join("\\", optionsForm.FolderToSave, viewName + ".dwg"));
                }
                
                catch (IOException ex)
                {
                    if (MessageBox.Show(ex.Message + " Deseja substituir arquivo?", 
                        "Substituir arquivo", 
                        MessageBoxButtons.YesNo) 
                        == DialogResult.Yes)
                    {
                        File.Copy(this.Directory + "\\" + this._dwgName + ".dwg",
                            String.Join("\\", optionsForm.FolderToSave, viewName + ".dwg"), true);
                    }
                }
            }


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
            doc.Import(this.Directory + "\\" + this._dwgName + ".dwg", 
                optionsForm.DWGImportOptions, draftingView, out elementId);

            // Deleting aux ViewSheet (according to optionsForm and DWG
            doc.Delete(tempViewSheet.Id);
            File.Delete(this.Directory + "\\" + this._dwgName + ".dwg");
        }
    }
}
