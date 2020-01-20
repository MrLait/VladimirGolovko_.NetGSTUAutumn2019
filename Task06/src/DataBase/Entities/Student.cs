using System;

namespace DataBase.Entities
{
    [TableName("Student")]
    public class Student
    {
        [DbColumn("StudentID")]
        public int StudentID { get; set; }
        [DbColumn("Surname")]
        public string Surname { get; set; }
        [DbColumn("FirstName")]
        public string FirstName { get; set; }
        [DbColumn("MiddleName")]
        public string MiddleName { get; set; }
        [DbColumn("Gender")]
        public string Gender { get; set; }
        [DbColumn("DateOfBirth")]
        public DateTime DateOfBirth { get; set; }
        [DbColumn("StudentGroup")]
        public int StudentGroup { get; set; }

    }
}
