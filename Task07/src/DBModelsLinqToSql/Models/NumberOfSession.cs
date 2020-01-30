using DBModelsLinqToSql.Interfaces;
using System;
using System.Data.Linq.Mapping;

namespace DBModelsLinqToSql.Models
{
    /// <summary>
    /// Number of session table
    /// </summary>
    public class NumberOfSession : IEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID { get; set; }

        /// <summary>
        /// Number of session
        /// </summary>
        [Column(Name = "NumOfSession")]
        public int NumOfSession { get; set; }
    }
}
