using System;
using DatabaseModels.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseModels.Models
{
    /// <summary>
    /// Exam shedule table
    /// </summary>
    [Table("ExamSchedule")]
    public class ExamSchedule : IEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        [Key]
        public int ID { get; set; }

        /// <summary>
        /// Number of session ID
        /// </summary>
        public int NumberOfSessionID { get; set; }

        /// <summary>
        /// Group ID
        /// </summary>
        [ForeignKey("GroupID")]
        public int GroupID { get; set; }
        
        /// <summary>
        /// Subject
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// ExamDate
        /// </summary>
        public DateTime ExamDate { get; set; }

        /// <summary>
        /// IsEstimated
        /// </summary>
        public string IsEstimated { get; set; }
    }
}