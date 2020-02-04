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
    public class StudentsToBeExpelledReport
    {
        public DAOFactory DAOFactory { get; private set; }
        public IEnumerable<ExamSchedules> ExamSchedules { get; private set; }
        public IEnumerable<Groups> Groups { get; private set; }
        public IEnumerable<SessionsResults> SessionsResults { get; private set; }
        public IEnumerable<Students> Students { get; private set; }
        public IEnumerable<Subjects> Subjects { get; private set; }

        public StudentsToBeExpelledReport(DAOFactory dAOFactory)
        {
            DAOFactory = dAOFactory;
            ExamSchedules = DAOFactory.CreateExamSchedulesRepository().GetAll();
            Groups = DAOFactory.CreateGroupsRepository().GetAll();
            SessionsResults = DAOFactory.CreateSessionsResultsRepository().GetAll();
            Students = DAOFactory.CreateStudentsRepository().GetAll();
            Subjects = DAOFactory.CreateSubjectsRepository().GetAll();
        }

        public IEnumerable<IGrouping<int, Students>> GetStudentsToBeExpelled(int minimumPassingScore)
        {
            IEnumerable<Students> expelledStudentsQuere =
                (from sessionsResults in SessionsResults
                 join students in Students on sessionsResults.StudentsID equals students.ID
                 join examSchedules in ExamSchedules on sessionsResults.ExamSchedulesID equals examSchedules.ID
                 join subjects in Subjects on examSchedules.SubjectsID equals subjects.ID
                 where sessionsResults.ExamValue <= minimumPassingScore & subjects.IsAssessment == "True"
                 select students).Distinct();

            IEnumerable<IGrouping<int, Students>> expelledStudentsGroupedByGroup =
                from ExpelledStudentsQuere in expelledStudentsQuere
                group ExpelledStudentsQuere by ExpelledStudentsQuere.GroupsID;

            if (expelledStudentsGroupedByGroup == null)
                throw new NullReferenceException("Data not found.");

            return expelledStudentsGroupedByGroup;
        }
    }
}
