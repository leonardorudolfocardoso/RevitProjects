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

namespace FreezeDrawing
{
    class App : IExternalApplication
    {
        public Result OnStartup(UIControlledApplication a)
        {
            RevitAddIn revitAddIn = new RevitAddIn(
                a,
                "Congelar\nvistas",
                "FreezeDrawing.Command",
                "Ferramentas",
                "BFS Tools")
            {
                Img = Properties.Resources.icons8_floco_de_neve_32,
                LImg = Properties.Resources.icons8_floco_de_neve_32
            };
            PushButtonData pushButtonData = new PushButtonData(revitAddIn.Name,
                revitAddIn.Name,
                Assembly.GetExecutingAssembly().Location,
                revitAddIn.ClassName)
            {
                ToolTip = "Congela a vista atual em uma vista de desenho.",
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
