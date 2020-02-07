using NUnit.Framework;
using SaveToXLSXManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveToXLSXManager.Tests
{
    [TestFixture()]
    public class DynamicsAverageSubjectScoreByYearsReportTests
    {

        [Test()]
        public void GivenGetDataHeaderTest()
        {
            //Arrnge
            DynamicsAverageSubjectScoreByYearsReport dynamicsAverageSubjectScoreByYearsReport = new DynamicsAverageSubjectScoreByYearsReport(x => x.AverageExamValue, true);
            IEnumerable<string> expectedGetDataHeader = new List<string>
            {
                "ExamDataYear", "Subject", "AverageExamValue"
            };

            //Act
            var actualGetDataHeader = dynamicsAverageSubjectScoreByYearsReport.GetDataHeader();

            //Assert
            Assert.AreEqual(expectedGetDataHeader, actualGetDataHeader);
        }

        [TestCase( true)]
        public void GivenGetDataWhenDescendingIsTrueByAverageExamValue(bool descending)
        {
            //Arrange
            DynamicsAverageSubjectScoreByYearsReport averageScoreForEachSpecialtyReport = new DynamicsAverageSubjectScoreByYearsReport(x => x.AverageExamValue, descending);
            IEnumerable<IEnumerable<string>> expectedGetData = new List<List<string>>()
            {
                new List<string> { "2019", "Subject-2.0", "68,30" },
                new List<string> { "2019", "Subject-1.0", "50,68" },
                new List<string> { "2020", "Subject-1.0", "49,00" },
                new List<string> { "2020", "Subject-2.0", "41,93" }
            };

            //Act
            IEnumerable<IEnumerable<string>> actualGetData = averageScoreForEachSpecialtyReport.GetData();

            //Assert
            Assert.AreEqual(expectedGetData, actualGetData);
        }

        [TestCase(false)]
        public void GivenGetDataWhenDescendingIsFalseByAverageExamValue(bool descending)
        {
            //Arrange
            DynamicsAverageSubjectScoreByYearsReport averageScoreForEachSpecialtyReport = new DynamicsAverageSubjectScoreByYearsReport(x => x.AverageExamValue, descending);
            IEnumerable<IEnumerable<string>> expectedGetData = new List<List<string>>()
            {
                new List<string> { "2020", "Subject-2.0", "41,93" },
                new List<string> { "2020", "Subject-1.0", "49,00" },
                new List<string> { "2019", "Subject-1.0", "50,68" },
                new List<string> { "2019", "Subject-2.0", "68,30" }
            };

            //Act
            IEnumerable<IEnumerable<string>> actualGetData = averageScoreForEachSpecialtyReport.GetData();

            //Assert
            Assert.AreEqual(expectedGetData, actualGetData);
        }
    }
}