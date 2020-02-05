using DAO.Factories;
using SaveToXLSXManager;
using SaveToXLSXManager.Interfaces;
using SaveToXLSXManager.Model;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SQLServerDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        static void Main(string[] args)
        {
            LinqToSqlSingelton linqToSqlSingelton =  LinqToSqlSingelton.GetInstance(connectionString);
            
            DAOFactory dAOFactory = LinqToSqlSingelton.GetInstance(connectionString);
            dAOFactory.CreateExaminersRepository();

            Func<GroupSessionsResultsRow, object> orderByFunc = x => x.StudentID;
            Func<PivotResultsRow, object> orderByFuncPivot = x => x.AverageExamValue;

            Excel excel = new Excel(@"..\..\Excel", "TestHeader");
            //IReport averageScoreForEachexExaminerReport = new AverageScoreForEachexExaminerReport(
            //    dAOFactory, 1, x => x.SessionNumber, false);

            //averageScoreForEachexExaminerReport.GetData();

            IReport dynamicsAverageSubjectScoreByYearsReport = new DynamicsAverageSubjectScoreByYearsReport(linqToSqlSingelton, x => x.ExamDataYear, false);

            dynamicsAverageSubjectScoreByYearsReport.GetData();
            Excel dynamicsAverageSubjectScoreByYearsReportExcel = new Excel(@"..\..\Excel", "YearsReport");
            dynamicsAverageSubjectScoreByYearsReportExcel.SaveToXLSX(dynamicsAverageSubjectScoreByYearsReport);

            //IReport report = new GroupSessionsResultsReport(dAOFactory, "PM-2", 1, orderByFunc, false);
            //IReport pivotReport = new PivotResultsReport(dAOFactory, "PM-1", orderByFuncPivot, false);

            StudentsToBeExpelledReport studentToBeExpelled = new StudentsToBeExpelledReport(linqToSqlSingelton, 90);
            studentToBeExpelled.GetStudentsToBeExpelled();

            // excel.SaveToXLSX(report);
            //Excel excelPivot = new Excel(@"..\..\Excel", "TestHeaderPivot");

            // excelPivot.SaveToXLSX(pivotReport);

            //  Console.Read();
        }
    }
}
