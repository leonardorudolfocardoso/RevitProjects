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

namespace ExportToDwg
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
            List<ViewSheet> viewSheets = new FilteredElementCollector(doc)
                                            .OfCategory(BuiltInCategory.OST_Sheets)
                                            .ToElements()
                                            .Cast<ViewSheet>()
                                            .ToList();
            List<string> viewSheetsNames = (from viewSheet in viewSheets select viewSheet.Title).ToList();

            Dictionary<string, ViewSheet> viewSheetsDic = viewSheetsNames
                                                         .Zip(viewSheets, (vsn, vs) => new { vsn, vs })
                                                         .ToDictionary(item => item.vsn, item => item.vs);

            // opening a select from list form
            SelectFromList selectFromList = new SelectFromList(viewSheets.Cast<Element>().ToList());
            selectFromList.ShowDialog();

            // if cancelled
            if (selectFromList.DialogResult == System.Windows.Forms.DialogResult.Cancel)
            {
                return Result.Cancelled;
            }

            // getting the sheet views selected
            List<ViewSheet> selectedViewSheets = new List<ViewSheet>();
            ExportToDwg exportToDwg = new ExportToDwg(doc, selectFromList.GetChoosedElements()
                                                           .Cast<ViewSheet>()
                                                           .ToList());
            exportToDwg.Export();

            return Result.Succeeded;
        }
    }
}
