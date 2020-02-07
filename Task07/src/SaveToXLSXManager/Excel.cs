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
        private string _path;
        private string _fileName;
        private Application _excelApplication;
        private Workbook _excelWorkbook;
        private Worksheet _excelWorksheet;

        public Excel(string path, string fileName = "outputName")
        {
            _path = path;
            _fileName = fileName;
            _excelApplication = new Application();
            _excelApplication.Visible = false;
            _excelApplication.DisplayAlerts = false;
        }

        public void SaveToXLSX(IReport report)
        {
            string outputPath = _path + _fileName;
            
            if (!Directory.Exists(_path))
                Directory.CreateDirectory(_path);

            _excelWorkbook = _excelApplication.Workbooks.Add();
            _excelWorksheet = (Worksheet)_excelWorkbook.Sheets[1];
            _excelWorksheet.Name = _fileName;

            try
            {
                var header = report.GetDataHeader();
                var data = report.GetData();
                int row = 1;
                int cells = 1;

                foreach (var cellValue in header)
                {
                    _excelWorksheet.Cells[row, cells] = cellValue;
                    cells++;
                }

                foreach (var item in data)
                {
                    cells = 1;
                    row++;
                    foreach (var cellValue in item)
                    {
                        _excelWorksheet.Cells[row, cells] = cellValue;
                        cells++;
                    }
                }

                _excelWorksheet.Rows.AutoFit();
                _excelWorksheet.Columns.AutoFit();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _excelWorkbook.SaveAs(outputPath);
                _excelWorkbook.Close(true);
                _excelApplication.Quit();
            }
        }
    }
}
