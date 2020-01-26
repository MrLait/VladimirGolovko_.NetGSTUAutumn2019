using System;

namespace SaveToXLSXManager.Model
{
    public class SessionTableOfBothResult
    {
        public int ID { get; set; }
        public string NumberOfGroup { get; set; }
        public int NumberOfSession { get; set; }
        public string Surname { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Subject { get; set; }
        public DateTime ExamDate { get; set; }
        public int ExamValue { get; set; }
        public DateTime SetOffDate { get; set; }
        public string SetOffValue { get; set; }
    }
}
