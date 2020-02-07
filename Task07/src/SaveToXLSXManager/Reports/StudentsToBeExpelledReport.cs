using DBModelsLinqToSql.Models;
using SaveToXLSXManager.Reports;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SaveToXLSXManager
{
    /// <summary>
    /// Implementation of report base class students to be expelled report.
    /// </summary>
    public class StudentsToBeExpelledReport : Report
    {
        /// <summary>
        /// Minimum assessment threshold field.
        /// </summary>
        private readonly int _minimumPassingScore;

        /// <summary>
        /// Constructor <see cref="StudentsToBeExpelledReport"/>
        /// </summary>
        /// <param name="minimumPassingScore">Minimum assessment threshold.</param>
        public StudentsToBeExpelledReport(int minimumPassingScore) : base()
        {
            _minimumPassingScore = minimumPassingScore;
        }

        /// <summary>
        /// Table data. Not implemented.
        /// </summary>
        /// <returns>Returns throw new NotImplementedException();.</returns>
        public override IEnumerable<IEnumerable<string>> GetData()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Generate ordered enumerable row. Not implemented.
        /// </summary>
        /// <returns>Returns throw new NotImplementedException();.</returns>
        public override IEnumerable<string> GetDataHeader()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get students to be expelled method.
        /// </summary>
        /// <returns>Returns grouped students.</returns>
        public IEnumerable<IGrouping<int, Students>> GetStudentsToBeExpelled()
        {
            IEnumerable<Students> expelledStudentsQuere =
                (from sessionsResults in _sessionsResults
                 join students in _students on sessionsResults.StudentsID equals students.ID
                 join examSchedules in _examSchedules on sessionsResults.ExamSchedulesID equals examSchedules.ID
                 join subjects in _subjects on examSchedules.SubjectsID equals subjects.ID
                 where sessionsResults.ExamValue <= _minimumPassingScore & subjects.IsAssessment == "True"
                 select students).Distinct();

            IEnumerable<IGrouping<int, Students>> expelledStudentsGroupedByGroup =
                (from ExpelledStudentsQuere in expelledStudentsQuere
                group ExpelledStudentsQuere by ExpelledStudentsQuere.GroupsID);

            if (expelledStudentsGroupedByGroup == null)
                throw new NullReferenceException("Data not found.");

            return expelledStudentsGroupedByGroup;
        }
    }
}
