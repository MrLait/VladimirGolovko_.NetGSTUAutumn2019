using DAO.Enums;
using DAO.Factories;
using DatabaseModels.Models;
using SaveToXLSXManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using SaveToXLSXManager.ListToObjectQuere;
using System.Reflection;
using System.IO;

namespace SaveToXLSXManager
{
    /// <summary>
    /// Save Session Results To Excel file
    /// </summary>
    public class SaveSessionResultsToXLSX
    {
        /// <summary>
        /// Dao factory 
        /// </summary>
        public DAOFactory DaoFactory { get; private set; }

        /// <summary>
        /// Excel instance
        /// </summary>
        public Excel Excel { get; set; }

        /// <summary>
        /// Groups table
        /// </summary>
        public IList<Group> Groups { get; set; }

        /// <summary>
        /// Student model
        /// </summary>
        public IList<Student> Student { get; set; }

        /// <summary>
        /// Student session results
        /// </summary>
        public IList<StudentSessionResults> StudentSessionResults { get; set; }

        /// <summary>
        /// Exam schedule 
        /// </summary>
        public IList<ExamSchedule> ExamSchedule { get; set; }

        /// <summary>
        /// Number of sessions
        /// </summary>
        public IList<NumberOfSession> NumberOfSessions { get; set; }

        /// <summary>
        /// Path to Excel File
        /// </summary>
        public string PathToExcelFile { get; set; }

        /// <summary>
        /// Constuctor of <see cref="SaveSessionResultsToXLSX"/>
        /// </summary>
        /// <param name="dbConnectionString"> db connection string</param>
        /// <param name="pathToExcelFile">path to file</param>
        public SaveSessionResultsToXLSX(string dbConnectionString, string pathToExcelFile)
        {
            PathToExcelFile = pathToExcelFile;
            DaoFactory = DAOFactory.CreateDAOFactory(DBAccessTechnologyEnum.SqlClientUsingReflection, dbConnectionString);
            Groups = DaoFactory.CreateGroupRepositoryDAO().GetAll();
            Student = DaoFactory.CreateStudentRepositoryDAO().GetAll();
            StudentSessionResults = DaoFactory.CreateStudentSessionResultsRepositoryDAO().GetAll();
            ExamSchedule = DaoFactory.CreateExamScheduleRepositoryDAO().GetAll();
            NumberOfSessions = DaoFactory.CreateNumberOfSessionRepositoryDAO().GetAll();

        }

        /// <summary>
        /// Save all session result by group to EXCL tables
        /// </summary>
        public void SaveAllSessionResultByGroupToEXCLTables()
        {
            foreach (Group item in Groups)
            {
                IEnumerable<Student> studentByGroupQuere = Quere.StudentByGroupQuere(item, Student);
                IEnumerable<ExamSchedule> examSheduleByGroupQuere = Quere.ExamSheduleByGroupQuere(item, ExamSchedule);
                IEnumerable<SessionTableExamResult> studentSessionResultExamQuere = Quere.StudentSessionResultExamQuere(StudentSessionResults, studentByGroupQuere, examSheduleByGroupQuere, item.NumberOfGroup);
                IEnumerable<SessionTableSetOffResult> studentSessionResultSetOffQuere = Quere.StudentSessionResultSetOffQuere(StudentSessionResults, studentByGroupQuere, examSheduleByGroupQuere, item.NumberOfGroup);
                IEnumerable<SessionTableOfBothResult> sessionTableOfBothResultsQuere = Quere.SessionTableOfBothResultsQuere(studentSessionResultExamQuere, studentSessionResultSetOffQuere);

                SaveDataToEXCL(sessionTableOfBothResultsQuere, "AllResultsByGroup№" + item.NumberOfGroup);
            }
        }

        /// <summary>
        /// Save average minimum maximum value for each group ToEXCL Tables
        /// </summary>
        public void SaveAverageMinimumMaximumValueforEachGroupToEXCLTables()
        {
            foreach (NumberOfSession numberOfSessionItem in NumberOfSessions)
            {
                foreach (Group item in Groups)
                {
                    //IEnumerable<Group> groupQuere = Quere.GroupQuere()
                    IEnumerable<Student> studentByGroupQuere = Quere.StudentByGroupQuere(item, Student);
                    IEnumerable<ExamSchedule> examSheduleByGroupQuere = Quere.ExamSheduleByGroupQuere(item, ExamSchedule);
                    IEnumerable<SessionTableExamResult> studentSessionResultExamQuere = Quere.StudentSessionResultExamQuere(StudentSessionResults, studentByGroupQuere, examSheduleByGroupQuere, item.NumberOfGroup);
                    IEnumerable<SessionTableSetOffResult> studentSessionResultSetOffQuere = Quere.StudentSessionResultSetOffQuere(StudentSessionResults, studentByGroupQuere, examSheduleByGroupQuere, item.NumberOfGroup);
                    IEnumerable<SessionTableOfBothResult> sessionTableOfBothResultsQuere = Quere.SessionTableOfBothResultsQuere(studentSessionResultExamQuere, studentSessionResultSetOffQuere, numberOfSessionItem);

                    var minQueres =
                        from SessionTableOfBothResult in sessionTableOfBothResultsQuere
                        let minGroup = sessionTableOfBothResultsQuere.Min(n => n.ExamValue)
                        select minGroup;

                    var minExamValue = minQueres.First();

                    var maxQueres =
                        from SessionTableOfBothResult in sessionTableOfBothResultsQuere
                        let maxGroup = sessionTableOfBothResultsQuere.Max(n => n.ExamValue)
                        select maxGroup;
                    
                    var maxExamValue = maxQueres.First();

                    var averageQueres =
                        from SessionTableOfBothResult in sessionTableOfBothResultsQuere
                        let averageGroup = sessionTableOfBothResultsQuere.Average(n => n.ExamValue)
                        select averageGroup;
                    
                    var averageExamValue = averageQueres.First();

                    SaveMaxMinAvereByGroupBySessionToEXCL(minExamValue, maxExamValue, averageExamValue, "AllResultsByGroup№" + item.NumberOfGroup, "BySession№" + numberOfSessionItem.NumOfSession);
                }
            }
        }

        /// <summary>
        /// Get List of students for expulsion grouped by Group
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IGrouping<string, SessionTableOfBothResult>> GetListOfStudentsForExpulsionGroupedByGroup()
        {
            List<SessionTableOfBothResult> asListSessionTableOfBothResults = new List<SessionTableOfBothResult>();
            foreach (NumberOfSession numberOfSessionItem in NumberOfSessions)
            {
                foreach (Group item in Groups)
                {
                    IEnumerable<Student> studentByGroupQuere = Quere.StudentByGroupQuere(item, Student);
                    IEnumerable<ExamSchedule> examSheduleByGroupQuere = Quere.ExamSheduleByGroupQuere(item, ExamSchedule);
                    IEnumerable<SessionTableExamResult> studentSessionResultExamQuere = Quere.StudentSessionResultExamQuere(StudentSessionResults, studentByGroupQuere, examSheduleByGroupQuere, item.NumberOfGroup);
                    IEnumerable<SessionTableSetOffResult> studentSessionResultSetOffQuere = Quere.StudentSessionResultSetOffQuere(StudentSessionResults, studentByGroupQuere, examSheduleByGroupQuere, item.NumberOfGroup);
                    IEnumerable<SessionTableOfBothResult> sessionTableOfBothResultsQuere = Quere.SessionTableOfBothResultsQuere(studentSessionResultExamQuere, studentSessionResultSetOffQuere, numberOfSessionItem);
                    asListSessionTableOfBothResults.AddRange(sessionTableOfBothResultsQuere);
                }
            }
            IEnumerable<SessionTableOfBothResult> sessionTableOfBothResults = asListSessionTableOfBothResults as IEnumerable<SessionTableOfBothResult>;

            IEnumerable<IGrouping<string, SessionTableOfBothResult>> listOfStudentsForExpulsionQuere =
                from SessionTableOfBothResult in sessionTableOfBothResults
                where SessionTableOfBothResult.ExamValue < 40
                group SessionTableOfBothResult by SessionTableOfBothResult.NumberOfGroup;

            return listOfStudentsForExpulsionQuere;
        }

        /// <summary>
        /// Save max min avere by group bySession ToEXCL
        /// </summary>
        /// <param name="minExamValue">minExamValue</param>
        /// <param name="maxExamValue">maxExamValue</param>
        /// <param name="averageExamValue">averageExamValue</param>
        /// <param name="numberOfGroup">numberOfGroup</param>
        /// <param name="numberOfSession">numberOfSession</param>
        private void SaveMaxMinAvereByGroupBySessionToEXCL(int minExamValue, int maxExamValue, double averageExamValue, string numberOfGroup, string numberOfSession)
        {
            Excel = new Excel();
            try
            {
                Excel.CreateNewFile();
                Excel.CreateNewSheet(numberOfGroup + numberOfSession);
                Excel.WriteDataToCell(1, 1, numberOfGroup);
                Excel.WriteDataToCell(1, 2, numberOfSession);
                Excel.WriteDataToCell(1, 3, "MinimumExamValue");
                Excel.WriteDataToCell(1, 4, "MaximumExamValue");
                Excel.WriteDataToCell(1, 5, "AverageExamValue");

                Excel.WriteDataToCell(2, 1, numberOfGroup);
                Excel.WriteDataToCell(2, 2, numberOfSession);
                Excel.WriteDataToCell(2, 3, minExamValue);
                Excel.WriteDataToCell(2, 4, maxExamValue);
                Excel.WriteDataToCell(2, 5, averageExamValue);
                Excel.SaveAs(PathToExcelFile + @"\" + numberOfGroup + numberOfSession);
                Excel.Close();
                Excel.Quit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Excel.Workbook = null;
                Excel.Worksheet = null;
                Excel.CelRange = null;
            }
        }

        /// <summary>
        /// Save data to EXCeL
        /// </summary>
        /// <param name="sessionTableOfBothResultsQuere">sessionTableOfBothResultsQuere</param>
        /// <param name="numberOfGroup">numberOfGroup</param>
        private void SaveDataToEXCL(IEnumerable<SessionTableOfBothResult> sessionTableOfBothResultsQuere, string numberOfGroup)
        {

            var asListSessionTableOfBothResultsQuere = sessionTableOfBothResultsQuere.ToList();
            Excel = new Excel();

            try
            {
                Excel.CreateNewFile();
                Excel.CreateNewSheet(numberOfGroup);

                var listProps = asListSessionTableOfBothResultsQuere[0].GetType().GetProperties();

                for (int i = 0; i < listProps.Length; i++)
                {
                    Excel.WriteDataToCell(1, i + 1, listProps[i].Name);
                }

                int counterRow = 2;

                foreach (var item in asListSessionTableOfBothResultsQuere)
                {
                    var listItemProp = item.GetType().GetProperties();

                    for (int i = 0; i < listItemProp.Length; i++)
                    {
                        var test = listProps[i].GetValue(item, null);
                        Excel.WriteDataToCell(counterRow, i + 1, listProps[i].GetValue(item, null));
                    }
                    counterRow++;
                }


                Excel.SaveAs(PathToExcelFile + @"\" + numberOfGroup);
                Excel.Close();
                Excel.Quit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Excel.Workbook = null;
                Excel.Worksheet = null;
                Excel.CelRange = null;
            }
        }
    }
}
