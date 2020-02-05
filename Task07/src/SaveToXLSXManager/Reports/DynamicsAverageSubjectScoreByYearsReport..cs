using DAO.Factories;
using SaveToXLSXManager.Model;
using SaveToXLSXManager.Reports;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SaveToXLSXManager
{
    public class DynamicsAverageSubjectScoreByYearsReport : Report
    {
        private Func<DynamicsAverageSubjectScoreByYearsReportRow, object> _orderByFunc;

        public DynamicsAverageSubjectScoreByYearsReport(LinqToSqlSingelton linqToSqlSingelton, Func<DynamicsAverageSubjectScoreByYearsReportRow, object> orderByFunc, bool descending)
            : base(linqToSqlSingelton, descending)
        {
            _orderByFunc = orderByFunc;
        }

        public override IEnumerable<string> GetDataHeader()
        {
            return new List<string>
            {
                "ExamDataYear", "Subject", "AverageExamValue"
            };
        }

        public override IEnumerable<IEnumerable<string>> GetData()
        {
            _getDataRows.Clear();
            foreach (DynamicsAverageSubjectScoreByYearsReportRow item in GenerateRow().ToList())
            {
                _getDataRows.Add(new List<string>
                {
                    item.ExamDataYear.ToString(),
                    item.Subject,
                    string.Format("{0:N2}", item.AverageExamValue)
                });
            }
            return _getDataRows;
        }

        private IOrderedEnumerable<DynamicsAverageSubjectScoreByYearsReportRow> GenerateRow()
        {

            var examValuesQuere =
                from sessionsResults in _sessionsResults
                join examSchedules in _examSchedules on sessionsResults.ExamSchedulesID equals examSchedules.ID
                join groups in _groups on examSchedules.GroupsID equals groups.ID
                join specialties in _specialties on groups.SpecialtiesID equals specialties.ID
                join subjects in _subjects on examSchedules.SubjectsID equals subjects.ID
                where  subjects.IsAssessment == "True"
                select new
                {
                    SubjectsID = subjects.ID,
                    ExamDataYear = examSchedules.ExamDate.Year,
                    ExamValue = sessionsResults.ExamValue
                };

            var averageExamValuesByYearBySubjectQuere = examValuesQuere
                .GroupBy(x => new { x.ExamDataYear, x.SubjectsID })
                .Select(y => new 
                {
                    ExamDataYear = y.Key.ExamDataYear,
                    SubjectsID = y.Key.SubjectsID,
                    AverageExamValue = y.Average(z => z.ExamValue)
                });

            IEnumerable<DynamicsAverageSubjectScoreByYearsReportRow> dynamicsAverageSubjectScoreByYearsReportRowQuere =
                from AverageExamValuesByYearBySubjectQuere in averageExamValuesByYearBySubjectQuere
                join subjects in _subjects on AverageExamValuesByYearBySubjectQuere.SubjectsID equals subjects.ID
                select new DynamicsAverageSubjectScoreByYearsReportRow
                {
                    ExamDataYear = AverageExamValuesByYearBySubjectQuere.ExamDataYear,
                    Subject = subjects.SubjectName,
                    AverageExamValue = AverageExamValuesByYearBySubjectQuere.AverageExamValue
                };

            IOrderedEnumerable<DynamicsAverageSubjectScoreByYearsReportRow> orderedGroupSessionBothTypeResult;

            if (_descending)
                orderedGroupSessionBothTypeResult = dynamicsAverageSubjectScoreByYearsReportRowQuere.OrderByDescending(_orderByFunc);
            else
                orderedGroupSessionBothTypeResult = dynamicsAverageSubjectScoreByYearsReportRowQuere.OrderBy(_orderByFunc);

            return orderedGroupSessionBothTypeResult;
        }
    }
}
