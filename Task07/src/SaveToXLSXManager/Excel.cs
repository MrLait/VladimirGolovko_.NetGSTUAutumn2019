using Microsoft.Office.Interop.Excel;
using SaveToXLSXManager.Interfaces;
using System;
using System.IO;

namespace SaveToXLSXManager
{

    /// <summary>
    /// Class for access to EXCEL file
    /// </summary>
    public class Excel
    {
        public string Path { get; private set; }
        public string FileName { get; private set; }
        public string WorkSheetName { get; set; }
        public Application ExcelApplication { get; private set; }
        public Workbook ExcelWorkbook { get; private set; }
        public Worksheet ExcelWorksheet { get; private set; }
        
        public Excel(string path, string fileName = "outputName")
        {
            Path = path;
            FileName = fileName;
            ExcelApplication = new Application();
        }

        public void SaveToXLSX(IReport report)
        {
            string outputPath = Path + FileName + ".xlsx";

            Directory.CreateDirectory(Path);


            if (!Directory.Exists(Path))
                throw new FileNotFoundException("Directory is not found.");
            
            ExcelWorkbook = ExcelApplication.Workbooks.Add();
            ExcelWorksheet = (Worksheet)ExcelWorkbook.Sheets[1];
            ExcelWorksheet.Name = FileName;

            try
            {
                var header = report.GetDataHeader();

                int row = 1;
                int cells = 1;

                    foreach (var cellValue in header)
                    {
                        ExcelWorksheet.Cells[row, cells] = cellValue;
                        cells++;
                    }

                ExcelWorksheet.Rows.AutoFit();
                ExcelWorksheet.Columns.AutoFit();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally 
            {
                ExcelWorkbook.SaveAs(outputPath);
                ExcelWorkbook.Close(true);
                ExcelApplication.Quit();
            }
        }
    }
}
