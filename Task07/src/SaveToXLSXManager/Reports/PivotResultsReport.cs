using DAO.Factories;
using DAO.Interfaces;
using DBModelsLinqToSql.Models;
using SaveToXLSXManager.Interfaces;
using SaveToXLSXManager.Model;
using SaveToXLSXManager.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveToXLSXManager
{
    public class PivotResultsReport : Report
    {
        private Func<PivotResultsRow, object> _orderByFunc;

    public PivotResultsReport(LinqToSqlSingelton linqToSqlSingelton, string groupName, Func<PivotResultsRow, object> orderByFunc, bool descending)
        :base(linqToSqlSingelton, groupName, descending)
        {
            _orderByFunc = orderByFunc;
        }

        public override IEnumerable<string> GetDataHeader()
        {
            return new List<string>
            {
                "NumberOfSession", "MaxExamValue", "MinExamValue", "AverageExamValue"
            };
        }

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
                    GroupName = groups.GroupName,
                    NumberOfSession = sessions.ID,
                    ExamValue = sessionsResults.ExamValue
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
