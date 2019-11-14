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

namespace DeleteViews
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

            List<ViewType> viewTypes = new List<ViewType>();
            List<View> views = new List<View>();

            List<ViewType> allowedViewTypes = new List<ViewType>()
            {
                ViewType.FloorPlan,
                ViewType.CeilingPlan,
                ViewType.Elevation,
                ViewType.ThreeD,
                ViewType.Legend,
                ViewType.Schedule,
                ViewType.DrawingSheet,
                ViewType.Walkthrough,
                ViewType.Section,
                ViewType.Undefined,
                ViewType.AreaPlan,
                ViewType.EngineeringPlan,
                ViewType.Rendering,
                ViewType.PanelSchedule,
                ViewType.Internal,
                ViewType.DraftingView
            };

            FilteredElementCollector viewCollector = new FilteredElementCollector(doc);            
            viewCollector.OfClass(typeof(View));

            foreach(Element viewElement in viewCollector)
            {
                View view = viewElement as View;
                if (allowedViewTypes.Contains(view.ViewType))
                {
                    if (!viewTypes.Contains(view.ViewType))
                    {
                        viewTypes.Add(view.ViewType);
                        
                    }
                    views.Add(view);
                }
            }

            AppForm appForm = new AppForm(viewTypes, views);
            
            var result = appForm.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                List<string> deletedViews = new List<string>();
                List<string> notDeletedViews = new List<string>();
                // Modify document within a transaction
                using (Transaction tx = new Transaction(doc))
                {
                    tx.Start("Deletar vistas");

                    // Deleting each view choosed
                    foreach (Element view in appForm.GetCheckedViews())
                    {
                        try
                        {
                            deletedViews.Add((view as View).ViewType + "-" + (view as View).Title);
                            doc.Delete(view.Id);
                        }
                        catch 
                        {
                            notDeletedViews.Add((view as View).ViewType + "-" + (view as View).Title);
                        }
                    }

                    tx.Commit();
                }
                if(deletedViews.Any() || notDeletedViews.Any())
                {
                    string text = "";
                    if (deletedViews.Any())
                    {
                        text += "Foram exluídas as vistas:\n";
                        foreach (string view in deletedViews)
                        {
                            text += "   " + view + "\n";
                        }
                    }
                    if (notDeletedViews.Any())
                    {
                        text += "Não puderam ser excluídas as vistas:\n";
                        foreach (string view in notDeletedViews)
                        {
                            text += "   " + view + "\n";
                        }
                    }
                    ResumeDialog resumeDialog = new ResumeDialog(text);
                    resumeDialog.ShowDialog();
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Nenhuma vista foi selecionada.", "Resumo de vistas excluídas");
                }

                return Result.Succeeded;
            }
            return Result.Cancelled;
        }
    }
}
