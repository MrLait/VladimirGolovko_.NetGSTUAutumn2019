namespace SaveToXLSXManager.Model
{
    /// <summary>
    /// Implementation of table columns.
    /// </summary>
    public class PivotResultsRow
    {
        /// <summary>
        /// Number of session column.
        /// </summary>
        public int NumberOfSession { get; set; }

        /// <summary>
        /// Max exam value column.
        /// </summary>
        public int? MaxExamValue { get; set; }

        /// <summary>
        /// Min exam value column.
        /// </summary>
        public int? MinExamValue { get; set; }

        /// <summary>
        /// Average exam value column.
        /// </summary>
        public double? AverageExamValue { get; set; }
    }
}
