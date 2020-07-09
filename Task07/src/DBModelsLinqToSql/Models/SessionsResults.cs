using DBModelsLinqToSql.Interfaces;
using System.Data.Linq.Mapping;

namespace DBModelsLinqToSql.Models
{
    /// <summary>
    /// Sessions results table model.
    /// </summary>
    [Table(Name = "SessionsResults")]
    public class SessionsResults : IEntity
    {
        /// <summary>
        /// Id column.
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID { get; set; }

        /// <summary>
        /// Student id column.
        /// </summary>
        [Column(Name = "StudentsID")]
        public int StudentsID { get; set; }

        /// <summary>
        /// Exam schedule id column.
        /// </summary>
        [Column(Name = "ExamSchedulesID")]
        public int ExamSchedulesID { get; set; }

        /// <summary>
        /// Exam value column.
        /// </summary>
        [Column(Name = "ExamValue")]
        public int? ExamValue { get; set; }

        /// <summary>
        /// Set-off value column.
        /// </summary>
        [Column(Name = "SetOffValue")]
        public string SetOffValue { get; set; }
    }
}
