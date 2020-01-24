using System.ComponentModel.DataAnnotations;

namespace DatabaseModels.Interfaces
{
    public interface IEntity
    {
        [Key]
        int ID { get; set; }
    }
}