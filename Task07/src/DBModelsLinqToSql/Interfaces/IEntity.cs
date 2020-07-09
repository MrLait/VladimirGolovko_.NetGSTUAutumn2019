using System.Data.Linq.Mapping;

namespace DBModelsLinqToSql.Interfaces
{
    /// <summary>
    /// Entity interface with ID field.
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// ID column.
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        int ID { get; set; }
    }
}