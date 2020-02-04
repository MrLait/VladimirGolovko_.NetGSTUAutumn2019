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
    public class GroupSessionsResultsReport : IReport
    {
        public DAOFactory DAOFactory { get; private set; }
        public IEnumerable<ExamSchedules> ExamSchedules { get; private set; }
        public IEnumerable<Groups> Groups { get; private set; }
        public IEnumerable<Sessions> Sessions { get; private set; }
        public IEnumerable<SessionsResults> SessionsResults { get; private set; }
        public IEnumerable<Students> Students { get; private set; }
        public IEnumerable<Subjects> Subjects { get; private set; }

        public string GroupName { get; private set; }
        public int SessionNumber { get; private set; }
        public Func<GroupSessionsResultsRow, object> OrderByFunc { get; private set; }
        public bool Descending { get; private set; }
        public List<List<string>> GetDataRows {get; private set; }

    public GroupSessionsResultsReport(DAOFactory dAOFactory, string groupName, int sessionNumber, Func<GroupSessionsResultsRow, object> orderByFunc, bool descending)
        {
            DAOFactory = dAOFactory;
            ExamSchedules = DAOFactory.CreateExamSchedulesRepository().GetAll();
            Groups = DAOFactory.CreateGroupsRepository().GetAll();
            Sessions = DAOFactory.CreateSessionsRepository().GetAll();
            SessionsResults = DAOFactory.CreateSessionsResultsRepository().GetAll();
            Students = DAOFactory.CreateStudentsRepository().GetAll();
            Subjects = DAOFactory.CreateSubjectsRepository().GetAll();

            GroupName = groupName;
            SessionNumber = sessionNumber;
            OrderByFunc = orderByFunc;
            Descending = descending;
            GetDataRows = new List<List<string>>();
        }

        public IEnumerable<string> GetDataHeader()
        {
            return new List<string>
            {
                "ID", "NumberOfGroup", "NumberOfSession", "Surname",
                "FirstName", "MiddleName", "Gender", "DateOfBirth",
                "Subject", "ExamDate", "ExamValue", "SetOffDate",
                "SetOffValue"
            };
        }

        public IEnumerable<IEnumerable<string>> GetData()
        {

            GetDataRows.Clear();
            foreach (GroupSessionsResultsRow item in GenerateRow().ToList())
            {
                GetDataRows.Add(new List<string>
                {
                    item.StudentID.ToString(),
                    item.GroupName,
                    item.NumberOfSession.ToString(),
                    item.Surname,
                    item.FirstName,
                    item.MiddleName,
                    item.Gender,
                    item.DateOfBirth.ToString(),
                    item.Subject,
                    item.ExamDate.ToString(),
                    item.ExamValue.ToString(),
                    item.SetOffDate.ToString(),
                    item.SetOffValue.ToString()
                });
            }
            return GetDataRows;
        }

        private IOrderedEnumerable<GroupSessionsResultsRow> GenerateRow()
        {
            Groups requiredGroupReport = Groups.FirstOrDefault(x => x.GroupName == GroupName);
            Sessions requiredSessionReport = Sessions.FirstOrDefault(x => x.Session == SessionNumber);

            if (requiredGroupReport == null)
                throw new NullReferenceException("Check groupName");
            if (requiredSessionReport == null)
                throw new NullReferenceException("Check sessionNumber");

            var groupSessionExamResult =
                from students in Students
                join sessionsResults in SessionsResults on students.ID equals sessionsResults.StudentsID
                join examSchedules in ExamSchedules on sessionsResults.ExamSchedulesID equals examSchedules.ID
                join subjects in Subjects on examSchedules.SubjectsID equals subjects.ID
                where students.GroupsID == requiredGroupReport.ID & subjects.IsAssessment == "True" &
                examSchedules.SessionsID == requiredSessionReport.ID
                select new
                {
                    ID = students.ID,
                    GroupName = requiredGroupReport.GroupName,
                    NumberOfSession = requiredSessionReport.Session,
                    Surname = students.Surname,
                    FirstName = students.FirstName,
                    MiddleName = students.MiddleName,
                    Gender = students.Gender,
                    DateOfBirth = students.DateOfBirth,
                    Subject = subjects.SubjectName,
                    ExamDate = examSchedules.ExamDate,
                    ExamValue = sessionsResults.ExamValue
                };

            var groupSessionSetOffResult =
                from students in Students
                join sessionsResults in SessionsResults on students.ID equals sessionsResults.StudentsID
                join examSchedules in ExamSchedules on sessionsResults.ExamSchedulesID equals examSchedules.ID
                join subjects in Subjects on examSchedules.SubjectsID equals subjects.ID
                where students.GroupsID == requiredGroupReport.ID & subjects.IsAssessment == "False" &
                examSchedules.SessionsID == requiredSessionReport.ID
                select new
                {
                    ID = students.ID,
                    GroupName = requiredGroupReport.GroupName,
                    NumberOfSession = requiredSessionReport.Session,
                    Surname = students.Surname,
                    FirstName = students.FirstName,
                    MiddleName = students.MiddleName,
                    Gender = students.Gender,
                    DateOfBirth = students.DateOfBirth,
                    Subject = subjects.SubjectName,
                    ExamDate = examSchedules.ExamDate,
                    SetOffValue = sessionsResults.SetOffValue
                };

            IEnumerable<GroupSessionsResultsRow> groupSessionbothTypeResult = 
                from GroupSessionExamResult in groupSessionExamResult
                join GroupSessionSetOffResult in groupSessionSetOffResult on GroupSessionExamResult.ID equals GroupSessionSetOffResult.ID
                where GroupSessionSetOffResult.Subject == GroupSessionExamResult.Subject
                select new GroupSessionsResultsRow
                {
                    StudentID = GroupSessionExamResult.ID,
                    GroupName = GroupSessionExamResult.GroupName,
                    NumberOfSession = GroupSessionExamResult.NumberOfSession,
                    Surname = GroupSessionExamResult.Surname,
                    FirstName = GroupSessionExamResult.FirstName,
                    MiddleName = GroupSessionExamResult.MiddleName,
                    Gender = GroupSessionExamResult.Gender,
                    DateOfBirth = GroupSessionExamResult.DateOfBirth,
                    Subject = GroupSessionExamResult.Subject,
                    ExamDate = GroupSessionExamResult.ExamDate,
                    ExamValue = GroupSessionExamResult.ExamValue,
                    SetOffDate = GroupSessionSetOffResult.ExamDate,
                    SetOffValue = GroupSessionSetOffResult.SetOffValue
                };

            if (groupSessionbothTypeResult == null)
                throw new NullReferenceException("Data not found.");


            IOrderedEnumerable<GroupSessionsResultsRow> orderedGroupSessionBothTypeResult;

            if (Descending)
                orderedGroupSessionBothTypeResult = groupSessionbothTypeResult.OrderByDescending(OrderByFunc);
            else
                orderedGroupSessionBothTypeResult = groupSessionbothTypeResult.OrderBy(OrderByFunc);

            return orderedGroupSessionBothTypeResult;

        }
    }
}
