using DBModelsLinqToSql.Interfaces;
using System;
using System.Data.Linq.Mapping;

namespace DBModelsLinqToSql.Models
{
    /// <summary>
    /// Specialties table model.
    /// </summary>
    [Table(Name = "Specialties")]
    public class Specialties : IEntity
    {
        /// <summary>
        /// Id column.
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID { get; set; }

        /// <summary>
        /// Specialtie column.
        /// </summary>
        [Column(Name = "Specialtie")]
        public string Specialtie { get; set; }

    }
}
