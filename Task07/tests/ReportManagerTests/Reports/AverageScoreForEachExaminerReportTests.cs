using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace SaveToXLSXManager.Tests
{
    /// <summary>
    /// Tests for <see cref="AverageScoreForEachExaminerReport"/>.
    /// </summary>
    [TestFixture()]
    public class AverageScoreForEachExaminerReportTests
    {

        /// <summary>
        /// Test for GetData method when descending is true sorted by first name.
        /// </summary>
        /// <param name="sessionNumber">Session number.</param>
        /// <param name="descending">Sort descending or ascending.</param>
        [TestCase(1, true)]
        public void GivenGetDataWhenDescendingIsTrueByFirstName(int sessionNumber, bool descending)
        {
            //Arrange
            AverageScoreForEachExaminerReport averageScoreForEachExaminerReport = new AverageScoreForEachExaminerReport(sessionNumber, x => x.FirstName, descending);
            IEnumerable<IEnumerable<string>> expectedGetData = new List<List<string>>()
            {
                new List<string> { "1", "Surname2", "Firstname2", "Middlename2", "50" },
                new List<string> { "1", "Surname1", "Firstname1", "Middlename1", "46,1666666666667" }
            };

            //Act
            IEnumerable<IEnumerable<string>> actualGetData = averageScoreForEachExaminerReport.GetData();

            //Assert
            Assert.AreEqual(expectedGetData, actualGetData);
        }

        /// <summary>
        /// Test for GetData method when descending is false sorted by firstName
        /// </summary>
        /// <param name="sessionNumber">Session number.</param>
        /// <param name="descending">Sort descending or ascending.</param>
        [TestCase(1, false)]
        public void GivenGetDataWhenDescendingIsFalseByFirstName(int sessionNumber, bool descending)
        {
            //Arrange
            AverageScoreForEachExaminerReport averageScoreForEachExaminerReport = new AverageScoreForEachExaminerReport(sessionNumber, x => x.FirstName, descending);
            IEnumerable<IEnumerable<string>> expectedGetData = new List<List<string>>()
            {
                new List<string> { "1", "Surname1", "Firstname1", "Middlename1", "46,1666666666667" },
                new List<string> { "1", "Surname2", "Firstname2", "Middlename2", "50" }
            };

            //Act
            IEnumerable<IEnumerable<string>> actualGetData = averageScoreForEachExaminerReport.GetData();

            //Assert
            Assert.AreEqual(expectedGetData, actualGetData);
        }

        /// <summary>
        /// Test for get data when descending is false sorted by first name then out is NullReferenceException.
        /// </summary>
        /// <param name="sessionNumber">Session number.</param>
        /// <param name="descending">Sort descending or ascending.</param>
        [TestCase(5, false)]
        [TestCase(50, true)]
        public void GivenGetDataWhenDescendingIsFalseByFirstNameThenNullReferenceException(int sessionNumber, bool descending)
        {
            //Arrange
            AverageScoreForEachExaminerReport averageScoreForEachExaminerReport = new AverageScoreForEachExaminerReport(sessionNumber, x => x.FirstName, descending);

            //Assert
            Assert.That(() => averageScoreForEachExaminerReport.GetData(), Throws.TypeOf<NullReferenceException>());
        }

        /// <summary>
        /// Test for get data header.
        /// </summary>
        [Test()]
        public void GivenGetDataHeaderTest()
        {
            //Arrnge
            AverageScoreForEachExaminerReport averageScoreForEachExaminerReport = new AverageScoreForEachExaminerReport(1, x => x.FirstName, true);
            IEnumerable<string> expectedGetDataHeader = new List<string>
            {
                "SessionNumber", "Surname", "FirstName", "MiddleName", "AverageExamValue"
            };

            //Act
            var actualGetDataHeader = averageScoreForEachExaminerReport.GetDataHeader();

            //Assert
            Assert.AreEqual(expectedGetDataHeader, actualGetDataHeader);
        }
    }
}