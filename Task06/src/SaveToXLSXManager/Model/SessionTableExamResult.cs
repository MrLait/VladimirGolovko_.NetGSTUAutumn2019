using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveToXLSXManager.Model
{
    /// <summary>
    /// Session table exam result
    /// </summary>
    public class SessionTableExamResult: SessionTableResult
    {
        /// <summary>
        /// ExamDate
        /// </summary>
        public DateTime ExamDate { get; set; }

        /// <summary>
        /// ExamValue
        /// </summary>
        public int ExamValue { get; set; }
    }
}
