using DBModelsLinqToSql.Interfaces;
using System.Data.Linq.Mapping;

namespace DBModelsLinqToSql.Models
{
    /// <summary>
    /// Student table model.
    /// </summary>
    [Table(Name = "Examiners")]
    public class Examiners : IEntity
    {
        /// <summary>
        /// ID column.
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

    }
}
