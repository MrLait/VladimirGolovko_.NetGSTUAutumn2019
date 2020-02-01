using DBModelsLinqToSql.Interfaces;
using System;
using System.Data.Linq.Mapping;

namespace DBModelsLinqToSql.Models
{
    /// <summary>
    /// Student table
    /// </summary>
    [Table(Name = "Examiners")]
    public class Examiners : IEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID { get; set; }

        /// <summary>
        /// Surname
        /// </summary>
        [Column(Name = "Surname")]
        public string Surname { get; set; }

        /// <summary>
        /// FirstName
        /// </summary>
        [Column(Name = "FirstName")]
        public string FirstName { get; set; }

        /// <summary>
        /// MiddleName
        /// </summary>
        [Column(Name = "MiddleName")]
        public string MiddleName { get; set; }

    }
}
