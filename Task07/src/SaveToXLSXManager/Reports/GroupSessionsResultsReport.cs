using DBModelsLinqToSql.Models;
using SaveToXLSXManager.Model;
using SaveToXLSXManager.Reports;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SaveToXLSXManager
{
    /// <summary>
    /// Implementation of report base class group sessions results report
    /// </summary>
    public class GroupSessionsResultsReport : Report
    {
        /// <summary>
        /// Func for sorting column.
        /// </summary>
        private readonly Func<GroupSessionsResultsRow, object> _orderByFunc;

        /// <summary>
        /// Constructor <see cref="GroupSessionsResultsReport"/>
        /// </summary>
        /// <param name="groupName">Group name.</param>
        /// <param name="sessionNumber">Session number.</param>
        /// <param name="orderByFunc">Func for sorting column.</param>
        /// <param name="descending">Sort by descening.</param>
        public GroupSessionsResultsReport(string groupName, int sessionNumber, Func<GroupSessionsResultsRow, object> orderByFunc, bool descending)
        :base(groupName, sessionNumber, descending)
        {
            _orderByFunc = orderByFunc;
        }

        /// <summary>
        /// Table header.
        /// </summary>
        /// <returns>Returns header.</returns>
        public override IEnumerable<string> GetDataHeader()
        {
            return new List<string>
            {
                "ID", "NumberOfGroup", "NumberOfSession", "Surname",
                "FirstName", "MiddleName", "Gender", "DateOfBirth",
                "Subject", "ExamDate", "ExamValue", "SetOffDate",
                "SetOffValue"
            };
        }

        /// <summary>
        /// Table data.
        /// </summary>
        /// <returns>Returns data list.</returns>
        public override IEnumerable<IEnumerable<string>> GetData()
        {
            _getDataRows.Clear();
            foreach (GroupSessionsResultsRow item in GenerateRow().ToList())
            {
                _getDataRows.Add(new List<string>
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
            return _getDataRows;
        }

        /// <summary>
        /// Generate ordered enumerable row.
        /// </summary>
        /// <returns>Returns ordered enumerable row.</returns>
        private IOrderedEnumerable<GroupSessionsResultsRow> GenerateRow()
        {
            Groups requiredGroupReport = _groups.FirstOrDefault(x => x.GroupName == _groupName);
            Sessions requiredSessionReport = _sessions.FirstOrDefault(x => x.Session == _sessionNumber);

            if (requiredGroupReport == null)
                throw new NullReferenceException("Check groupName");
            if (requiredSessionReport == null)
                throw new NullReferenceException("Check sessionNumber");

            var groupSessionExamResult =
                from students in _students
                join sessionsResults in _sessionsResults on students.ID equals sessionsResults.StudentsID
                join examSchedules in _examSchedules on sessionsResults.ExamSchedulesID equals examSchedules.ID
                join subjects in _subjects on examSchedules.SubjectsID equals subjects.ID
                where students.GroupsID == requiredGroupReport.ID & subjects.IsAssessment == "True" &
                examSchedules.SessionsID == requiredSessionReport.ID
                select new
                {
                    students.ID,
                    requiredGroupReport.GroupName,
                    NumberOfSession = requiredSessionReport.Session,
                    students.Surname,
                    students.FirstName,
                    students.MiddleName,
                    students.Gender,
                    students.DateOfBirth,
                    Subject = subjects.SubjectName,
                    examSchedules.ExamDate,
                    sessionsResults.ExamValue
                };

            var groupSessionSetOffResult =
                from students in _students
                join sessionsResults in _sessionsResults on students.ID equals sessionsResults.StudentsID
                join examSchedules in _examSchedules on sessionsResults.ExamSchedulesID equals examSchedules.ID
                join subjects in _subjects on examSchedules.SubjectsID equals subjects.ID
                where students.GroupsID == requiredGroupReport.ID & subjects.IsAssessment == "False" &
                examSchedules.SessionsID == requiredSessionReport.ID
                select new
                {
                    students.ID,
                    requiredGroupReport.GroupName,
                    NumberOfSession = requiredSessionReport.Session,
                    students.Surname,
                    students.FirstName,
                    students.MiddleName,
                    students.Gender,
                    students.DateOfBirth,
                    Subject = subjects.SubjectName,
                    examSchedules.ExamDate,
                    sessionsResults.SetOffValue
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

            if (_descending)
                orderedGroupSessionBothTypeResult = groupSessionbothTypeResult.OrderByDescending(_orderByFunc);
            else
                orderedGroupSessionBothTypeResult = groupSessionbothTypeResult.OrderBy(_orderByFunc);

            return orderedGroupSessionBothTypeResult;

        }
    }
}
