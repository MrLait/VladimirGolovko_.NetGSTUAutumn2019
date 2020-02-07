using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace SaveToXLSXManager.Tests
{
    [TestFixture()]
    public class AverageScoreForEachSpecialtyReportTests
    {
        [Test()]
        public void GivenGetDataHeaderTest()
        {
            //Arrnge
            AverageScoreForEachSpecialtyReport averageScoreForEachSpecialtyReport = new AverageScoreForEachSpecialtyReport(1, x => x.AverageExamValue, true);
            IEnumerable<string> expectedGetDataHeader = new List<string>
            {
                "SessionNumber", "SpecialtiesName", "AverageExamValue"
            };

            //Act
            var actualGetDataHeader = averageScoreForEachSpecialtyReport.GetDataHeader();

            //Assert
            Assert.AreEqual(expectedGetDataHeader, actualGetDataHeader);
        }

        [TestCase(1, true)]
        public void GivenGetDataWhenDescendingIsTrueByAverageExamValue(int sessionNumber, bool descending)
        {
            //Arrange
            AverageScoreForEachSpecialtyReport averageScoreForEachSpecialtyReport = new AverageScoreForEachSpecialtyReport(sessionNumber, x => x.AverageExamValue, descending);
            IEnumerable<IEnumerable<string>> expectedGetData = new List<List<string>>()
            {
                new List<string> { "1", "Tester", "48,1875" },
                new List<string> { "1", "Programmer", "47,875" }
            };

            //Act
            IEnumerable<IEnumerable<string>> actualGetData = averageScoreForEachSpecialtyReport.GetData();

            //Assert
            Assert.AreEqual(expectedGetData, actualGetData);
        }

        [TestCase(1, false)]
        public void GivenGetDataWhenDescendingIsFalseByAverageExamValuee(int sessionNumber, bool descending)
        {
            //Arrange
            AverageScoreForEachSpecialtyReport averageScoreForEachSpecialtyReport = new AverageScoreForEachSpecialtyReport(sessionNumber, x => x.AverageExamValue, descending);
            IEnumerable<IEnumerable<string>> expectedGetData = new List<List<string>>()
            {
                new List<string> { "1", "Programmer", "47,875" },
                new List<string> { "1", "Tester", "48,1875" }
            };

            //Act
            IEnumerable<IEnumerable<string>> actualGetData = averageScoreForEachSpecialtyReport.GetData();

            //Assert
            Assert.AreEqual(expectedGetData, actualGetData);
        }

        [TestCase(5, false)]
        [TestCase(50, true)]
        public void GivenGetDataWhenDescendingIsFalseByFirstNameThenNullReferenceException(int sessionNumber, bool descending)
        {
            //Arrange
            AverageScoreForEachSpecialtyReport averageScoreForEachSpecialtyReport = new AverageScoreForEachSpecialtyReport(sessionNumber, x => x.AverageExamValue, descending);

            //Assert
            Assert.That(() => averageScoreForEachSpecialtyReport.GetData(), Throws.TypeOf<NullReferenceException>());
        }
    }
}