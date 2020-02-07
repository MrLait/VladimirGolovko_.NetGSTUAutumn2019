using DBModelsLinqToSql.Interfaces;
using System;
using System.Data.Linq.Mapping;

namespace DBModelsLinqToSql.Models
{
    /// <summary>
    /// Exam shedules table model.
    /// </summary>
    [Table(Name = "ExamSchedules")]
    public class ExamSchedules : IEntity
    {
        /// <summary>
        /// Id column.
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID { get; set; }

        /// <summary>
        /// Session id column.
        /// </summary>
        [Column(Name = "SessionsID")]
        public int SessionsID { get; set; }

        /// <summary>
        /// Group id column.
        /// </summary>
        //[ForeignKey("GroupID")]
        [Column(Name = "GroupsID")]
        public int GroupsID { get; set; }

        /// <summary>
        /// Subject id column.
        /// </summary>
        [Column(Name = "SubjectsID")]
        public int SubjectsID { get; set; }

        /// <summary>
        /// Exam date column.
        /// </summary>
        [Column(Name = "ExamDate")]
        public DateTime ExamDate { get; set; }
    }
}