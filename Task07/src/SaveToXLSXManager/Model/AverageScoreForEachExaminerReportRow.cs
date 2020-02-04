using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveToXLSXManager.Model
{
    public class AverageScoreForEachExaminerReportRow
    {
        public int SessionNumber { get; set; }
        public string Surname { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public double? AverageExamValue { get; set; }
    }
}
