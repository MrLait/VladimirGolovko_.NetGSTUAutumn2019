using DBModelsLinqToSql.Interfaces;
using System.Data.Linq.Mapping;

namespace DBModelsLinqToSql.Models
{
    /// <summary>
    /// Student session results table
    /// </summary>
    [Table(Name = "StudentSessionResults")]
    public class StudentSessionResults : IEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID { get; set; }

        /// <summary>
        /// StudentID
        /// </summary>
        [Column(Name = "StudentID")]
        public int StudentID { get; set; }

        /// <summary>
        /// ExamScheduleID
        /// </summary>
        [Column(Name = "ExamScheduleID")]
        public int ExamScheduleID { get; set; }

        /// <summary>
        /// ExamValue
        /// </summary>
        [Column(Name = "ExamValue")]
        public int ExamValue { get; set; }

        /// <summary>
        /// SetOffValue
        /// </summary>
        [Column(Name = "SetOffValue")]
        public string SetOffValue { get; set; }
    }
}
