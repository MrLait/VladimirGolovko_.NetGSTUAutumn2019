using DBModelsLinqToSql.Interfaces;
using System;
using System.Data.Linq.Mapping;

namespace DBModelsLinqToSql.Models
{
    /// <summary>
    /// Number of session table
    /// </summary>
    [Table(Name = "Sessions")]
    public class Sessions : IEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID { get; set; }

        /// <summary>
        /// Number of session
        /// </summary>
        [Column(Name = "Session")]
        public int Session { get; set; }
    }
}
