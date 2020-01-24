using DAO.DBAccessTechnology.SqlClientUsingReflectionRepository;
using DAO.Factories;
using DAO.Enums;
using DatabaseModels.Models;
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
                Gender = "Famale",
                GroupID = 1,
                ID = 4
            };


            StudentRepository studentRepository = new StudentRepository(dbConnectionString);
            studentRepository.Add(student);
            //ICRUD<T> cRUD = new 
           // var testObj = studentObject.GetByID(student.StudentID);
           // studentObject.Delete(student.StudentID);
            studentRepository.Update(student);
            var getAllStudents = studentRepository.GetAll();

            DAOFactory daoFactory = DAOFactory.CreateDAOFactory(DBAccessTechnologyEnum.SqlClientUsingReflection, dbConnectionString);
            StudentRepository studentRepositoryTwo = daoFactory.CreateStudentRepositoryDAO();

            IList<Student> students = studentRepositoryTwo.GetAll();
            studentRepositoryTwo.Add(student);
        }
    }
}
