using DatabaseModels.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace DatabaseModels.Models
{
    /// <summary>
    /// Group table
    /// </summary>
    public class Group : IEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        [Key]
        public int ID { get; set; }

        /// <summary>
        /// Number of group
        /// </summary>
        public string NumberOfGroup { get; set; }
    }
}
