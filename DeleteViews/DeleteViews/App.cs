#region Namespaces
using System;
using System.Collections.Generic;
using System.Reflection;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using RevitAddInTools;
#endregion

namespace DeleteViews
{
    class App : IExternalApplication
    {
        public Result OnStartup(UIControlledApplication a)
        {
            RevitAddIn revitAddIn = new RevitAddIn(
                a,
                "Deletar\nvistas",
                "DeleteViews.Command",
                "Limpeza",
                "BFS Tools")
            {
                Img = Properties.Resources.icon,
                LImg = Properties.Resources.icon,
            };
            revitAddIn.AssertTabExistence();

            // creating push button data
            PushButtonData pushButtonData = new PushButtonData(revitAddIn.Name,
                revitAddIn.Name,
                Assembly.GetExecutingAssembly().Location,
                revitAddIn.ClassName)
            {
                ToolTip = "Deleta as vistas selecionadas.",
                LongDescription = "",
                Image = revitAddIn.GetImageSource(revitAddIn.Img),
                LargeImage = revitAddIn.GetImageSource(revitAddIn.LImg)
            };

            // adding button to panel
            _ = revitAddIn.GetRibbonPanel().AddItem(pushButtonData) as PushButton;

            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication a)
        {
            return Result.Succeeded;
        }
    }
}
