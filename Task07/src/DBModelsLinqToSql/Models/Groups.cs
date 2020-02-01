using DBModelsLinqToSql.Interfaces;
using System;
using System.Data.Linq.Mapping;

namespace DBModelsLinqToSql.Models
{
    /// <summary>
    /// Group table
    /// </summary>
    [Table(Name = "Groups")]
    public class Groups : IEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID { get; set; }

        /// <summary>
        /// Number of group
        /// </summary>
        [Column(Name = "GroupName")]
        public string GroupName { get; set; }

        [Column(Name = "SpecialtiesID")]
        public int SpecialtiesID { get; set; }
    }
}
