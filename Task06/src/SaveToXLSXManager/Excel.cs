using Microsoft.Office.Interop.Excel;
using System;

namespace SaveToXLSXManager
{
    public class Excel
    {
        public string Path { get; set; }
        public string WorkSheetName { get; set; }
        public Application ExcelApp { get; set; }
        public Workbook Workbook { get; set; }
        public Worksheet Worksheet { get; set; }
        public Range CelRange { get; set; }

        public Excel() 
        {
            ExcelApp = new Application();
            ExcelApp.Visible = false;
            ExcelApp.DisplayAlerts = false;
        }

        public void CreateNewFile()
        {
            Workbook = ExcelApp.Workbooks.Add(Type.Missing);
        }

        public void CreateNewSheet(string workSheetName)
        {
            Worksheet = Workbook.ActiveSheet;
            Worksheet.Name = workSheetName;
        }

        public void WriteDataToCell(int row, int collum, object data)
        {
            Worksheet.Cells[row, collum] = data;
        }
        public void WriteDataToCell(int row, int collum, DateTime data)
        {
            Worksheet.Cells[row, collum] = data;
        }
        public void WriteDataToCell(int row, int collum, int data)
        {
            Worksheet.Cells[row, collum] = data;
        }
        public void WriteDataToCell(int row, int collum, string data)
        {
            Worksheet.Cells[row, collum] = data;
        }

        public void Save()
        {
            Workbook.Save();
        }

        public void SaveAs(string path)
        {
            Workbook.SaveAs(path);
        }

        public void Close()
        {
            Workbook.Close();
        }

        public void Quit()
        {
            ExcelApp.Quit();
        }

    }
}
