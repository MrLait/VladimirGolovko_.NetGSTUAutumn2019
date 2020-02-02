//using DatabaseModels.Models;
//using DBModelsLinqToSql.Models;
//using SaveToXLSXManager.Model;
//using System.Collections.Generic;
//using System.Linq;

//namespace SaveToXLSXManager.ListToObjectQuere
//{

//    /// <summary>
//    /// linq to object quere
//    /// </summary>
//    public class Quere
//    {
//        /// <summary>
//        /// StudentByGroupQuere
//        /// </summary>
//        /// <param name="item">group item</param>
//        /// <param name="student"> studen</param>
//        /// <returns></returns>
//        public static IEnumerable<Student> StudentByGroupQuere(Group item, IList<Student> student)
//        {
//            return (
//                from Student in student
//                where Student.GroupID == item.ID
//                select Student);
//        }

//        /// <summary>
//        /// ExamSheduleByGroupQuere
//        /// </summary>
//        /// <param name="item">item</param>
//        /// <param name="examSchedule">examSchedule</param>
//        /// <returns></returns>
//        public static IEnumerable<ExamSchedule> ExamSheduleByGroupQuere(Group item, IList<ExamSchedule> examSchedule)
//        {
//            return (
//                from ExamSchedule in examSchedule
//                where ExamSchedule.GroupID == item.ID
//                select ExamSchedule);
//        }

//        /// <summary>
//        /// Student Session Result Exam Quere
//        /// </summary>
//        /// <param name="studentSessionResults">studentSessionResults</param>
//        /// <param name="studentByGroupQuere">studentByGroupQuere</param>
//        /// <param name="examSheduleByGroupQuere">examSheduleByGroupQuere</param>
//        /// <param name="numberOfGroup">numberOfGroup</param>
//        /// <returns></returns>
//        public static IEnumerable<SessionTableExamResult> StudentSessionResultExamQuere(IList<StudentSessionResults> studentSessionResults,
//            IEnumerable<Student> studentByGroupQuere, IEnumerable<ExamSchedule> examSheduleByGroupQuere, string numberOfGroup)
//        {
//            return (from StudentSessionResults in studentSessionResults
//                    where StudentSessionResults.SetOffValue == ""
//                    join ExamSchedule in examSheduleByGroupQuere on StudentSessionResults.ExamScheduleID equals ExamSchedule.ID
//                    join Student in studentByGroupQuere on StudentSessionResults.StudentID equals Student.ID
//                    select new SessionTableExamResult
//                    {
//                        ID = Student.ID,
//                        NumberOfGroup = numberOfGroup,
//                        NumberOfSession = ExamSchedule.NumberOfSessionID,
//                        Surname = Student.Surname,
//                        FirstName = Student.FirstName,
//                        MiddleName = Student.MiddleName,
//                        Gender = Student.Gender,
//                        DateOfBirth = Student.DateOfBirth,
//                        Subject = ExamSchedule.Subject,
//                        ExamDate = ExamSchedule.ExamDate,
//                        ExamValue = StudentSessionResults.ExamValue
//                    });
//        }

//        /// <summary>
//        /// Student Session Result SetOff Quere
//        /// </summary>
//        /// <param name="studentSessionResults">studentSessionResults</param>
//        /// <param name="studentByGroupQuere">studentByGroupQuere</param>
//        /// <param name="examSheduleByGroupQuere">examSheduleByGroupQuere</param>
//        /// <param name="numberOfGroup">numberOfGroup</param>
//        /// <returns></returns>
//        public static IEnumerable<SessionTableSetOffResult> StudentSessionResultSetOffQuere(IList<StudentSessionResults> studentSessionResults,
//    IEnumerable<Students> studentByGroupQuere, IEnumerable<ExamSchedule> examSheduleByGroupQuere, string numberOfGroup)
//        {
//            return (from StudentSessionResults in studentSessionResults
//                    where StudentSessionResults.SetOffValue != ""
//                    join ExamSchedule in examSheduleByGroupQuere on StudentSessionResults.ExamScheduleID equals ExamSchedule.ID
//                    join Student in studentByGroupQuere on StudentSessionResults.StudentID equals Student.ID
//                    select new SessionTableSetOffResult
//                    {
//                        ID = Student.ID,
//                        NumberOfGroup = numberOfGroup,
//                        NumberOfSession = ExamSchedule.NumberOfSessionID,
//                        Surname = Student.Surname,
//                        FirstName = Student.FirstName,
//                        MiddleName = Student.MiddleName,
//                        Gender = Student.Gender,
//                        DateOfBirth = Student.DateOfBirth,
//                        Subject = ExamSchedule.Subject,
//                        SetOffDate = ExamSchedule.ExamDate,
//                        SetOffValue = StudentSessionResults.SetOffValue
//                    });
//        }

//        /// <summary>
//        /// Session Table Of Both Results Quere
//        /// </summary>
//        /// <param name="studentSessionResultExamQuere">studentSessionResultExamQuere</param>
//        /// <param name="studentSessionResultSetOffQuere">studentSessionResultSetOffQuere</param>
//        /// <returns></returns>
//        public static IEnumerable<SessionTableOfBothResult> SessionTableOfBothResultsQuere(
//            IEnumerable<SessionTableExamResult> studentSessionResultExamQuere, IEnumerable<SessionTableSetOffResult> studentSessionResultSetOffQuere)
//        {
//            return (from SessionTableExamResult in studentSessionResultExamQuere
//                    from SessionTableSetOffResult in studentSessionResultSetOffQuere
//                    where SessionTableExamResult.ID == SessionTableSetOffResult.ID &&
//                    SessionTableExamResult.Subject == SessionTableSetOffResult.Subject
//                    select new SessionTableOfBothResult
//                    {
//                        ID = SessionTableExamResult.ID,
//                        NumberOfGroup = SessionTableExamResult.NumberOfGroup,
//                        NumberOfSession = SessionTableExamResult.NumberOfSession,
//                        Surname = SessionTableExamResult.Surname,
//                        FirstName = SessionTableExamResult.FirstName,
//                        MiddleName = SessionTableExamResult.MiddleName,
//                        Gender = SessionTableExamResult.Gender,
//                        DateOfBirth = SessionTableExamResult.DateOfBirth,
//                        Subject = SessionTableSetOffResult.Subject,
//                        ExamDate = SessionTableExamResult.ExamDate,
//                        ExamValue = SessionTableExamResult.ExamValue,
//                        SetOffDate = SessionTableSetOffResult.SetOffDate,
//                        SetOffValue = SessionTableSetOffResult.SetOffValue
//                    });
//        }

//        /// <summary>
//        /// Session Table Of Both Results Quere
//        /// </summary>
//        /// <param name="studentSessionResultExamQuere">studentSessionResultExamQuere</param>
//        /// <param name="studentSessionResultSetOffQuere">studentSessionResultSetOffQuere</param>
//        /// <param name="numberOfSessionItem">numberOfSessionItem</param>
//        /// <returns></returns>
//        public static IEnumerable<SessionTableOfBothResult> SessionTableOfBothResultsQuere(
//    IEnumerable<SessionTableExamResult> studentSessionResultExamQuere, IEnumerable<SessionTableSetOffResult> studentSessionResultSetOffQuere, NumberOfSession numberOfSessionItem)
//        {
//            return (from SessionTableExamResult in studentSessionResultExamQuere
//                    from SessionTableSetOffResult in studentSessionResultSetOffQuere
//                    where SessionTableExamResult.ID == SessionTableSetOffResult.ID &&
//                    SessionTableExamResult.Subject == SessionTableSetOffResult.Subject &&
//                    SessionTableExamResult.NumberOfSession == numberOfSessionItem.NumOfSession
//                    select new SessionTableOfBothResult
//                    {
//                        ID = SessionTableExamResult.ID,
//                        NumberOfGroup = SessionTableExamResult.NumberOfGroup,
//                        NumberOfSession = SessionTableExamResult.NumberOfSession,
//                        Surname = SessionTableExamResult.Surname,
//                        FirstName = SessionTableExamResult.FirstName,
//                        MiddleName = SessionTableExamResult.MiddleName,
//                        Gender = SessionTableExamResult.Gender,
//                        DateOfBirth = SessionTableExamResult.DateOfBirth,
//                        Subject = SessionTableSetOffResult.Subject,
//                        ExamDate = SessionTableExamResult.ExamDate,
//                        ExamValue = SessionTableExamResult.ExamValue,
//                        SetOffDate = SessionTableSetOffResult.SetOffDate,
//                        SetOffValue = SessionTableSetOffResult.SetOffValue
//                    });
//        }

//    }
//}
