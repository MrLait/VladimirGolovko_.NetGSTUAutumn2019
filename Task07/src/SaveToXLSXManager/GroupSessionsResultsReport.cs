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
        public DAOFactory DAOFactory;
        public IEnumerable<Examiners> Examiners;
        public IEnumerable<ExamSchedules> ExamSchedules;
        public IEnumerable<Groups> Groups;
        public IEnumerable<Sessions> Sessions;
        public IEnumerable<SessionsResults> SessionsResults;
        public IEnumerable<Specialties> Specialties;
        public IEnumerable<Students> Students;
        public IEnumerable<Subjects> Subjects;

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

        public IEnumerable<string> GetData()
        {
            throw new NotImplementedException();
        }



        public GroupSessionsResultsReport(DAOFactory dAOFactory)
        {
            DAOFactory = dAOFactory;
            Examiners = DAOFactory.CreateExaminersRepository().GetAll();
            ExamSchedules = DAOFactory.CreateExamSchedulesRepository().GetAll();
            Groups = DAOFactory.CreateGroupsRepository().GetAll();
            Sessions = DAOFactory.CreateSessionsRepository().GetAll();
            SessionsResults = DAOFactory.CreateSessionsResultsRepository().GetAll();
            Specialties = DAOFactory.CreateSpecialtiesRepository().GetAll();
            Students = DAOFactory.CreateStudentsRepository().GetAll();
            Subjects = DAOFactory.CreateSubjectsRepository().GetAll();
        }


        public IOrderedEnumerable<GroupSessionsResultsRow> GenerateRow(string groupName, int sessionNumber, Func<GroupSessionsResultsRow, object> orderByFunc, bool descending)
        {
            Groups requiredGroupReport = Groups.FirstOrDefault(x => x.GroupName == groupName);
            Sessions requiredSessionReport = Sessions.FirstOrDefault(x => x.Session == sessionNumber);

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
                    NumberOfGroup = requiredGroupReport.GroupName,
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
                    NumberOfGroup = requiredGroupReport.GroupName,
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
                    ID = GroupSessionExamResult.ID,
                    NumberOfGroup = GroupSessionExamResult.NumberOfGroup,
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

            if (descending)
                orderedGroupSessionBothTypeResult = groupSessionbothTypeResult.OrderByDescending(orderByFunc);
            else
                orderedGroupSessionBothTypeResult = groupSessionbothTypeResult.OrderBy(orderByFunc);

            return orderedGroupSessionBothTypeResult;

        }
    }
}
