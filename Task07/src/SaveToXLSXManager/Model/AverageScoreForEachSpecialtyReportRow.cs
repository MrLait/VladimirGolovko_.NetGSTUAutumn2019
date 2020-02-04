using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveToXLSXManager.Model
{
    public class AverageScoreForEachSpecialtyReportRow
    {
        public int SessionNumber { get; set; }
        public string SpecialtiesName { get; set; }
        public double? AverageExamValue { get; set; }
    }
}
