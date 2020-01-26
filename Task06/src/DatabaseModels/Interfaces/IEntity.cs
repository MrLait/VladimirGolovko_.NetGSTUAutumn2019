using System.ComponentModel.DataAnnotations;

namespace DatabaseModels.Interfaces
{
    /// <summary>
    /// Entity interface
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        [Key]
        int ID { get; set; }
    }
}