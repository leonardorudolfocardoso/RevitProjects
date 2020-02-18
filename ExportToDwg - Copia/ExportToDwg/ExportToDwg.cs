using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ExportToDwg
{
    class ExportToDwg
    {
        #region Fields
        char[] _Separators = { '[', ',', '\\', '-', '!', '?', ':', '.', ']', '+' };
        #endregion
        #region Properties
        public Document Doc { get; set; }
        public Transaction Transaction { get; set; }
        public string SetupName { get; set; }
        public List<ViewSheet> ViewSheets { get; set; }
        public List<string> SheetSizes { get; set; }
        public string FolderPath { get; set; }
        public List<string> FileNames { get; set; }
        public DWGExportOptions DWGExportOptions { get; set; }
        #endregion

        public ExportToDwg(Document doc, List<ViewSheet> viewSheets)
        {
            this.Doc = doc;
            this.SetupName = "BFS";
            this.DWGExportOptions = this.GetDwgOptions();
            this.ViewSheets = viewSheets;
            this.SheetSizes = this.GetSheetSizes();
            this.FileNames = this.GetFileNames();
            this.FolderPath = this.GetFolderPath();
        }

        private string GetFolderPath()
        {
            System.Windows.Forms.FolderBrowserDialog folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            folderBrowserDialog.SelectedPath = this.Doc.PathName;
            folderBrowserDialog.ShowDialog();
            return folderBrowserDialog.SelectedPath;
        }

        private List<string> GetFileNames()
        {
            // grabs the document directory
            string directory = this.Doc.PathName;

            // splitted directory
            List<string> splittedDirectory = directory.Split('\\').ToList();

            // works with file paths
            string file_path_prefixtemp = String.Join("\\", splittedDirectory.GetRange(0, splittedDirectory.Count - 2).ToArray());
            string file_path_midtemp = this.Doc.Title;
            string file_path_prefix = String.Format("{0}\\{1}", file_path_prefixtemp, file_path_midtemp);

            // creates the list to store the file paths
            string filePath;
            List<string> filePaths = new List<string>();

            // iterates through the sheetViews and sheetSize
            var zip = this.ViewSheets.Zip(this.SheetSizes, (vs, ss) => new { ViewSheet = vs, SheetSize = ss });
            string rev;
            string viewSheetsCount = this.Doc.ProjectInformation.LookupParameter("Total de folhas").AsString();

            foreach (var vs in zip)
            {
                var currentRevision = vs.ViewSheet.GetCurrentRevision();
                var sequenceNumber = (this.Doc.GetElement(currentRevision) as Revision).SequenceNumber;
                rev = String.Format("Rev.{0}", sequenceNumber-1);
                
                filePath = String.Format("{0}-{1}_{2}.{3}-{4}.dwg", file_path_prefix,
                    rev, vs.ViewSheet.SheetNumber, viewSheetsCount, vs.SheetSize);

                filePaths.Add(filePath);
            }
            List<string> fileNames = new List<string>();
            foreach (string fp in filePaths)
            {
                List<string> fp_splitted = fp.Split('\\').ToList();
                string fileName = fp_splitted[fp_splitted.Count - 1];
                fileNames.Add(fileName);
            }
            return fileNames;
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
                        if (a == b && !c.Contains("selo"))
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
                if (ftitleBlock.LookupParameter("Tamanho padrão").AsInteger() == 1)
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

        private DWGExportOptions GetDwgOptions()
        {
            List<string> setupNames = BaseExportOptions.GetPredefinedSetupNames(this.Doc).ToList();

            string prompt = "";

            prompt += "setupNames: \n";
            foreach (string setupName in setupNames)
            {
                prompt += "  " + setupName + "\n";
            }

            prompt += "this.SetupName: \n";
            prompt += this.SetupName;


            if (!(from name in setupNames select name.ToLower()).Contains(this.SetupName.ToLower()))
            {
                System.Windows.Forms.MessageBox.Show(String.Format("Não há configuração de exportação." +
                    "Crie uma configuração com nome {0}, que será utilizada para exportar.", this.SetupName));
                return null;
            }
            DWGExportOptions dwgExportOptions = DWGExportOptions.GetPredefinedOptions(this.Doc, this.SetupName);
            return dwgExportOptions;
        }

        public void Export()
        {
            var zip = this.FileNames.Zip(this.ViewSheets, (fn, vs) => new { fn, vs, });
            foreach(var item in zip)
            {
                List<ElementId> viewSheet = new List<ElementId>() { item.vs.Id };
                this.Doc.Export(this.FolderPath, item.fn, viewSheet, this.DWGExportOptions); 
            }
        }
    }
}
