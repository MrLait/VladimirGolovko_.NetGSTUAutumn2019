using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveToXLSXManager.Model
{
    /// <summary>
    /// Implementation of table column.
    /// </summary>
    public class AverageScoreForEachExaminerReportRow
    {
        /// <summary>
        /// Session number column.
        /// </summary>
        public int SessionNumber { get; set; }

        /// <summary>
        /// Surname column.
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// First name  column.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Middle name column.
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Average exam value column.
        /// </summary>
        public double? AverageExamValue { get; set; }
    }
}
