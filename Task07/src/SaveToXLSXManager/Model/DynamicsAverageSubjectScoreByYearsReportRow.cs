namespace SaveToXLSXManager.Model
{
    /// <summary>
    /// Implementation of table column.
    /// </summary>
    public class DynamicsAverageSubjectScoreByYearsReportRow
    {
        /// <summary>
        /// Exam data year column.
        /// </summary>
        public int ExamDataYear { get; set; }

        /// <summary>
        /// Subject column.
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Average exam value column.
        /// </summary>
        public double? AverageExamValue { get; set; }
    }
}