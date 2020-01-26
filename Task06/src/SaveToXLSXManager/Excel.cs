using Microsoft.Office.Interop.Excel;
using System;

namespace SaveToXLSXManager
{

    /// <summary>
    /// Class for access to EXCEL file
    /// </summary>
    public class Excel
    {
        /// <summary>
        /// Path
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// WorkSheetName
        /// </summary>
        public string WorkSheetName { get; set; }

        /// <summary>
        /// ExcelApp
        /// </summary>
        public Application ExcelApp { get; set; }

        /// <summary>
        /// Workbook
        /// </summary>
        public Workbook Workbook { get; set; }

        /// <summary>
        /// Worksheet
        /// </summary>
        public Worksheet Worksheet { get; set; }

        /// <summary>
        /// CelRange
        /// </summary>
        public Range CelRange { get; set; }

        /// <summary>
        /// Constructor <seealso cref="Excel"/>
        /// </summary>
        public Excel() 
        {
            ExcelApp = new Application();
            ExcelApp.Visible = false;
            ExcelApp.DisplayAlerts = false;
        }

        /// <summary>
        /// Create new excel file.
        /// </summary>
        public void CreateNewFile()
        {
            Workbook = ExcelApp.Workbooks.Add(Type.Missing);
        }

        /// <summary>
        /// Create a new sheet
        /// </summary>
        /// <param name="workSheetName"> Sheet name</param>
        public void CreateNewSheet(string workSheetName)
        {
            Worksheet = Workbook.ActiveSheet;
            Worksheet.Name = workSheetName;
        }

        /// <summary>
        /// Write to Excel file
        /// </summary>
        /// <param name="row">row</param>
        /// <param name="collum">collum</param>
        /// <param name="data">data</param>
        public void WriteDataToCell(int row, int collum, object data)
        {
            Worksheet.Cells[row, collum] = data;
        }

        /// <summary>
        /// Save excel file
        /// </summary>
        public void Save()
        {
            Workbook.Save();
        }

        /// <summary>
        /// Save as excel file
        /// </summary>
        /// <param name="path">path to folder</param>
        public void SaveAs(string path)
        {
            Workbook.SaveAs(path);
        }

        /// <summary>
        /// Close file
        /// </summary>
        public void Close()
        {
            Workbook.Close();
        }

        /// <summary>
        /// Quit file
        /// </summary>
        public void Quit()
        {
            ExcelApp.Quit();
        }

    }
}
