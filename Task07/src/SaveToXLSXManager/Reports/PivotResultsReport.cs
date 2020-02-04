using DAO.Factories;
using DAO.Interfaces;
using DBModelsLinqToSql.Models;
using SaveToXLSXManager.Interfaces;
using SaveToXLSXManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveToXLSXManager
{
    public class PivotResultsReport : IReport
    {
        public DAOFactory DAOFactory { get; private set; }
        public IEnumerable<ExamSchedules> ExamSchedules { get; private set; }
        public IEnumerable<Groups> Groups { get; private set; }
        public IEnumerable<Sessions> Sessions { get; private set; }
        public IEnumerable<SessionsResults> SessionsResults { get; private set; }
        public IEnumerable<Subjects> Subjects { get; private set; }

        public string GroupName { get; private set; }
        public int SessionNumber { get; private set; }
        public Func<PivotResultsRow, object> OrderByFunc { get; private set; }
        public bool Descending { get; private set; }
        public List<List<string>> GetDataRows {get; private set; }

    public PivotResultsReport(DAOFactory dAOFactory, string groupName, Func<PivotResultsRow, object> orderByFunc, bool descending)
        {
            DAOFactory = dAOFactory;
            ExamSchedules = DAOFactory.CreateExamSchedulesRepository().GetAll();
            Groups = DAOFactory.CreateGroupsRepository().GetAll();
            Sessions = DAOFactory.CreateSessionsRepository().GetAll();
            SessionsResults = DAOFactory.CreateSessionsResultsRepository().GetAll();
            Subjects = DAOFactory.CreateSubjectsRepository().GetAll();

            GroupName = groupName;
            OrderByFunc = orderByFunc;
            Descending = descending;
            GetDataRows = new List<List<string>>();
        }

        public IEnumerable<string> GetDataHeader()
        {
            return new List<string>
            {
                "NumberOfSession", "MaxExamValue", "MinExamValue", "AverageExamValue"
            };
        }

        public IEnumerable<IEnumerable<string>> GetData()
        {
            GetDataRows.Clear();
            foreach (PivotResultsRow item in GenerateRow().ToList())
            {
                GetDataRows.Add(new List<string>
                {
                    item.NumberOfSession.ToString(),
                    item.MaxExamValue.ToString(),
                    item.MinExamValue.ToString(),
                    item.AverageExamValue.ToString()
                });
            }
            return GetDataRows;
        }

        private IOrderedEnumerable<PivotResultsRow> GenerateRow()
        {
            Groups requiredGroupReport = Groups.FirstOrDefault(x => x.GroupName == GroupName);

            if (requiredGroupReport == null)
                throw new NullReferenceException("Check groupName");

            var examValuesQuere =
                from sessionsResults in SessionsResults
                join examSchedules in ExamSchedules on sessionsResults.ExamSchedulesID equals examSchedules.ID
                join sessions in Sessions on examSchedules.SessionsID equals sessions.ID
                join groups in Groups on examSchedules.GroupsID equals groups.ID
                join subjects in Subjects on examSchedules.SubjectsID equals subjects.ID
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

            if (Descending)
                orderedGroupSessionBothTypeResult = groupPivotResultsQuere.OrderByDescending(OrderByFunc);
            else
                orderedGroupSessionBothTypeResult = groupPivotResultsQuere.OrderBy(OrderByFunc);

            return orderedGroupSessionBothTypeResult;

        }
    }
}
