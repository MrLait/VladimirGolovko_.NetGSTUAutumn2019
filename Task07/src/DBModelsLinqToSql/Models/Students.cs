using DBModelsLinqToSql.Interfaces;
using System;
using System.Data.Linq.Mapping;

namespace DBModelsLinqToSql.Models
{
    /// <summary>
    /// Students table model.
    /// </summary>
    [Table(Name = "Students")]
    public class Students : IEntity
    {
        /// <summary>
        /// Id column.
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID { get; set; }

        /// <summary>
        /// Surname column.
        /// </summary>
        [Column(Name = "Surname")]
        public string Surname { get; set; }

        /// <summary>
        /// First name column.
        /// </summary>
        [Column(Name = "FirstName")]
        public string FirstName { get; set; }

        /// <summary>
        /// Middle name column.
        /// </summary>
        [Column(Name = "MiddleName")]
        public string MiddleName { get; set; }

        /// <summary>
        /// Gender column.
        /// </summary>
        [Column(Name = "Gender")]
        public string Gender { get; set; }

        /// <summary>
        /// Date of birth column.
        /// </summary>
        [Column(Name = "DateOfBirth")]
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Group id column.
        /// </summary>
        [Column(Name = "GroupsID")]
        public int GroupsID { get; set; }
    }
}
