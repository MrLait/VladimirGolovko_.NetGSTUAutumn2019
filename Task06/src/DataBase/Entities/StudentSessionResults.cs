using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Entities
{
    public class StudentSessionResults
    {
        public int StudentSessionResultsID { get; set; }
        public int StudentID { get; set; }
        public int SessionScheduleID { get; set; }
        public int ExamResult { get; set; }
        public string OffsettResult { get; set; }
    }
}
