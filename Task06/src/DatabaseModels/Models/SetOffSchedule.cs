using System;
using DatabaseModels.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseModels.Models
{
    [Table("SetOffSchedule")]
    public class SetOffSchedule : IEntity
    {
        [Key]
        public int ID { get; set; }

        public int NumberOfSession { get; set; }

        [ForeignKey("GroupID")]
        public int GroupID { get; set; }
        
        public string Subject { get; set; }
        public DateTime SetOffDate { get; set; }
    }
}