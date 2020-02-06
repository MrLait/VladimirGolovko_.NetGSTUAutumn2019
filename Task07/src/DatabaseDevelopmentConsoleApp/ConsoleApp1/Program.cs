using DAO.Factories;
using SaveToXLSXManager;
using SaveToXLSXManager.Interfaces;
using SaveToXLSXManager.Model;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<GroupSessionsResultsRow, object> orderByFunc = x => x.StudentID;
            Func<PivotResultsRow, object> orderByFuncPivot = x => x.AverageExamValue;

            Excel excel = new Excel(@"..\..\Excel", "TestHeader");
            //IReport averageScoreForEachexExaminerReport = new AverageScoreForEachexExaminerReport(
            //    dAOFactory, 1, x => x.SessionNumber, false);

            //averageScoreForEachexExaminerReport.GetData();

            IReport dynamicsAverageSubjectScoreByYearsReport = new DynamicsAverageSubjectScoreByYearsReport(x => x.ExamDataYear, false);

            dynamicsAverageSubjectScoreByYearsReport.GetData();
            Excel dynamicsAverageSubjectScoreByYearsReportExcel = new Excel(@"..\..\Excel", "YearsReport");
            dynamicsAverageSubjectScoreByYearsReportExcel.SaveToXLSX(dynamicsAverageSubjectScoreByYearsReport);

            //IReport report = new GroupSessionsResultsReport(dAOFactory, "PM-2", 1, orderByFunc, false);
            //IReport pivotReport = new PivotResultsReport(dAOFactory, "PM-1", orderByFuncPivot, false);

            StudentsToBeExpelledReport studentToBeExpelled = new StudentsToBeExpelledReport(90);
            studentToBeExpelled.GetStudentsToBeExpelled();

            // excel.SaveToXLSX(report);
            //Excel excelPivot = new Excel(@"..\..\Excel", "TestHeaderPivot");

            // excelPivot.SaveToXLSX(pivotReport);

            //  Console.Read();
        }
    }
}
