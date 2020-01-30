using DAO.DBAccessTechnology.SqlClientUsingReflectionRepository;
using DAO.Factories;
using DAO.Enums;
using DatabaseModels.Models;
using System;
using System.Collections.Generic;
using SaveToXLSXManager;
using System.Reflection;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {

        static void Main()
        {
            string dbConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SQLServerDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            Student student = new Student
            {
                Surname = "Ksd",
                MiddleName = "sddM",
                FirstName = "Dimfffffff",
                DateOfBirth = DateTime.Now.Date,
                Gender = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                GroupID = 1,
                ID = 4
            };

            DAOFactory dAOFactory = DAOFactory.CreateDAOFactory(DBAccessTechnologyEnum.SqlClientUsingReflection, dbConnectionString);
            dAOFactory.CreateStudentRepositoryDAO().Update(student);


            //var location = System.Reflection.Assembly.GetExecutingAssembly().Location;
            //var path = Path.GetDirectoryName(location);

            //SaveSessionResultsToXLSX tableByGoupName = new SaveSessionResultsToXLSX(dbConnectionString, path + @"\Excel");
            //var getStrudentToExpulsionGroupedByGroup = tableByGoupName.GetListOfStudentsForExpulsionGroupedByGroup();
            //tableByGoupName.SaveAverageMinimumMaximumValueforEachGroupToEXCLTables();
            //tableByGoupName.SaveAllSessionResultByGroupToEXCLTables();

        }
    }
}
