using DAO.DBAccessTechnology.SqlClientUsingReflectionObjects;
using DAO.Factories;
using DAO.Models;
using DAO.Enums;
using System;
using System.Collections.Generic;

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
                Gender = "Maldsde",
                StudentGroup = 1,
                StudentID = 4
            };


            StudentObject studentObject = new StudentObject(dbConnectionString);
            studentObject.Add(student);
            //ICRUD<T> cRUD = new 
           // var testObj = studentObject.GetByID(student.StudentID);
           // studentObject.Delete(student.StudentID);
            studentObject.Update(student);
            var getAllStudents = studentObject.GetAll();

            DAOFactory daoFactory = DAOFactory.CreateDAOFactory(DBAccessTechnologyEnum.SqlClientUsingReflection, dbConnectionString);
            StudentObject studentObjectTwo = daoFactory.CreateStudentObjectDAO(dbConnectionString);

            IList<Student> students = studentObjectTwo.GetAll();
            studentObjectTwo.Add(student);
        }
    }
}
