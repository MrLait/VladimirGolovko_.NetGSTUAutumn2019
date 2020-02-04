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
    public class DynamicsAverageSubjectScoreByYearsReport : IReport
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

        public Func<DynamicsAverageSubjectScoreByYearsReportRow, object> OrderByFunc { get; private set; }
        public bool Descending { get; private set; }
        public List<List<string>> GetDataRows {get; private set; }

    public DynamicsAverageSubjectScoreByYearsReport(DAOFactory dAOFactory, Func<DynamicsAverageSubjectScoreByYearsReportRow, object> orderByFunc, bool descending)
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

            OrderByFunc = orderByFunc;
            Descending = descending;
            GetDataRows = new List<List<string>>();

        }

        public IEnumerable<string> GetDataHeader()
        {
            return new List<string>
            {
                "ExamDataYear", "Subject", "AverageExamValue"
            };
        }

        public IEnumerable<IEnumerable<string>> GetData()
        {
            GetDataRows.Clear();
            foreach (DynamicsAverageSubjectScoreByYearsReportRow item in GenerateRow().ToList())
            {
                GetDataRows.Add(new List<string>
                {
                    item.ExamDataYear.ToString(),
                    item.Subject,
                    string.Format("{0:N2}", item.AverageExamValue)
                });
            }
            return GetDataRows;
        }

        private IOrderedEnumerable<DynamicsAverageSubjectScoreByYearsReportRow> GenerateRow()
        {

            var examValuesQuere =
                from sessionsResults in SessionsResults
                join examSchedules in ExamSchedules on sessionsResults.ExamSchedulesID equals examSchedules.ID
                join groups in Groups on examSchedules.GroupsID equals groups.ID
                join specialties in Specialties on groups.SpecialtiesID equals specialties.ID
                join subjects in Subjects on examSchedules.SubjectsID equals subjects.ID
                join sessions in Sessions on examSchedules.SessionsID equals sessions.ID
                join students in Students on sessionsResults.StudentsID equals students.ID
                where  subjects.IsAssessment == "True"
                select new
                {
                    StudentsID = students.ID,
                    SessionsID = sessions.ID,
                    ExaminersID = subjects.ExaminersID,
                    SubjectsID = subjects.ID,
                    ExamDataYear = examSchedules.ExamDate.Year,
                    Specialties = specialties.Specialtie,
                    SpecialtiesID = specialties.ID,
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
                join subjects in Subjects on AverageExamValuesByYearBySubjectQuere.SubjectsID equals subjects.ID
                select new DynamicsAverageSubjectScoreByYearsReportRow
                {
                    ExamDataYear = AverageExamValuesByYearBySubjectQuere.ExamDataYear,
                    Subject = subjects.SubjectName,
                    AverageExamValue = AverageExamValuesByYearBySubjectQuere.AverageExamValue
                };


            if (dynamicsAverageSubjectScoreByYearsReportRowQuere == null)
                throw new NullReferenceException("Data not found.");

            IOrderedEnumerable<DynamicsAverageSubjectScoreByYearsReportRow> orderedGroupSessionBothTypeResult;

            if (Descending)
                orderedGroupSessionBothTypeResult = dynamicsAverageSubjectScoreByYearsReportRowQuere.OrderByDescending(OrderByFunc);
            else
                orderedGroupSessionBothTypeResult = dynamicsAverageSubjectScoreByYearsReportRowQuere.OrderBy(OrderByFunc);

            return orderedGroupSessionBothTypeResult;
        }
    }
}
