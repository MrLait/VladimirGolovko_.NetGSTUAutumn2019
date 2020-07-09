using NUnit.Framework;
using System.Collections.Generic;

namespace SaveToXLSXManager.Tests
{
    /// <summary>
    /// Tests for <see cref="DynamicsAverageSubjectScoreByYearsReport"/>.
    /// </summary>
    [TestFixture()]
    public class DynamicsAverageSubjectScoreByYearsReportTests
    {
        /// <summary>
        /// Get data header tests.
        /// </summary>
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

        /// <summary>
        /// Get data when descending is true by average exam value.
        /// </summary>
        /// <param name="descending">Sort descending or ascending.</param>
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

        /// <summary>
        /// Test get data when descending is false by average exam value.
        /// </summary>
        /// <param name="descending">Sort descending or ascending.</param>
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