using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Entities
{
    public class SessionSchedule
    {
        public int SessionScheduleID { get; set; }
        public int StudentGroup { get; set; }
        public DateTime ExamDate { get; set; }
        public DateTime OffsetDate { get; set; }
        public int NumberOfSession { get; set; }
        public string Subject { get; set; }
    }
}
