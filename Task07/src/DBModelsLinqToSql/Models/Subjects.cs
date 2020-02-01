using DBModelsLinqToSql.Interfaces;
using System;
using System.Data.Linq.Mapping;

namespace DBModelsLinqToSql.Models
{
    /// <summary>
    /// Student table
    /// </summary>
    [Table(Name = "Subjects")]
    public class Subjects : IEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID { get; set; }

        /// <summary>
        /// Surname
        /// </summary>
        [Column(Name = "SubjectName")]
        public string SubjectName { get; set; }

        /// <summary>
        /// IsAssessment 
        /// </summary>
        [Column(Name = "IsAssessment")]
        public string IsAssessment { get; set; }

        /// <summary>
        /// ExaminersID
        /// </summary>
        [Column(Name = "ExaminersID")]
        public int ExaminersID { get; set; }
    }
}
