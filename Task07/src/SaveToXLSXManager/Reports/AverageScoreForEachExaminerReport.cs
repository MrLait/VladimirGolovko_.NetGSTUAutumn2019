using DBModelsLinqToSql.Models;
using SaveToXLSXManager.Model;
using SaveToXLSXManager.Reports;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SaveToXLSXManager
{
    /// <summary>
    /// Implementation of the report base class average score for each examiners.
    /// </summary>
    public class AverageScoreForEachExaminerReport : Report
    {
        /// <summary>
        /// Func for sorting column.
        /// </summary>
        private readonly Func<AverageScoreForEachExaminerReportRow, object> _orderByFunc;

        /// <summary>
        /// Constructor <see cref="AverageScoreForEachExaminerReport"/>
        /// </summary>
        /// <param name="sessionNumber">Session number.</param>
        /// <param name="orderByFunc">Func for sorting column.</param>
        /// <param name="descending">Sort by descening.</param>
        public AverageScoreForEachExaminerReport(int sessionNumber, Func<AverageScoreForEachExaminerReportRow, object> orderByFunc, bool descending)
            : base(sessionNumber , descending)
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
                "SessionNumber", "Surname", "FirstName", "MiddleName", "AverageExamValue"
            };
        }

        /// <summary>
        /// Table data.
        /// </summary>
        /// <returns>Returns data list.</returns>
        public override IEnumerable<IEnumerable<string>> GetData()
        {
            _getDataRows.Clear();
            foreach (AverageScoreForEachExaminerReportRow item in GenerateRow().ToList())
            {
                _getDataRows.Add(new List<string>
                {
                    item.SessionNumber.ToString(),
                    item.Surname,
                    item.FirstName,
                    item.MiddleName,
                    item.AverageExamValue.ToString()
                });
            }
            return _getDataRows;
        }

        /// <summary>
        /// Generate ordered enumerable row.
        /// </summary>
        /// <returns>Returns ordered enumerable row.</returns>
        private IOrderedEnumerable<AverageScoreForEachExaminerReportRow> GenerateRow()
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
                    subjects.ExaminersID,
                    Subjects = subjects.SubjectName,
                    Specialties = specialties.Specialtie,
                    SpecialtiesID = specialties.ID,
                    sessionsResults.ExamValue
                };

            var groupExaminersIdAverageExaminersExamValueResultsQuere =
                from examValueQuere in examValuesBySessionNumberQuere
                group examValueQuere by examValueQuere.ExaminersID into examValueQuereGroup
                select new
                {
                    ExaminersID = examValueQuereGroup.Key,
                    AverageExamValue = examValueQuereGroup.Average(x => x.ExamValue)
                };

            IEnumerable<AverageScoreForEachExaminerReportRow> averageScoreForEachSpecialtyReportRowQuere =
                from GroupExaminersIdAverageExaminersExamValueResultsQuere in groupExaminersIdAverageExaminersExamValueResultsQuere
                join examiners in _examiners on GroupExaminersIdAverageExaminersExamValueResultsQuere.ExaminersID equals examiners.ID
                select new AverageScoreForEachExaminerReportRow
                {
                    SessionNumber = _sessionNumber,
                    Surname = examiners.Surname,
                    FirstName = examiners.FirstName,
                    MiddleName = examiners.MiddleName,
                    AverageExamValue = GroupExaminersIdAverageExaminersExamValueResultsQuere.AverageExamValue
                };

            if (averageScoreForEachSpecialtyReportRowQuere == null)
                throw new NullReferenceException("Data not found.");

            IOrderedEnumerable<AverageScoreForEachExaminerReportRow> orderedGroupSessionBothTypeResult;

            if (_descending)
                orderedGroupSessionBothTypeResult = averageScoreForEachSpecialtyReportRowQuere.OrderByDescending(_orderByFunc);
            else
                orderedGroupSessionBothTypeResult = averageScoreForEachSpecialtyReportRowQuere.OrderBy(_orderByFunc);

            return orderedGroupSessionBothTypeResult;
        }
    }
}
