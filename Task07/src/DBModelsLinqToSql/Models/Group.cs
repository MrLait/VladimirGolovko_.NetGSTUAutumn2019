using DBModelsLinqToSql.Interfaces;
using System;
using System.Data.Linq.Mapping;

namespace DBModelsLinqToSql.Models
{
    /// <summary>
    /// Group table
    /// </summary>
    public class Group : IEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID { get; set; }

        /// <summary>
        /// Number of group
        /// </summary>
        [Column(Name = "NumberOfGroup")]
        public string NumberOfGroup { get; set; }
    }
}
