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
    public class AverageScoreForEachSpecialtyReport : IReport
    {
        public DAOFactory DAOFactory { get; private set; }
        public IEnumerable<ExamSchedules> ExamSchedules { get; private set; }
        public IEnumerable<Groups> Groups { get; private set; }
        public IEnumerable<Sessions> Sessions { get; private set; }
        public IEnumerable<SessionsResults> SessionsResults { get; private set; }
        public IEnumerable<Subjects> Subjects { get; private set; }
        public IEnumerable<Specialties> Specialties { get; private set; }
        public IEnumerable<Students> Students { get; private set; }

        public int SessionNumber { get; private set; }
        public Func<AverageScoreForEachSpecialtyReportRow, object> OrderByFunc { get; private set; }
        public bool Descending { get; private set; }
        public List<List<string>> GetDataRows {get; private set; }

    public AverageScoreForEachSpecialtyReport(DAOFactory dAOFactory, int sessionNumber, Func<AverageScoreForEachSpecialtyReportRow, object> orderByFunc, bool descending)
        {
            DAOFactory = dAOFactory;
            ExamSchedules = DAOFactory.CreateExamSchedulesRepository().GetAll();
            Groups = DAOFactory.CreateGroupsRepository().GetAll();
            Sessions = DAOFactory.CreateSessionsRepository().GetAll();
            SessionsResults = DAOFactory.CreateSessionsResultsRepository().GetAll();
            Subjects = DAOFactory.CreateSubjectsRepository().GetAll();
            Specialties = DAOFactory.CreateSpecialtiesRepository().GetAll();
            Students = DAOFactory.CreateStudentsRepository().GetAll();

            SessionNumber = sessionNumber;
            OrderByFunc = orderByFunc;
            Descending = descending;
            GetDataRows = new List<List<string>>();

        }

        public IEnumerable<string> GetDataHeader()
        {
            return new List<string>
            {
                "SessionNumber", "SpecialtiesName", "AverageExamValue"
            };
        }

        public IEnumerable<IEnumerable<string>> GetData()
        {
            GetDataRows.Clear();
            foreach (AverageScoreForEachSpecialtyReportRow item in GenerateRow().ToList())
            {
                GetDataRows.Add(new List<string>
                {
                    item.SessionNumber.ToString(),
                    item.SpecialtiesName,
                    item.AverageExamValue.ToString()
                });
            }
            return GetDataRows;
        }

        private IOrderedEnumerable<AverageScoreForEachSpecialtyReportRow> GenerateRow()
        {
            Sessions requiredSessionsReport = Sessions.FirstOrDefault(x => x.Session == SessionNumber);

            if (requiredSessionsReport == null)
                throw new NullReferenceException("Check SessionNumber");

            var examValuesBySessionNumberQuere =
                from sessionsResults in SessionsResults
                join examSchedules in ExamSchedules on sessionsResults.ExamSchedulesID equals examSchedules.ID
                join groups in Groups on examSchedules.GroupsID equals groups.ID
                join specialties in Specialties on groups.SpecialtiesID equals specialties.ID
                join subjects in Subjects on examSchedules.SubjectsID equals subjects.ID
                join sessions in Sessions on examSchedules.SessionsID equals sessions.ID
                join students in Students on sessionsResults.StudentsID equals students.ID
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
                join specialties in Specialties on GroupSpecialtiesIdAverageSpecialitesExamValueResultsQuere.SpecialtiesID equals specialties.ID
                select new AverageScoreForEachSpecialtyReportRow
                {
                    SessionNumber = SessionNumber,
                    SpecialtiesName = specialties.Specialtie,
                    AverageExamValue = GroupSpecialtiesIdAverageSpecialitesExamValueResultsQuere.AverageExamValue
                };


            if (averageScoreForEachSpecialtyReportRowQuere == null)
                throw new NullReferenceException("Data not found.");


            IOrderedEnumerable<AverageScoreForEachSpecialtyReportRow> orderedGroupSessionBothTypeResult;

            if (Descending)
                orderedGroupSessionBothTypeResult = averageScoreForEachSpecialtyReportRowQuere.OrderByDescending(OrderByFunc);
            else
                orderedGroupSessionBothTypeResult = averageScoreForEachSpecialtyReportRowQuere.OrderBy(OrderByFunc);

            return orderedGroupSessionBothTypeResult;

        }
    }
}
