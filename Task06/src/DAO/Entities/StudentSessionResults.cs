using DAO.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAO.Entities
{
    [Table("StudentSessionResults")]
    public class StudentSessionResults
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("StudentID")]
        public int StudentID { get; set; }
        [ForeignKey("SessionScheduleID")]
        public int SessionScheduleID { get; set; }
        public int ExamResult { get; set; }
        public string OffsettResult { get; set; }
    }
}
