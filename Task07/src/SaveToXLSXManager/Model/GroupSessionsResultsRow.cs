using System;

namespace SaveToXLSXManager.Model
{
    /// <summary>
    /// Implementation of table columns.
    /// </summary>
    public class GroupSessionsResultsRow
    {
        /// <summary>
        /// Student id column.
        /// </summary>
        public int StudentID { get; set; }

        /// <summary>
        /// Group name column.
        /// </summary>
        public string GroupName { get; set; }

        /// <summary>
        /// Number of session column.
        /// </summary>
        public int NumberOfSession { get; set; }

        /// <summary>
        /// Surname column.
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// First name column.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Middle name column.
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Gender column.
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// Date of birth column.
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Subject column.
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Exam date column.
        /// </summary>
        public DateTime ExamDate { get; set; }

        /// <summary>
        /// Exam value column.
        /// </summary>
        public int? ExamValue { get; set; }

        /// <summary>
        /// Set-off date column.
        /// </summary>
        public DateTime SetOffDate { get; set; }

        /// <summary>
        /// Set-off value column.
        /// </summary>
        public string SetOffValue { get; set; }
    }
}
