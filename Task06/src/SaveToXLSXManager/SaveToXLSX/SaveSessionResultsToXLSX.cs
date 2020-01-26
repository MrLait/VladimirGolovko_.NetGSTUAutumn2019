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
    public class SaveSessionResultsToXLSX
    {
        public DAOFactory DaoFactory { get; private set; }
        public Excel Excel { get; set; }
        public IList<Group> Groups { get; set; }
        public IList<Student> Student { get; set; }
        public IList<StudentSessionResults> StudentSessionResults { get; set; }
        public IList<ExamSchedule> ExamSchedule { get; set; }
        public IList<NumberOfSession> NumberOfSessions { get; set; }
        public string PathToExcelFile { get; set; }

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
