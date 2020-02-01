using DBModelsLinqToSql.Interfaces;
using System.Data.Linq.Mapping;

namespace DBModelsLinqToSql.Models
{
    /// <summary>
    /// Student session results table
    /// </summary>
    [Table(Name = "SessionsResults")]
    public class SessionsResults : IEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID { get; set; }

        /// <summary>
        /// StudentID
        /// </summary>
        [Column(Name = "StudentsID")]
        public int StudentsID { get; set; }

        /// <summary>
        /// ExamScheduleID
        /// </summary>
        [Column(Name = "ExamSchedulesID")]
        public int ExamSchedulesID { get; set; }

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
