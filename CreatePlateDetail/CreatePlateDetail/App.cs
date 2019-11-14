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

namespace CreatePlateDetail
{
    class App : IExternalApplication
    {
        public Result OnStartup(UIControlledApplication a)
        {
            RevitAddIn revitAddIn = new RevitAddIn(
                a,
                "Detalhar\nchapas",
                "CreatePlateDetail.Command",
                "Detalhamento",
                "BFS Tools")
            {
                Img = Properties.Resources.icons8_pintura_met�lica_36,
                LImg = Properties.Resources.icons8_pintura_met�lica_36,
            };

            PushButtonData pushButtonData = new PushButtonData(revitAddIn.Name,
                revitAddIn.Name,
                Assembly.GetExecutingAssembly().Location,
                revitAddIn.ClassName)
            {
                ToolTip = "Cria um detalhe em planta e um em corte para cada tipo de chapa existente.",
                LongDescription = "A ferramenta busca pelas chapas met�licas, e de acordo com o tipo especificado" +
                "no par�metro Coment�rios cria os detalhes, um em planta, e um em corte.",
                Image = revitAddIn.GetImageSource(revitAddIn.Img),
                LargeImage = revitAddIn.GetImageSource(revitAddIn.LImg)
            };

            revitAddIn.AssertTabExistence();
            _ = revitAddIn.GetRibbonPanel().AddItem(pushButtonData) as PushButton;

            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication a)
        {
            return Result.Succeeded;
        }
    }
}
