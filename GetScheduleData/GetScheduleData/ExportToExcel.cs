using Microsoft.Office.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace GetScheduleData
{
    class ExportToExcel
    {
        #region Properties
        string _fileName;
        string _sheetName;
        List<List<List<string>>> _schedulesData;
        List<List<List<string>>> _revisionData;
        Excel._Application _application;
        Excel._Workbook _workbook;
        String WARNING_TEXT = "Obs.: os valores apresentados neste documento são extraídos da " +
                              "construção virtual modelada. Deve-se levar em consideração uma " +
                              "verba para materiais gerais e serviços não apresentados nas pla" +
                              "nilhas que fazem parte da execução (escavação, solda, seladores," +
                              " suportes, pregos, parafusos, etc.).";
        Dictionary<string, string> SUBJECT_DIC = new Dictionary<string, string>()
        {
            { "HID", "Projeto Hidrossanitário" },
            { "ELE", "Projeto Elétrico" },
            { "EXA", "Projeto de Exaustão" },
            { "ARC", "Projeto de Ar-condicionado e Climatização" },
            { "COM", "Projeto de Comunicação" },
            { "SPDA", "Projeto de Prevenção de Descargas Atmosféricas" },
            { "GAS", "Projeto de Instalações de Gás" },
            { "PCI", "Projeto de Prevenção e Combate a Incêndios" }
        };

        public string filePath { get => _fileName; set => _fileName = value; }
        public string sheetName { get => _sheetName; set => _sheetName = value; }
        public List<List<List<string>>> SchedulesData { get => _schedulesData; set => _schedulesData = value; }
        public List<List<List<string>>> RevisionData { get => _revisionData; set => _revisionData = value; }
        public Excel._Application Application { get => _application; set => _application = value; }
        public Excel._Workbook Workbook { get => _workbook; set => _workbook = value; }
        #endregion

        public enum TemplateType { QUANTITATIVO };

        public ExportToExcel(string file_name,
            string sheet_name,
            List<List<List<string>>> schedules_data,
            List<List<List<string>>> revisionData)
        {
            this.filePath = file_name;
            this.sheetName = sheet_name;
            this.SchedulesData = schedules_data;
            this.RevisionData = revisionData;
        }

        public void Export(TemplateType templateType, BfsDocument bfsDocument)
        {
            // start Excel and get Application object
            Excel._Application oXL = new Excel.Application();

            // get a new workbook
            Excel._Workbook oWB = oXL.Workbooks.Add(Type.Missing);

            Excel._Worksheet oSheet = oWB.ActiveSheet;
            oSheet.Name = this.sheetName;

            // adjusting template page setup
            oSheet.Rows.WrapText = true;
            oSheet.PageSetup.LeftMargin = 40;
            oSheet.PageSetup.RightMargin = 28;
            oSheet.PageSetup.TopMargin = 100;
            oSheet.PageSetup.BottomMargin = 80;
            oSheet.PageSetup.PaperSize = Excel.XlPaperSize.xlPaperA4;
            oSheet.PageSetup.Orientation = Excel.XlPageOrientation.xlPortrait;

            // adjusting template header
            oSheet.PageSetup.LeftHeaderPicture.Filename = "Z:\\BFS Revit Extensions\\logo.png";
            oSheet.PageSetup.LeftHeader = "&G";
            oSheet.PageSetup.CenterHeader = String.Format("&\"Arial Black\"&14PLANILHA\nDE\n{0}", templateType.ToString());
            string rightHeaderText = String.Format("DOC.: {0}\nDATA:{1}\nREVISÃO:{2}\nETAPA: N/A",
                                                   bfsDocument.Codigo,
                                                   System.DateTime.Now.Date.ToShortDateString(),
                                                   bfsDocument.Revisao);
            oSheet.PageSetup.RightHeader = String.Format("&R&11&\"Calibri, Bold\"{0}", rightHeaderText);
            oSheet.PageSetup.AlignMarginsHeaderFooter = true;
            oSheet.PageSetup.ScaleWithDocHeaderFooter = true;

            // adjusting template footer
            string footer_text1 = "RUA DONA FRANCISCA, 8300, PERINI BUSINESS PARK, ÁGORA HUB, SALA 318, CEP: 89219-600 BAIRRO DISTRITO INDUSTRIAL-JOINVILLE/SC-BRASIL\n";
            string footer_text2 = "BFS ENGENHARIA LTDA ME";
            oSheet.PageSetup.CenterFooter = String.Format("&\"Arial\"&10{0}&\"Arial Black\"&12{1}",
                                                          footer_text1, footer_text2);
            oSheet.PageSetup.RightFooter = "Pág.&P/&N";

            // formatting
            this.Format(oSheet, templateType);

            // row count
            int rowCount=0, rowAddition;

            // populating the project information
            oSheet.Range[oSheet.Cells[0+1, 0+1], oSheet.Cells[0+1, 1+1]].Merge(Missing.Value);
            oSheet.Range[oSheet.Cells[0 + 1, 0 + 1], oSheet.Cells[0 + 1, 1 + 1]].Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            oSheet.Range[oSheet.Cells[0 + 1, 0 + 1], oSheet.Cells[0 + 1, 1 + 1]].Borders.Color = System.Drawing.Color.Orange;
            oSheet.Cells[0+1, 0+1] = "1. DADOS DO PROJETO";
            oSheet.Cells[1+1, 0+1] = "PROPRIETÁRIO";
            oSheet.Cells[2+1, 0+1] = "ENDEREÇO";
            oSheet.Cells[3+1, 0+1] = "DISCIPLINA";
            oSheet.Cells[1+1, 1+1] = bfsDocument.Proprietario + "\n" + bfsDocument.Cnpj;
            oSheet.Cells[2+1, 1+1] = bfsDocument.Obra;
            oSheet.Cells[3+1, 1+1] = this.SUBJECT_DIC[bfsDocument.Disciplina];
            oSheet.Range[oSheet.Cells[0 + 1, 0 + 1], oSheet.Cells[3 + 1, 1 + 1]].Font.Name = "Arial";

            // styling the project information
            rowAddition = rowCount;
            for (int i=0; i<4; i++)
            {
                for(int j=0; j<2; j++)
                {
                    // styling
                    oSheet.Cells[i + 1 + rowAddition, j + 1].Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    oSheet.Cells[i + 1 + rowAddition, j + 1].Borders.Color = System.Drawing.Color.Orange;
                    oSheet.Cells[i + 1 + rowAddition, j + 1].VerticalAlignment = Excel.Constants.xlCenter;
                    oSheet.Cells[i + 1 + rowAddition, j + 1].Font.Name = "Arial";
                    oSheet.Cells[i + 1 + rowAddition, j + 1].Font.Size = 12;
                    if (j == 0)
                    {
                        oSheet.Cells[i + 1 + rowAddition, j + 1].Font.Bold = true;
                    }
                }
                rowCount++;
            }
            rowCount++;


            // iterating and populating the worksheet with data
            for (int n = 0; n < this.SchedulesData.Count; n++)
            {
                List<List<string>> scheduleData = this.SchedulesData[n];
                rowAddition = rowCount;
                for (int i = 0; i < scheduleData.Count; i++)
                {
                    List<string> rowData = scheduleData[i];
                    for (int j = 0; j < scheduleData[i].Count; j++)
                    {
                        //if (oSheet.Cells[i + 1 + rowAddition, j + 1] != null)
                        {
                            // styling
                            oSheet.Cells[i + 1 + rowAddition, j + 1]
                                  .Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                            oSheet.Cells[i + 1 + rowAddition, j + 1]
                                  .Borders.Color = System.Drawing.Color.Orange;
                            oSheet.Cells[i + 1 + rowAddition, j + 1]
                                  .VerticalAlignment = Excel.Constants.xlCenter;
                            oSheet.Cells[i + 1 + rowAddition, j + 1].Font.Name = "Arial";
                            oSheet.Cells[i + 1 + rowAddition, j + 1].Font.Size = 12;
                            if (rowAddition == rowCount)
                            {
                                // first row of schedule must have index and be bold text
                                oSheet.Range[oSheet.Cells[i + 1 + rowAddition, j + 1],
                                             oSheet.Cells[i + 1 + rowAddition, j + 1 + 1]].Merge(Missing.Value);
                                oSheet.Range[oSheet.Cells[i + 1 + rowAddition, j + 1],
                                             oSheet.Cells[i + 1 + rowAddition, j + 1 + 1]].Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                                oSheet.Range[oSheet.Cells[i + 1 + rowAddition, j + 1],
                                             oSheet.Cells[i + 1 + rowAddition, j + 1 + 1]].Borders.Color = System.Drawing.Color.Orange;
                                oSheet.Cells[i + 1 + rowAddition, j + 1] = string.Format("{0}. {1}", n + 2, rowData[j]);
                                oSheet.Cells[i + 1 + rowAddition, j + 1].Font.Bold = true;
                            }
                            else
                            {
                                // quant. data must be centralized
                                if (j == 0) oSheet.Cells[i + 1 + rowAddition, j + 1]
                                                  .HorizontalAlignment = Excel.Constants.xlCenter;

                                // normal data being written
                                oSheet.Cells[i + 1 + rowAddition, j + 1] = rowData[j];

                                // second row of schedule must be bold text
                                if (rowAddition + 1 == rowCount)
                                {
                                    oSheet.Cells[i + 1 + rowAddition, j + 1].Font.Bold = true;
                                }
                            }
                        }
                    }
                    rowCount++;
                }
                oSheet.Range[oSheet.Cells[rowCount + 1, 1], oSheet.Cells[rowCount + 1, 2]]
                      .Merge(Missing.Value);
                oSheet.Range[oSheet.Cells[rowCount + 1, 1], oSheet.Cells[rowCount + 1, 2]] = this.WARNING_TEXT;
                oSheet.Range[oSheet.Cells[rowCount + 1, 1], oSheet.Cells[rowCount + 1, 2]].RowHeight = 50;
                rowCount += 2;
            }

            // iterating and populating revision schedule
            for (int n = 0; n < this.RevisionData.Count; n++)
            {
                List<List<string>> revisionData = this.RevisionData[n];
                rowAddition = rowCount;
                for (int i = 0; i < revisionData.Count; i++)
                {
                    List<string> rowData = revisionData[i];
                    for (int j = 0; j < revisionData[i].Count; j++)
                    {
                        if (oSheet.Cells[i + 1, j + 1 + 2] != null)
                        {
                            // styling
                            oSheet.Cells[i + 1, j + 1 + 2].Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                            oSheet.Cells[i + 1, j + 1 + 2].Borders.Color = System.Drawing.Color.Orange;
                            oSheet.Cells[i + 1, j + 1 + 2].VerticalAlignment = Excel.Constants.xlCenter;
                            oSheet.Cells[i + 1, j + 1 + 2].Font.Name = "Arial";
                            oSheet.Cells[i + 1, j + 1 + 2].Font.Size = 12;
                            if (i == 0)
                            {
                                // first row of schedule must have index and be bold text
                                oSheet.Range[oSheet.Cells[i + 1, j + 1 + 2],
                                             oSheet.Cells[i + 1, j + 1 + 2 + 3]].Merge(Missing.Value);
                                oSheet.Range[oSheet.Cells[i + 1, j + 1 + 2],
                                             oSheet.Cells[i + 1, j + 1 + 2 + 3]].Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                                oSheet.Range[oSheet.Cells[i + 1, j + 1 + 2],
                                             oSheet.Cells[i + 1, j + 1 + 2 + 3]].Borders.Color = System.Drawing.Color.Orange;
                                oSheet.Cells[i + 1, j + 1 + 2] = string.Format("{0}. {1}", n + 2, rowData[j]);
                                oSheet.Cells[i + 1, j + 1 + 2].Font.Bold = true;
                            }
                            else
                            {
                                // normal data must be centralized
                                oSheet.Cells[i + 1, j + 1 + 2].HorizontalAlignment = Excel.Constants.xlCenter;

                                // normal data being written
                                oSheet.Cells[i + 1, j + 1 + 2] = rowData[j];

                                // second row of schedule must be bold text
                                if (i==1)
                                {
                                    oSheet.Cells[i + 1, j + 1 + 2].Font.Bold = true;
                                }

                            }
                        }
                    }
                    rowCount++;
                }
                rowCount++;
            }
            
            // changing view
            oXL.ActiveWindow.View = Excel.XlWindowView.xlPageLayoutView;

            this.Application = oXL;
            this.Workbook = oWB;

        }

        private void Format(Excel._Worksheet oSheet, TemplateType templateType)
        {
            switch (templateType)
            {
                case 0:
                    oSheet.Columns[1].ColumnWidth = 22;
                    oSheet.Columns[2].ColumnWidth = 70;
                    oSheet.Columns[3].ColumnWidth = 12;
                    oSheet.Columns[4].ColumnWidth = 12;
                    oSheet.Columns[5].ColumnWidth = 20;
                    oSheet.Columns[6].ColumnWidth = 43;
                    break;
            }
        }
    }
}
