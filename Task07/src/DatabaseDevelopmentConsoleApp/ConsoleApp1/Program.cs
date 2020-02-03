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
            DAOFactory dAOFactory =  LinqToSqlSingelton.GetInstance(connectionString);

            Func<GroupSessionsResultsRow, object> orderByFunc = x => x.StudentID;
            Func<PivotResultsRow, object> orderByFuncPivot = x => x.AverageExamValue;

            Excel excel = new Excel(@"..\..\Excel", "TestHeader");

            IReport report = new GroupSessionsResultsReport(dAOFactory, "PM-2", 1, orderByFunc, false);
            IReport pivotReport = new PivotResultsReport(dAOFactory, "PM-1", orderByFuncPivot, false);

           // excel.SaveToXLSX(report);
            Excel excelPivot = new Excel(@"..\..\Excel", "TestHeaderPivot");

            excelPivot.SaveToXLSX(pivotReport);

            //LinqToSqlSingelton linqToSqlSingelton = new 

            //Students student = new Students
            //{
            //    ID = 4,
            //    Surname = "Ksd",
            //    FirstName = "Dimfffffff",
            //    MiddleName = "sddM",
            //    Gender = "Famale",
            //    DateOfBirth = DateTime.Now.Date,
            //    GroupsID = 2
            //};
            ////// добавляем его в таблицу Users
            //////db.GetTable<Student>().InsertOnSubmit(student);
            //////db.SubmitChanges();


            //Student student2 = new Student
            //{
            //ID = 5,
            //Surname = "Ksdeeesssse1",
            //FirstName = "Dimfffffff1",
            //MiddleName = "sddM1",
            //Gender = "Famale1",
            //DateOfBirth = DateTime.Now.Date,
            //GroupID = 2,
            //};

            //DataContext db = new DataContext(connectionString);
            //var user2 = db.GetTable<Student>().Where(x => x.ID == student2.ID).SingleOrDefault();
            //GetUpdateParameter(student2, user2);
            //db.SubmitChanges();

            //user2.MiddleName = "Aaaaaaaaaaaaaaa";
            ////user2 = student2;
            ////user2 = (Student)student2.Clone();
            //// user2.ID = 0;
            //// сохраним изменения

            //// db.GetTable<Student>().Attach(student2);
            // db.SubmitChanges();


            //Student student = new Student
            //{
            //    //ID = 4,
            //    Surname = "Ksd",
            //    FirstName = "Dimfffffff",
            //    MiddleName = "sddM",
            //    Gender = "Famale",
            //    DateOfBirth = DateTime.Now.Date,
            //    GroupID = 2,
            //
            //
            //};
            //

            //DAOFactory test = DAOFactory.CreateDAOFactory(connectionString);
            //test.CreateStudentsRepository().Add(student);
            //
            ////var test1 =  test.CreateStudentRepositoryDAO().GetAll();
            // var test2 = test.CreateStudentRepositoryDAO().Update(student);
            // var getByIDTest = test.CreateStudentRepositoryDAO().GetByID(7);
            //var addNeObjTest = 
            //test.CreateStudentRepositoryDAO().Delete(7);


            //  Console.Read();
        }

        //static void Main()
        //{
        //    string dbConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SQLServerDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //    Student student = new Student
        //    {
        //        Surname = "Ksd",
        //        MiddleName = "sddM",
        //        FirstName = "Dimfffffff",
        //        DateOfBirth = DateTime.Now.Date,
        //        Gender = "Famale",
        //        GroupID = 1,
        //        ID = 4
        //    };


        //    var location = System.Reflection.Assembly.GetExecutingAssembly().Location;
        //    var path = Path.GetDirectoryName(location);

        //    SaveSessionResultsToXLSX tableByGoupName = new SaveSessionResultsToXLSX(dbConnectionString, path + @"\Excel");
        //    var getStrudentToExpulsionGroupedByGroup = tableByGoupName.GetListOfStudentsForExpulsionGroupedByGroup();
        //    tableByGoupName.SaveAverageMinimumMaximumValueforEachGroupToEXCLTables();
        //    tableByGoupName.SaveAllSessionResultByGroupToEXCLTables();

        //}
    }
}
