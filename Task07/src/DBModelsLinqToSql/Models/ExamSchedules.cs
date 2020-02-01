using DBModelsLinqToSql.Interfaces;
using System;
using System.Data.Linq.Mapping;

namespace DBModelsLinqToSql.Models
{
    /// <summary>
    /// Exam shedule table
    /// </summary>
    [Table(Name = "ExamSchedules")]
    public class ExamSchedules : IEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID { get; set; }

        /// <summary>
        /// Number of session ID
        /// </summary>
        [Column(Name = "SessionsID")]
        public int SessionsID { get; set; }

        /// <summary>
        /// Group ID
        /// </summary>
        //[ForeignKey("GroupID")]
        [Column(Name = "GroupsID")]
        public int GroupsID { get; set; }

        /// <summary>
        /// Subject
        /// </summary>
        [Column(Name = "SubjectsID")]
        public int SubjectsID { get; set; }

        /// <summary>
        /// ExamDate
        /// </summary>
        [Column(Name = "ExamDate")]
        public DateTime ExamDate { get; set; }
    }
}