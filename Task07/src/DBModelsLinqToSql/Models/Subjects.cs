using DBModelsLinqToSql.Interfaces;
using System;
using System.Data.Linq.Mapping;

namespace DBModelsLinqToSql.Models
{
    /// <summary>
    /// Subjects table model
    /// </summary>
    [Table(Name = "Subjects")]
    public class Subjects : IEntity
    {
        /// <summary>
        /// Id column.
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID { get; set; }

        /// <summary>
        /// Subject name column.
        /// </summary>
        [Column(Name = "SubjectName")]
        public string SubjectName { get; set; }

        /// <summary>
        /// Is assessment column.
        /// </summary>
        [Column(Name = "IsAssessment")]
        public string IsAssessment { get; set; }

        /// <summary>
        /// Examiners id column.
        /// </summary>
        [Column(Name = "ExaminersID")]
        public int ExaminersID { get; set; }
    }
}
