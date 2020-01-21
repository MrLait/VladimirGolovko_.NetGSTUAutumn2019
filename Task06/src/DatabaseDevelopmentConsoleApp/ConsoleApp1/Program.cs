using DAO.Entities;
using DAO.Objects;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SQLServerDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            Student student = new Student
            {
                Surname = "K",
                MiddleName = "M",
                FirstName = "Dim",
                DateOfBirth = DateTime.Now.Date,
                Gender = "Male",
                StudentGroup = 1,
                StudentID = 2
            };

            StudentObject studentObject = new StudentObject(connectionString);
            studentObject.Add(student);

             var testObj = studentObject.GetByID(student.StudentID);


        }
    }
}
