using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveToXLSXManager.Model
{
    public class PivotResultsRow
    {
        public int NumberOfSession { get; set; }
        public int? MaxExamValue { get; set; }
        public int? MinExamValue { get; set; }
        public double? AverageExamValue { get; set; }
    }
}
