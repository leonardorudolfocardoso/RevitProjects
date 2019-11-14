#region Namespaces
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
#endregion

namespace UpdateRevisions
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

            var revisionIds = new List<ElementId>(new FilteredElementCollector(doc)
                                                     .OfClass(typeof(Revision))
                                                     .ToElementIds());

            var viewSheets = new List<Element> (new FilteredElementCollector(doc)
                                                     .OfClass(typeof(ViewSheet))
                                                     .ToElements());

            if (revisionIds.Count == 0)
            {
                System.Windows.Forms.MessageBox.Show("Não foram encontradas revisões.", "Erro");
                return Result.Failed;
            }

            if (viewSheets.Count == 0)
            {
                System.Windows.Forms.MessageBox.Show("Não foram encontradas folhas.", "Erro");
                return Result.Failed;
            }

            Transaction tx = new Transaction(doc);
            tx.SetName("Atualizar revisões");

            tx.Start();
            foreach (Element viewSheet in viewSheets)
            {
                (viewSheet as ViewSheet).SetAdditionalRevisionIds(revisionIds);
            }
            tx.Commit();

            return Result.Succeeded;
        }
    }
}
