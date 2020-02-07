using DBModelsLinqToSql.Models;
using SaveToXLSXManager.Model;
using SaveToXLSXManager.Reports;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SaveToXLSXManager
{
    /// <summary>
    /// Implementation of report base class average score for each specialty.
    /// </summary>
    public class AverageScoreForEachSpecialtyReport : Report
    {
        /// <summary>
        /// Func for sorting column.
        /// </summary>
        private readonly Func<AverageScoreForEachSpecialtyReportRow, object> _orderByFunc;

        /// <summary>
        /// Constructor <see cref="AverageScoreForEachSpecialtyReport"/>
        /// </summary>
        /// <param name="sessionNumber">Session number.</param>
        /// <param name="orderByFunc">Func for sorting column.</param>
        /// <param name="descending">Sort by descening.</param>
        public AverageScoreForEachSpecialtyReport(int sessionNumber, Func<AverageScoreForEachSpecialtyReportRow, object> orderByFunc, bool descending)
            : base(sessionNumber, descending)
        {
            _orderByFunc = orderByFunc;
        }

        /// <summary>
        /// Table header.
        /// </summary>
        /// <returns>Returns header.</returns>
        public override IEnumerable<string> GetDataHeader()
        {
            return new List<string>
            {
                "SessionNumber", "SpecialtiesName", "AverageExamValue"
            };
        }


        /// <summary>
        /// Table data.
        /// </summary>
        /// <returns>Returns data list.</returns>
        public override IEnumerable<IEnumerable<string>> GetData()
        {
            _getDataRows.Clear();
            foreach (AverageScoreForEachSpecialtyReportRow item in GenerateRow().ToList())
            {
                _getDataRows.Add(new List<string>
                {
                    item.SessionNumber.ToString(),
                    item.SpecialtiesName,
                    item.AverageExamValue.ToString()
                });
            }
            return _getDataRows;
        }

        /// <summary>
        /// Generate ordered enumerable row.
        /// </summary>
        /// <returns>Returns ordered enumerable row.</returns>
        private IOrderedEnumerable<AverageScoreForEachSpecialtyReportRow> GenerateRow()
        {
            Sessions requiredSessionsReport = _sessions.FirstOrDefault(x => x.Session == _sessionNumber);

            if (requiredSessionsReport == null)
                throw new NullReferenceException("Check SessionNumber");

            var examValuesBySessionNumberQuere =
                from sessionsResults in _sessionsResults
                join examSchedules in _examSchedules on sessionsResults.ExamSchedulesID equals examSchedules.ID
                join groups in _groups on examSchedules.GroupsID equals groups.ID
                join specialties in _specialties on groups.SpecialtiesID equals specialties.ID
                join subjects in _subjects on examSchedules.SubjectsID equals subjects.ID
                join sessions in _sessions on examSchedules.SessionsID equals sessions.ID
                join students in _students on sessionsResults.StudentsID equals students.ID
                where requiredSessionsReport.ID == sessions.ID & subjects.IsAssessment == "True"
                select new
                {
                    StudentsID = students.ID,
                    SessionsID = sessions.ID,
                    Subjects = subjects.SubjectName,
                    Specialties = specialties.Specialtie,
                    SpecialtiesID = specialties.ID,
                    sessionsResults.ExamValue
                };

            var groupSpecialtiesIdAverageSpecialitesExamValueResultsQuere =
                from examValueQuere in examValuesBySessionNumberQuere
                group examValueQuere by examValueQuere.SpecialtiesID into examValueQuereGroup
                select new
                {
                    SpecialtiesID = examValueQuereGroup.Key,
                    AverageExamValue = examValueQuereGroup.Average(x => x.ExamValue)
                };

            IEnumerable<AverageScoreForEachSpecialtyReportRow> averageScoreForEachSpecialtyReportRowQuere =
                from GroupSpecialtiesIdAverageSpecialitesExamValueResultsQuere in groupSpecialtiesIdAverageSpecialitesExamValueResultsQuere
                join specialties in _specialties on GroupSpecialtiesIdAverageSpecialitesExamValueResultsQuere.SpecialtiesID equals specialties.ID
                select new AverageScoreForEachSpecialtyReportRow
                {
                    SessionNumber = _sessionNumber,
                    SpecialtiesName = specialties.Specialtie,
                    AverageExamValue = GroupSpecialtiesIdAverageSpecialitesExamValueResultsQuere.AverageExamValue
                };

            if (averageScoreForEachSpecialtyReportRowQuere == null)
                throw new NullReferenceException("Data not found.");

            IOrderedEnumerable<AverageScoreForEachSpecialtyReportRow> orderedGroupSessionBothTypeResult;

            if (_descending)
                orderedGroupSessionBothTypeResult = averageScoreForEachSpecialtyReportRowQuere.OrderByDescending(_orderByFunc);
            else
                orderedGroupSessionBothTypeResult = averageScoreForEachSpecialtyReportRowQuere.OrderBy(_orderByFunc);

            return orderedGroupSessionBothTypeResult;
        }
    }
}
