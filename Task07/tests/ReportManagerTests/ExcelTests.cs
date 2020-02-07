using NUnit.Framework;
using SaveToXLSXManager;
using SaveToXLSXManager.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveToXLSXManager.Tests
{
    [TestFixture()]
    public class ExcelTests
    {
        [TestCase("PM-2", 1, true)]
        public void SaveToXLSXTestWhenGroupSessionsResultsReport(string groupName, int sessionNumber, bool descending)
        {
            //Arrange
            var location = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var path = Path.GetDirectoryName(location);
            IReport report = new GroupSessionsResultsReport(groupName, sessionNumber, x => x.FirstName, descending);
            bool fileIsExist = false;

            //Act
            Excel excel = new Excel(path + "\\Excel\\", "GroupSessions");
            excel.SaveToXLSX(report);
            if (File.Exists(path + "\\Excel\\" + "GroupSessions.xlsx"))
                fileIsExist = true;

            //Assert
            Assert.IsTrue(fileIsExist);
        }

        [TestCase(1, false)]
        public void SaveToXLSXTestWhenAverageScoreForEachExaminerReport(int sessionNumber, bool descending)
        {
            //Arrange
            var location = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var path = Path.GetDirectoryName(location);
            IReport report = new AverageScoreForEachExaminerReport(sessionNumber, x => x.FirstName, descending);
            bool fileIsExist = false;

            //Act
            Excel excel = new Excel(path + "\\Excel\\", "AverageScoreExaminerReport");
            excel.SaveToXLSX(report);
            if (File.Exists(path + "\\Excel\\" + "AverageScoreExaminerReport.xlsx"))
                fileIsExist = true;

            //Assert
            Assert.IsTrue(fileIsExist);
        }

        [TestCase(1, false)]
        public void SaveToXLSXTestWhenAverageScoreForEachSpecialtyReport(int sessionNumber, bool descending)
        {
            //Arrange
            var location = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var path = Path.GetDirectoryName(location);
            IReport report = new AverageScoreForEachSpecialtyReport(sessionNumber, x => x.AverageExamValue, descending);
            bool fileIsExist = false;

            //Act
            Excel excel = new Excel(path + "\\Excel\\", "AverageScoreSpecialtyReport");
            excel.SaveToXLSX(report);
            if (File.Exists(path + "\\Excel\\" + "AverageScoreSpecialtyReport.xlsx"))
                fileIsExist = true;

            //Assert
            Assert.IsTrue(fileIsExist);
        }

        [TestCase(true)]
        public void SaveToXLSXTestWhenDynamicsAverageSubjectScoreByYearsReport(bool descending)
        {
            //Arrange
            var location = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var path = Path.GetDirectoryName(location);
            IReport report = new DynamicsAverageSubjectScoreByYearsReport(x => x.AverageExamValue, descending);
            bool fileIsExist = false;

            //Act
            Excel excel = new Excel(path + "\\Excel\\", "DynamicsAverageSubjectReport");
            excel.SaveToXLSX(report);
            if (File.Exists(path + "\\Excel\\" + "DynamicsAverageSubjectReport.xlsx"))
                fileIsExist = true;

            //Assert
            Assert.IsTrue(fileIsExist);
        }

        [TestCase("PM-1", false)]
        public void GivenGetDataWhenDescendingIsFalseByAverageExamValue(string groupName, bool descending)
        {
            //Arrange
            var location = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var path = Path.GetDirectoryName(location);
            IReport report = new PivotResultsReport(groupName, x => x.AverageExamValue, descending);
            bool fileIsExist = false;
            Excel excel = new Excel(path + "\\Excel\\", "PivotResultsReport");


            //Act
            excel.SaveToXLSX(report);

            if (File.Exists(path + "\\Excel\\" + "PivotResultsReport.xlsx"))
                fileIsExist = true;

            //Assert
            Assert.IsTrue(fileIsExist);
        }
    }
}