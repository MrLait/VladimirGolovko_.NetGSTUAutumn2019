using System.Data.Linq.Mapping;

namespace DBModelsLinqToSql.Interfaces
{
    /// <summary>
    /// Entity interface
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        int ID { get; set; }
    }
}