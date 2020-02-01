using DBModelsLinqToSql.Interfaces;
using System;
using System.Data.Linq.Mapping;

namespace DBModelsLinqToSql.Models
{
    /// <summary>
    /// Group table
    /// </summary>
    [Table(Name = "Specialties")]
    public class Specialties : IEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID { get; set; }

        /// <summary>
        /// Number of group
        /// </summary>
        [Column(Name = "Specialtie")]
        public string Specialtie { get; set; }

    }
}
