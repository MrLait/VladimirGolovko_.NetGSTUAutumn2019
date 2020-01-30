using DBModelsLinqToSql.Interfaces;
using System;
using System.Data.Linq.Mapping;

namespace DBModelsLinqToSql.Models
{
    /// <summary>
    /// Exam shedule table
    /// </summary>
    [Table(Name = "ExamSchedule")]
    public class ExamSchedule : IEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID { get; set; }

        /// <summary>
        /// Number of session ID
        /// </summary>
        [Column(Name = "NumberOfSessionID")]
        public int NumberOfSessionID { get; set; }

        /// <summary>
        /// Group ID
        /// </summary>
        //[ForeignKey("GroupID")]
        [Column(Name = "GroupID")]
        public int GroupID { get; set; }

        /// <summary>
        /// Subject
        /// </summary>
        [Column(Name = "Subject")]
        public string Subject { get; set; }

        /// <summary>
        /// ExamDate
        /// </summary>
        [Column(Name = "ExamDate")]
        public DateTime ExamDate { get; set; }

        /// <summary>
        /// IsEstimated
        /// </summary>
        [Column(Name = "IsEstimated")]
        public string IsEstimated { get; set; }
    }
}