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
    public class AverageScoreForEachSpecialtyReport : Report
    {
        private Func<AverageScoreForEachSpecialtyReportRow, object> _orderByFunc;

    public AverageScoreForEachSpecialtyReport(int sessionNumber, Func<AverageScoreForEachSpecialtyReportRow, object> orderByFunc, bool descending)
            : base(sessionNumber, descending)
        {
            _orderByFunc = orderByFunc;
        }

        public override IEnumerable<string> GetDataHeader()
        {
            return new List<string>
            {
                "SessionNumber", "SpecialtiesName", "AverageExamValue"
            };
        }

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
                    ExamValue = sessionsResults.ExamValue
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
