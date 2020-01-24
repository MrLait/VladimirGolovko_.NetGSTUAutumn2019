using DatabaseModels.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace DatabaseModels.Models
{
    public class Group : IEntity
    {
        [Key]
        public int ID { get; set; }

        public string NumberOfGroup { get; set; }
    }
}
