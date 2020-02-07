namespace SaveToXLSXManager.Model
{
    /// <summary>
    /// Implementation of table column.
    /// </summary>
    public class AverageScoreForEachSpecialtyReportRow
    {
        /// <summary>
        /// Session number column.
        /// </summary>
        public int SessionNumber { get; set; }

        /// <summary>
        /// Specialties name column.
        /// </summary>
        public string SpecialtiesName { get; set; }

        /// <summary>
        /// Average exam value column.
        /// </summary>
        public double? AverageExamValue { get; set; }
    }
}
