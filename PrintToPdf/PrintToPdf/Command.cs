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

            // collecting view sheets
            List<Element> viewSheetsElements = new List<Element>(new FilteredElementCollector(doc)
                                                            .OfCategory(BuiltInCategory.OST_Sheets)
                                                            .ToElements());

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
            PrintViewSheets printViewSheets = new PrintViewSheets(doc, viewSheets);

            System.Windows.Forms.MessageBox.Show("Exportação finalizada.", "Resumo");

            return Result.Succeeded;
        }
    }
}
