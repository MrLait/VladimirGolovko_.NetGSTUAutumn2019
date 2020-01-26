using System;
using DatabaseModels.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseModels.Models
{
    /// <summary>
    /// Student session results table
    /// </summary>
    [Table("StudentSessionResults")]
    public class StudentSessionResults : IEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        [Key]
        public int ID { get; set; }

        /// <summary>
        /// StudentID
        /// </summary>
        [ForeignKey("StudentID")]
        public int StudentID { get; set; }

        /// <summary>
        /// ExamScheduleID
        /// </summary>
        [ForeignKey("ExamScheduleID")]
        public int ExamScheduleID { get; set; }

        /// <summary>
        /// ExamValue
        /// </summary>
        public int ExamValue { get; set; }

        /// <summary>
        /// SetOffValue
        /// </summary>
        public string SetOffValue { get; set; }
    }
}
