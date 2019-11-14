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

namespace PurgeUnused
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;

            TaskDialog taskDialog = new TaskDialog("Limpar inutilizados");
            taskDialog.MainInstruction = "Você realmente deseja limpar os inutilizados?";
            taskDialog.CommonButtons = TaskDialogCommonButtons.Yes | TaskDialogCommonButtons.No;
            TaskDialogResult result = taskDialog.Show();
            if (result != TaskDialogResult.Yes)
            {
                return Result.Cancelled;
            }

            List<ElementId> purgeableElementIds = new List<ElementId>();
            while (true)
            {
                if (PurgeTool.GetPurgeableElements(doc, purgeableElementIds))
                {
                    if (purgeableElementIds.Count > 0)
                    {
                        using (Transaction tx = new Transaction(doc))
                        {
                            tx.Start("Purge Unused");
                            doc.Delete(purgeableElementIds);
                            purgeableElementIds.Clear();
                            tx.Commit();
                        }
                    } else
                    {
                        return Result.Succeeded;
                    }
                } 
                else
                {
                    return Result.Failed;
                }
            }
        }
    }
    public class PurgeTool
    {
        const string PURGE_GUID = "e8c63650-70b7-435a-9010-ec97660c1bda";
        public static bool GetPurgeableElements(Document doc, List<ElementId> purgeableElementIds)
        {
            var ruleIds = new List<PerformanceAdviserRuleId>();
            var ruleId = new List<PerformanceAdviserRuleId>();

            if (GetPerformanceAdvisorRuleId(PURGE_GUID, ruleId))
            {
                ruleIds.Add(ruleId[0]);
            } else
            {
                return false; // can't find rule
            }
            // execute our chosen rule
            var failureMessages = new List<FailureMessage>(PerformanceAdviser
                                                           .GetPerformanceAdviser()
                                                           .ExecuteRules(doc, ruleIds));
            try { 
                if (failureMessages.Count > 0) {
                    // if there are many purgeable elements, we should have a failure message
                    // the failure message should have a collection of failing elements - set to our byref collection
                    purgeableElementIds.AddRange(failureMessages[0].GetFailingElements());
                // no errors - return true
                }
                return true;
            }
            catch { }
            return false;
        }
        public static bool GetPerformanceAdvisorRuleId(string guidStr, List<PerformanceAdviserRuleId> ruleId)
        {
            foreach (PerformanceAdviserRuleId rule in PerformanceAdviser
                                                      .GetPerformanceAdviser()
                                                      .GetAllRuleIds())
            {
                // check if the rule Id matches our rule guid
                if (rule.Guid.ToString().Equals(guidStr)){
                    ruleId.Add(rule); // if it does, assign it
                    return true;
                }
            }
            return false;
        }
    }
}
