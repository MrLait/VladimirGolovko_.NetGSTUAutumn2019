using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveToXLSXManager.Model
{
    public class SessionTableExamResult: SessionTableResult
    {
        public DateTime ExamDate { get; set; }
        public int ExamValue { get; set; }
    }
}
