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

namespace PrintToPdf
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(
          ExternalCommandData commandData,
          ref string message,
          ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;

            // cleaning element selection set
            Selection sel = uidoc.Selection;
            List<ElementId> emptyElementSet = new List<ElementId>() { };
            sel.SetElementIds(emptyElementSet);

            // collecting view sheets
            List<Element> viewSheetsElements = new List<Element>(new FilteredElementCollector(doc)
                                                            .OfCategory(BuiltInCategory.OST_Sheets)
                                                            .ToElements());

            viewSheetsElements.OrderBy(viewSheetElement => (viewSheetElement as ViewSheet).SheetNumber);

            // opening a select from list form
            SelectFromList selectFromList = new SelectFromList(viewSheetsElements);
            selectFromList.ShowDialog();

            // if cancelled
            if (selectFromList.DialogResult == System.Windows.Forms.DialogResult.Cancel)
            {
                return Result.Cancelled;
            }

            // getting the sheet views selected
            List<ViewSheet> viewSheets = selectFromList.GetChoosedElements()
                .Cast<ViewSheet>().ToList();

            // print view sheets
            try
            {
                PrintViewSheets printViewSheets = new PrintViewSheets(doc, viewSheets);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Erro");
            }

            System.Windows.Forms.MessageBox.Show("Exportação finalizada.", "Exportar PDF");
            return Result.Succeeded;
        }
    }
}
