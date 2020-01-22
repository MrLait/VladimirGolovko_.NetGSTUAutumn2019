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
                Surname = "Ksd",
                MiddleName = "sddM",
                FirstName = "Dimfffffff",
                DateOfBirth = DateTime.Now.Date,
                Gender = "Maldsde",
                StudentGroup = 1,
                StudentID = 4
            };


            StudentObject studentObject = new StudentObject(connectionString);
            studentObject.Add(student);

           // var testObj = studentObject.GetByID(student.StudentID);
           // studentObject.Delete(student.StudentID);
            studentObject.Update(student);
            var getAllStudents = studentObject.GetAll();
        }
    }
}
