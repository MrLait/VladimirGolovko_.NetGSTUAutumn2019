using System;
using DatabaseModels.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseModels.Models
{
    [Table("StudentSessionResults")]
    public class StudentSessionResults : IEntity
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("StudentID")]
        public int StudentID { get; set; }
        [ForeignKey("ExamScheduleID")]
        public int ExamScheduleID { get; set; }

        public int ExamValue { get; set; }
        public string SetOffValue { get; set; }
    }
}
