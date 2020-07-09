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
        private readonly string _path;
        private readonly string _fileName;
        private readonly Application _excelApplication;
        private Workbook _excelWorkbook;
        private Worksheet _excelWorksheet;

        /// <summary>
        /// Constructor <see cref="Excel"/>
        /// </summary>
        /// <param name="path">Path to save file.</param>
        /// <param name="fileName">Set file name.</param>
        public Excel(string path, string fileName = "outputName")
        {
            _path = path;
            _fileName = fileName;
            _excelApplication = new Application
            {
                Visible = false,
                DisplayAlerts = false
            };
        }

        /// <summary>
        /// Save to excel format.
        /// </summary>
        /// <param name="report">Input data for save to excel file.</param>
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
