using DBModelsLinqToSql.Interfaces;
using System;
using System.Data.Linq.Mapping;

namespace DBModelsLinqToSql.Models
{
    /// <summary>
    /// Sessions table model.
    /// </summary>
    [Table(Name = "Sessions")]
    public class Sessions : IEntity
    {
        /// <summary>
        /// Id column.
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID { get; set; }

        /// <summary>
        /// Sessions column.
        /// </summary>
        [Column(Name = "Session")]
        public int Session { get; set; }
    }
}
