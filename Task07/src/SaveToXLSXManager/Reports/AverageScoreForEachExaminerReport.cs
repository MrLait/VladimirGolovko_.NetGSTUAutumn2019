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
    public class AverageScoreForEachExaminerReport : IReport
    {
        public DAOFactory DAOFactory { get; private set; }
        public IEnumerable<ExamSchedules> ExamSchedules { get; private set; }
        public IEnumerable<Groups> Groups { get; private set; }
        public IEnumerable<Sessions> Sessions { get; private set; }
        public IEnumerable<SessionsResults> SessionsResults { get; private set; }
        public IEnumerable<Subjects> Subjects { get; private set; }
        public IEnumerable<Specialties> Specialties { get; private set; }
        public IEnumerable<Students> Students { get; private set; }
        public IEnumerable<Examiners> Examiners { get; private set; }

        public int SessionNumber { get; private set; }
        public Func<AverageScoreForEachExaminerReportRow, object> OrderByFunc { get; private set; }
        public bool Descending { get; private set; }
        public List<List<string>> GetDataRows {get; private set; }

    public AverageScoreForEachExaminerReport(DAOFactory dAOFactory, int sessionNumber, Func<AverageScoreForEachExaminerReportRow, object> orderByFunc, bool descending)
        {
            DAOFactory = dAOFactory;
            ExamSchedules = DAOFactory.CreateExamSchedulesRepository().GetAll();
            Groups = DAOFactory.CreateGroupsRepository().GetAll();
            Sessions = DAOFactory.CreateSessionsRepository().GetAll();
            SessionsResults = DAOFactory.CreateSessionsResultsRepository().GetAll();
            Subjects = DAOFactory.CreateSubjectsRepository().GetAll();
            Specialties = DAOFactory.CreateSpecialtiesRepository().GetAll();
            Students = DAOFactory.CreateStudentsRepository().GetAll();
            Examiners = dAOFactory.CreateExaminersRepository().GetAll();

            SessionNumber = sessionNumber;
            OrderByFunc = orderByFunc;
            Descending = descending;
            GetDataRows = new List<List<string>>();

        }

        public IEnumerable<string> GetDataHeader()
        {
            return new List<string>
            {
                "SessionNumber", "Surname", "FirstName", "MiddleName", "AverageExamValue"
            };
        }
        public IEnumerable<IEnumerable<string>> GetData()
        {
            GetDataRows.Clear();
            foreach (AverageScoreForEachExaminerReportRow item in GenerateRow().ToList())
            {
                GetDataRows.Add(new List<string>
                {
                    item.SessionNumber.ToString(),
                    item.Surname,
                    item.FirstName,
                    item.MiddleName,
                    item.AverageExamValue.ToString()
                });
            }
            return GetDataRows;
        }

        private IOrderedEnumerable<AverageScoreForEachExaminerReportRow> GenerateRow()
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
                    ExaminersID = subjects.ExaminersID,
                    Subjects = subjects.SubjectName,
                    Specialties = specialties.Specialtie,
                    SpecialtiesID = specialties.ID,
                    ExamValue = sessionsResults.ExamValue
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
                join examiners in Examiners on GroupExaminersIdAverageExaminersExamValueResultsQuere.ExaminersID equals examiners.ID
                select new AverageScoreForEachExaminerReportRow
                {
                    SessionNumber = SessionNumber,
                    Surname = examiners.Surname,
                    FirstName = examiners.FirstName,
                    MiddleName = examiners.MiddleName,
                    AverageExamValue = GroupExaminersIdAverageExaminersExamValueResultsQuere.AverageExamValue
                };

            if (averageScoreForEachSpecialtyReportRowQuere == null)
                throw new NullReferenceException("Data not found.");

            IOrderedEnumerable<AverageScoreForEachExaminerReportRow> orderedGroupSessionBothTypeResult;

            if (Descending)
                orderedGroupSessionBothTypeResult = averageScoreForEachSpecialtyReportRowQuere.OrderByDescending(OrderByFunc);
            else
                orderedGroupSessionBothTypeResult = averageScoreForEachSpecialtyReportRowQuere.OrderBy(OrderByFunc);

            return orderedGroupSessionBothTypeResult;
        }
    }
}
