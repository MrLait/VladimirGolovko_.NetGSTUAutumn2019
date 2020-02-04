using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveToXLSXManager.Model
{
    public class DynamicsAverageSubjectScoreByYearsReportRow
    {
        public int ExamDataYear { get; set; }
        public string Subject { get; set; }
        public double? AverageExamValue { get; set; }
    }
}