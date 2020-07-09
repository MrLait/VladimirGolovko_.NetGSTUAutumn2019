using DBModelsLinqToSql.Models;
using SaveToXLSXManager.Model;
using SaveToXLSXManager.Reports;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SaveToXLSXManager
{
    /// <summary>
    /// Implementation of report base class pivot results report.
    /// </summary>
    public class PivotResultsReport : Report
    {
        /// <summary>
        /// Func for sorting column.
        /// </summary>
        private readonly Func<PivotResultsRow, object> _orderByFunc;

        /// <summary>
        /// Constructor <see cref="PivotResultsReport"/>
        /// </summary>
        /// <param name="groupName">Group name.</param>
        /// <param name="orderByFunc">Func for sorting column.</param>
        /// <param name="descending">Sort by descening.</param>
        public PivotResultsReport(string groupName, Func<PivotResultsRow, object> orderByFunc, bool descending)
        :base(groupName, descending)
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
                "NumberOfSession", "MaxExamValue", "MinExamValue", "AverageExamValue"
            };
        }

        /// <summary>
        /// Table data.
        /// </summary>
        /// <returns>Returns data list.</returns>
        public override IEnumerable<IEnumerable<string>> GetData()
        {
            _getDataRows.Clear();
            foreach (PivotResultsRow item in GenerateRow().ToList())
            {
                _getDataRows.Add(new List<string>
                {
                    item.NumberOfSession.ToString(),
                    item.MaxExamValue.ToString(),
                    item.MinExamValue.ToString(),
                    item.AverageExamValue.ToString()
                });
            }
            return _getDataRows;
        }

        /// <summary>
        /// Generate ordered enumerable row.
        /// </summary>
        /// <returns>Returns ordered enumerable row.</returns>
        private IOrderedEnumerable<PivotResultsRow> GenerateRow()
        {
            Groups requiredGroupReport = _groups.FirstOrDefault(x => x.GroupName == _groupName);

            if (requiredGroupReport == null)
                throw new NullReferenceException("Check groupName");

            var examValuesQuere =
                from sessionsResults in _sessionsResults
                join examSchedules in _examSchedules on sessionsResults.ExamSchedulesID equals examSchedules.ID
                join sessions in _sessions on examSchedules.SessionsID equals sessions.ID
                join groups in _groups on examSchedules.GroupsID equals groups.ID
                join subjects in _subjects on examSchedules.SubjectsID equals subjects.ID
                where requiredGroupReport.ID == groups.ID & subjects.IsAssessment == "True"
                select new
                {
                    groups.GroupName,
                    NumberOfSession = sessions.ID,
                    sessionsResults.ExamValue
                };

            IEnumerable<PivotResultsRow> groupPivotResultsQuere =
                from examValueQuere in examValuesQuere
                group examValueQuere by examValueQuere.NumberOfSession into examValueQuereGroup
                select new PivotResultsRow
                {
                    NumberOfSession = examValueQuereGroup.Key,
                    MaxExamValue = examValueQuereGroup.Max(x => x.ExamValue),
                    MinExamValue = examValueQuereGroup.Min(x => x.ExamValue),
                    AverageExamValue = examValueQuereGroup.Average(x => x.ExamValue)
                };

            if (groupPivotResultsQuere == null)
                throw new NullReferenceException("Data not found.");

            IOrderedEnumerable<PivotResultsRow> orderedGroupSessionBothTypeResult;

            if (_descending)
                orderedGroupSessionBothTypeResult = groupPivotResultsQuere.OrderByDescending(_orderByFunc);
            else
                orderedGroupSessionBothTypeResult = groupPivotResultsQuere.OrderBy(_orderByFunc);

            return orderedGroupSessionBothTypeResult;
        }
    }
}
