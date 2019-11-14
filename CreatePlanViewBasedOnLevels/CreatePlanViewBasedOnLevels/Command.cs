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

namespace CreatePlanViewBasedOnLevels
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


            List<Element> levels = new List<Element>(new FilteredElementCollector(doc)
                                                        .OfClass(typeof(Level))
                                                        .ToElements());
            List<Element> viewFamilyTypes = new List<Element>(new FilteredElementCollector(doc)
                                                        .OfClass(typeof(ViewFamilyType))
                                                        .ToElements());

            // Get Floor Plan Family Type element

            ViewFamilyType viewFamilyFloorPlanType = null;

            foreach (ViewFamilyType viewFamilyType in viewFamilyTypes)
            {
                if (viewFamilyType.ViewFamily.Equals(ViewFamily.FloorPlan))
                {
                    viewFamilyFloorPlanType = viewFamilyType;
                    break;
                }
            }

            // Asserting viewFamilyFloorPlanType got the familyType
            if(viewFamilyFloorPlanType == null)
            {
                _ = System.Windows.Forms.MessageBox.Show("Não foi encontrado o tipo de planta de piso.",
                                                         "Criar plantas");
                return Result.Failed;
            }

            // Select levels with SelectFromList form
            SelectFromList selectFromList = new SelectFromList(levels);
            selectFromList.ShowDialog();

            if(selectFromList.DialogResult == System.Windows.Forms.DialogResult.Cancel)
            {
                return Result.Cancelled;
            }
            levels = selectFromList.GetChoosedElements();

            // Filtered element collector is iterable
            using (Transaction tx = new Transaction(doc))
            {
                foreach (Element level in levels)
                {
                    tx.Start("Planta " + level.Name);
                    _ = ViewPlan.Create(doc, viewFamilyFloorPlanType.Id, level.Id);
                    tx.Commit();
                }
            }

            return Result.Succeeded;
        }
    }
}
