using DatabaseModels.Models;
using SaveToXLSXManager.Model;
using System.Collections.Generic;
using System.Linq;

namespace SaveToXLSXManager.ListToObjectQuere
{
    public class Quere
    {
        public static IEnumerable<Student> StudentByGroupQuere(Group item, IList<Student> student)
        {
            return( 
                from Student in student
                where Student.GroupID == item.ID
                select Student);
        }

        public static IEnumerable<ExamSchedule> ExamSheduleByGroupQuere(Group item, IList<ExamSchedule> examSchedule)
        {
            return (
                from ExamSchedule in examSchedule
                where ExamSchedule.GroupID == item.ID
                select ExamSchedule);
        }

        public static IEnumerable<SessionTableExamResult> StudentSessionResultExamQuere(IList<StudentSessionResults> studentSessionResults,
            IEnumerable<Student> studentByGroupQuere, IEnumerable<ExamSchedule> examSheduleByGroupQuere, string numberOfGroup)
        {
            return (from StudentSessionResults in studentSessionResults
                    where StudentSessionResults.SetOffValue == ""
                    join ExamSchedule in examSheduleByGroupQuere on StudentSessionResults.ExamScheduleID equals ExamSchedule.ID
                    join Student in studentByGroupQuere on StudentSessionResults.StudentID equals Student.ID
                    select new SessionTableExamResult
                    {
                        ID = Student.ID,
                        NumberOfGroup = numberOfGroup,
                        NumberOfSession = ExamSchedule.NumberOfSessionID,
                        Surname = Student.Surname,
                        FirstName = Student.FirstName,
                        MiddleName = Student.MiddleName,
                        Gender = Student.Gender,
                        DateOfBirth = Student.DateOfBirth,
                        Subject = ExamSchedule.Subject,
                        ExamDate = ExamSchedule.ExamDate,
                        ExamValue = StudentSessionResults.ExamValue
                    });
        }

        public static IEnumerable<SessionTableSetOffResult> StudentSessionResultSetOffQuere(IList<StudentSessionResults> studentSessionResults,
    IEnumerable<Student> studentByGroupQuere, IEnumerable<ExamSchedule> examSheduleByGroupQuere, string numberOfGroup)
        {
            return (from StudentSessionResults in studentSessionResults
                    where StudentSessionResults.SetOffValue != ""
                    join ExamSchedule in examSheduleByGroupQuere on StudentSessionResults.ExamScheduleID equals ExamSchedule.ID
                    join Student in studentByGroupQuere on StudentSessionResults.StudentID equals Student.ID
                    select new SessionTableSetOffResult
                    {
                        ID = Student.ID,
                        NumberOfGroup = numberOfGroup,
                        NumberOfSession = ExamSchedule.NumberOfSessionID,
                        Surname = Student.Surname,
                        FirstName = Student.FirstName,
                        MiddleName = Student.MiddleName,
                        Gender = Student.Gender,
                        DateOfBirth = Student.DateOfBirth,
                        Subject = ExamSchedule.Subject,
                        SetOffDate = ExamSchedule.ExamDate,
                        SetOffValue = StudentSessionResults.SetOffValue
                    });
        }

        public static IEnumerable<SessionTableOfBothResult> SessionTableOfBothResultsQuere(
            IEnumerable<SessionTableExamResult> studentSessionResultExamQuere, IEnumerable<SessionTableSetOffResult> studentSessionResultSetOffQuere)
        {
            return (from SessionTableExamResult in studentSessionResultExamQuere
                    from SessionTableSetOffResult in studentSessionResultSetOffQuere
                    where SessionTableExamResult.ID == SessionTableSetOffResult.ID &&
                    SessionTableExamResult.Subject == SessionTableSetOffResult.Subject
                    select new SessionTableOfBothResult
                    {
                        ID = SessionTableExamResult.ID,
                        NumberOfGroup = SessionTableExamResult.NumberOfGroup,
                        NumberOfSession = SessionTableExamResult.NumberOfSession,
                        Surname = SessionTableExamResult.Surname,
                        FirstName = SessionTableExamResult.FirstName,
                        MiddleName = SessionTableExamResult.MiddleName,
                        Gender = SessionTableExamResult.Gender,
                        DateOfBirth = SessionTableExamResult.DateOfBirth,
                        Subject = SessionTableSetOffResult.Subject,
                        ExamDate = SessionTableExamResult.ExamDate,
                        ExamValue = SessionTableExamResult.ExamValue,
                        SetOffDate = SessionTableSetOffResult.SetOffDate,
                        SetOffValue = SessionTableSetOffResult.SetOffValue
                    });
        }


        public static IEnumerable<SessionTableOfBothResult> SessionTableOfBothResultsQuere(
    IEnumerable<SessionTableExamResult> studentSessionResultExamQuere, IEnumerable<SessionTableSetOffResult> studentSessionResultSetOffQuere, NumberOfSession numberOfSessionItem)
        {
            return (from SessionTableExamResult in studentSessionResultExamQuere
                    from SessionTableSetOffResult in studentSessionResultSetOffQuere
                    where SessionTableExamResult.ID == SessionTableSetOffResult.ID &&
                    SessionTableExamResult.Subject == SessionTableSetOffResult.Subject && 
                    SessionTableExamResult.NumberOfSession == numberOfSessionItem.NumOfSession
                    select new SessionTableOfBothResult
                    {
                        ID = SessionTableExamResult.ID,
                        NumberOfGroup = SessionTableExamResult.NumberOfGroup,
                        NumberOfSession = SessionTableExamResult.NumberOfSession,
                        Surname = SessionTableExamResult.Surname,
                        FirstName = SessionTableExamResult.FirstName,
                        MiddleName = SessionTableExamResult.MiddleName,
                        Gender = SessionTableExamResult.Gender,
                        DateOfBirth = SessionTableExamResult.DateOfBirth,
                        Subject = SessionTableSetOffResult.Subject,
                        ExamDate = SessionTableExamResult.ExamDate,
                        ExamValue = SessionTableExamResult.ExamValue,
                        SetOffDate = SessionTableSetOffResult.SetOffDate,
                        SetOffValue = SessionTableSetOffResult.SetOffValue
                    });
        }

    }
}
