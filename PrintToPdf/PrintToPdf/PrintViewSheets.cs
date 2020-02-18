using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;

namespace PrintToPdf
{
    class PrintViewSheets
    {
        String _PrinterName = "Adobe PDF";
        char[] _Separators = { '[', ',', '\\', '-', '!', '?', ':', '.', ']', '+' };
        #region Properties
        public Document Doc { get; set; }
        public List<ViewSheet> ViewSheets { get; set; }
        public int ViewSheetQuantity { get; set; }
        public List<string> SheetSizes { get; set; }
        public List<PrintSetting> PrintSettings { get; set; }
        public List<string> FilePaths { get; set; }
        public Transaction Transaction { get; set; }
        #endregion 
        public PrintViewSheets(Document doc, List<ViewSheet> viewSheets)
        {
            this.Doc = doc;
            this.Transaction = new Transaction(this.Doc, "Função de Exportar PDF");

            this.ViewSheets = viewSheets;
            this.ViewSheetQuantity = this.GetViewSheetQuantity();
            this.SheetSizes = this.GetSheetSizes();
            this.PrintSettings = this.GetPrintSettings();
            this.FilePaths = this.GetFilePaths();



            var zip = this.ViewSheets.Zip(this.SheetSizes, (vs, ss) => new { vs, ss })
                                     .Zip(this.PrintSettings, (t, ps) => new { t.vs, t.ss, ps })
                                     .Zip(this.FilePaths, (t, fp) => new
                                     {
                                         ViewSheet = t.vs,
                                         SheetSize = t.ss,
                                         PrintSetting = t.ps,
                                         FilePath = fp
                                     });

            foreach (var vs in zip)
            {
                this.PrintViewSheet(vs.ViewSheet, vs.SheetSize, vs.PrintSetting, vs.FilePath);
            }
        }

        private int GetViewSheetQuantity()
        {
            int viewSheetQuantity = new FilteredElementCollector(this.Doc)
                .OfCategory(BuiltInCategory.OST_Sheets).ToElements().Count;
            return viewSheetQuantity;
        }
        
        private List<string> GetFilePaths()
        {
            // creates BfsDocument object
            BfsDocument bfsDocument = new BfsDocument(this.Doc);

            // grabs the document directory
            string directory = this.Doc.PathName;

            // splitted directory
            List<string> splittedDirectory = directory.Split('\\').ToList();

            // works with file paths
            string file_path_prefix = String.Join("\\", splittedDirectory.GetRange(0, splittedDirectory.Count - 2).ToArray());

            // creates the list to store the file paths
            string filePath;
            List<string> filePaths = new List<string>();

            // iterates through the sheetViews and sheetSize
            var zip = this.ViewSheets.Zip(this.SheetSizes, (vs, ss) => new { ViewSheet = vs, SheetSize = ss });
            string rev;
            string viewSheetsCount = this.Doc.ProjectInformation.LookupParameter("Total de folhas").AsString();

            foreach(var vs in zip)
            {
                var currentRevision = vs.ViewSheet.GetCurrentRevision();
                var sequenceNumber = (this.Doc.GetElement(currentRevision) as Revision).SequenceNumber;
                rev = String.Format("Rev.{0}", sequenceNumber - 1);

                filePath = String.Format("{0}\\{1}-{2}_{3}.{4}-{5}.pdf", file_path_prefix, bfsDocument.Codigo,
                    bfsDocument.Revisao, vs.ViewSheet.SheetNumber, bfsDocument.TotalDeFolhas, vs.SheetSize); 
                filePaths.Add(filePath);
            }
            return filePaths;
        }

        private List<string> GetSheetSizes()
        {
            // creates a list to store all the view sheet sizes
            List<string> viewSheetSizes = new List<string>();
            // iterates through the sheets
            foreach (ViewSheet viewSheet in this.ViewSheets)
            {
                // creates a list and sotres all the viewSheet's elements
                List<Element> elements = new List<Element>(
                                             new FilteredElementCollector(this.Doc)
                                                 .OwnedByView(viewSheet.Id)
                                                 .ToElements());
                // creates a list and stores all the document's title blocks
                List<Element> titleBlocks = new List<Element>(
                                                new FilteredElementCollector(this.Doc)
                                                    .OfCategory(BuiltInCategory.OST_TitleBlocks)
                                                    .WhereElementIsNotElementType()
                                                    .ToElements());
                // creates a list to store the title blocks found in the sheet
                List<Element> titleBlocksFound = new List<Element>();
                // iterates through elements
                foreach (Element element in elements)
                {
                    // iterates over title blocks
                    foreach (Element titleBlock in titleBlocks)
                    {
                        // values for conditions
                        int a = element.Id.IntegerValue;
                        int b = titleBlock.Id.IntegerValue;
                        Char[] separators = { '[', ',', ' ', '\\', '-', '!', '?', ':', ']', '+' };
                        var c = from s in (titleBlock as FamilyInstance)
                                          .Symbol.Family.Name
                                          .Split(separators, separators.Length)
                                select s.ToLower();

                        // grabs the title block if it is a valid one
                        if (a==b && !c.Contains("selo"))
                        {
                            titleBlocksFound.Add(titleBlock);
                        }
                    }
                }

                if (titleBlocksFound.Count == 0)
                {
                    Console.WriteLine(String
                        .Format("Não foi encontrada title block na vista {0}", viewSheet.Name));
                }
                if (titleBlocksFound.Count > 1)
                {
                    Console.WriteLine(String
                        .Format("Foi encontrado mais de uma title block na vista {0}", viewSheet.Name));
                }

                // gets the first (and unique) title block
                Element ftitleBlock = titleBlocksFound.First();

                // saves the viewSheet's size information
                string viewSheetSize;
                if (ftitleBlock.LookupParameter("Tamanho padrão").AsInteger()==1)
                {
                    viewSheetSize = ftitleBlock.Name;
                }
                else
                {
                    viewSheetSize = ftitleBlock.Name +
                        "-" + (int)(1000 * ftitleBlock.LookupParameter("Largura da folha").AsDouble() * 1 / 3.28083989501);
                }
                viewSheetSizes.Add(viewSheetSize);
            }
            return viewSheetSizes;
        }

        private void PrintViewSheet(ViewSheet viewSheet, string sheetSize, PrintSetting printSetting, string filePath)
        {
            // creates view set
            ViewSet viewSet = new ViewSet();
            viewSet.Insert(viewSheet);
            PrintManager printManager = this.Doc.PrintManager;
            printManager.PrintRange = PrintRange.Select;
            printManager.Apply();

            // make new view set current
            ViewSheetSetting viewSheetSetting = printManager.ViewSheetSetting;
            viewSheetSetting.CurrentViewSheetSet.Views = viewSet;

            // set printer
            printManager.SelectNewPrintDriver(this._PrinterName);
            printManager.Apply();

            // set file path
            printManager.CombinedFile = true;
            printManager.PrintToFileName = filePath;
            printManager.Apply();

            // set print setting
            this.Transaction.Start();
            PrintSetup printSetup = printManager.PrintSetup;
            printSetup.CurrentPrintSetting = printSetting;
            printManager.Apply();
            this.Transaction.Commit();

            List<Element> viewSets = new List<Element>(new FilteredElementCollector(this.Doc)
                                                       .OfClass(typeof(ViewSheetSet))
                                                       .ToElements());
            foreach (Element element in viewSets)
            {
                if (element.Name == "tempSetName")
                {
                    this.Transaction.Start();
                    this.Doc.Delete(element.Id);
                    this.Transaction.Commit();
                }
            }

            // save settings and submit print
            this.Transaction.Start();
            viewSheetSetting.SaveAs("tempSetName");
            printManager.Apply();
            printManager.SubmitPrint();
            viewSheetSetting.Delete();
            this.Transaction.Commit();
        }

        private List<PrintSetting> GetPrintSettings()
        {
            List<PrintSetting> printSettings = new List<PrintSetting>();
            List<PrintSetting> allPrintSettings = new List<PrintSetting>
                                               (new FilteredElementCollector(this.Doc)
                                                .OfClass(typeof(PrintSetting))
                                                .ToElements().Cast<PrintSetting>().ToList());

            foreach (String sheetSize in this.SheetSizes)
            {
                foreach (PrintSetting printSetting in allPrintSettings)
                {
                    if (printSetting.Name == sheetSize)
                    {
                        printSettings.Add(printSetting);
                        break;
                    }
                    else if (printSetting == allPrintSettings.Last())
                    {
                        throw new Exception(String.Format(
                            "Tamanho de folha {0} não configurada." +
                            "Vá em 'Imprimir->Configurar...' e crie uma configuração de impressão com" +
                            "nome e tamanho '{1}'.",
                            sheetSize, sheetSize));
                    }
                }
            }

            return printSettings;
        }

    }
}
