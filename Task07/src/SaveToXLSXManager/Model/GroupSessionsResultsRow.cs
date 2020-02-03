using System;

namespace SaveToXLSXManager.Model
{
    /// <summary>
    /// Session table of both result
    /// </summary>
    public class GroupSessionsResultsRow
    {
        /// <summary>
        /// ID
        /// </summary>
        public int StudentID { get; set; }

        /// <summary>
        /// NumberOfGroup
        /// </summary>
        public string GroupName { get; set; }

        /// <summary>
        /// NumberOfSession
        /// </summary>
        public int NumberOfSession { get; set; }

        /// <summary>
        /// Surname
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// FirstName
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// MiddleName
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Gender
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// DateOfBirth
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Subject
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// ExamDate
        /// </summary>
        public DateTime ExamDate { get; set; }

        /// <summary>
        /// ExamValue
        /// </summary>
        public int? ExamValue { get; set; }

        /// <summary>
        /// SetOffDate
        /// </summary>
        public DateTime SetOffDate { get; set; }

        /// <summary>
        /// SetOffValue
        /// </summary>
        public string SetOffValue { get; set; }
    }
}
