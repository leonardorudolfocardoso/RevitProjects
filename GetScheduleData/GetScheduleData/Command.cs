#region Namespaces
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using Excel = Microsoft.Office.Interop.Excel;
#endregion

namespace GetScheduleData
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

            // creating bfs document instance
            BfsDocument bfsDocument = new BfsDocument(doc);

            // collecting schedules data from Revit
            List<List<List<string>>> schedulesData = getSchedulesData(doc);
            List<List<List<string>>> revisionData = getRevisionData(doc);
            if (schedulesData == null || revisionData == null)
            {
                return Result.Cancelled;
            }

            // asking file name to save
            System.Windows.Forms.SaveFileDialog saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            saveFileDialog.InitialDirectory = doc.PathName;
            saveFileDialog.Title = "Salvar";
            saveFileDialog.DefaultExt = ".xlsx";
            saveFileDialog.Filter = "Excel file|*.xlsx";
            saveFileDialog.FileName += string.Format("{0}-PLH-Rev.{1}", bfsDocument.Codigo, bfsDocument.Revisao);
            saveFileDialog.OverwritePrompt = false;

            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                // creating export to excel instance
                ExportToExcel exportToExcel = new ExportToExcel(
                    saveFileDialog.FileName,
                    "Planilha de quantitativos",
                    schedulesData,
                    revisionData);

                // solving export
                exportToExcel.Export(ExportToExcel.TemplateType.QUANTITATIVO, bfsDocument);

                // running export() and getting the application created
                Excel._Application oXL = exportToExcel.Application;
                Excel._Workbook oWB = exportToExcel.Workbook;


                oXL.UserControl = false;
                try
                {
                    // saving and closing
                    oWB.SaveAs(saveFileDialog.FileName, Excel.XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing,
                                false, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
                                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                }
                catch (Exception)
                {
                    System.Windows.Forms.MessageBox.Show("O arquivo a ser substituído está aberto.", "Erro");
                    return Result.Failed;
                }
                oWB.Close();
                oXL.Quit();

                // launching the file
                System.Diagnostics.Process.Start(saveFileDialog.FileName);

                return Result.Succeeded;
            }

            return Result.Cancelled;
        }

        public List<List<List<string>>> getRevisionData(Document doc)
        {
            // collecting all the schedules elements
            List<Element> revisionElements = new List<Element>
                                                 (new FilteredElementCollector(doc)
                                                 .OfCategory(BuiltInCategory.OST_Schedules)
                                                 .ToElements());
            List<List<List<string>>> revisionData = new List<List<List<string>>>();
            // iterating through the elements collected and getting the first titleblock revision
            foreach (Element element in revisionElements)
            {
                if ((element as ViewSchedule).IsTitleblockRevisionSchedule)
                {
                    ViewSchedule viewSchedule = element as ViewSchedule;
                    revisionData.Add(getScheduleData(doc, viewSchedule));
                    break;
                }
            }
            return revisionData;
        }

        public List<List<List<string>>> getSchedulesData(Document doc)
        {
            // collecting all schedules elements in doc
            List<Element> scheduleElements = new List<Element>
                                                (new FilteredElementCollector(doc)
                                                .OfCategory(BuiltInCategory.OST_Schedules)
                                                .ToElements());

            // creating select from list form to choose which schedule to export
            SelectFromList selectFromList = new SelectFromList(scheduleElements);
            selectFromList.ShowDialog();
            System.Windows.Forms.DialogResult dialogResult = selectFromList.DialogResult;

            // if the form was cancelled, return null
            if (dialogResult == System.Windows.Forms.DialogResult.Cancel)
            {
                return null;
            }

            // overwritting the schedule elements with the choosen ones
            scheduleElements = selectFromList.GetChoosedElements();

            // creating list to store schedules data
            List<List<List<string>>> schedulesData = new List<List<List<string>>>();

            // iterating through schedule elements selected and getting data
            foreach (Element e in scheduleElements)
            {
                ViewSchedule viewSchedule = e as ViewSchedule;
                schedulesData.Add(getScheduleData(doc, viewSchedule));
            }
            return schedulesData;
        }

        public List<List<string>> getScheduleData(Document doc, ViewSchedule viewSchedule)
        {
            TableData table = viewSchedule.GetTableData();
            TableSectionData section = table.GetSectionData(SectionType.Body);
            int nRows = section.NumberOfRows;
            int nColumns = section.NumberOfColumns;

            List<List<string>> scheduleData = new List<List<string>>();


            scheduleData.Add(new List<string>() { viewSchedule.Name });
            for (int i = 0; i < nRows; i++)
            {
                List<string> rowData = new List<string>();

                for (int j = 0; j < nColumns; j++)
                {
                    rowData.Add(viewSchedule.GetCellText(SectionType.Body, i, j));
                }
                scheduleData.Add(rowData);
            }
            return scheduleData;
        }
    }
}
