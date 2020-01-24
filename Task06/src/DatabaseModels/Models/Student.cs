using System;
using DatabaseModels.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseModels.Models
{
    [Table("Student")]
    public class Student : IEntity
    {
        [Key]
        public int ID { get; set; }

        public string Surname { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }

        [ForeignKey("GroupID")]
        public int GroupID { get; set; }
    }
}
