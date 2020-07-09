using NUnit.Framework;
using SaveToXLSXManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveToXLSXManager.Tests
{
    /// <summary>
    /// Test for <see cref="PivotResultsReport"/>.
    /// </summary>
    [TestFixture()]
    public class PivotResultsReportTests
    {
        /// <summary>
        /// Test for GetDataHeader method.
        /// </summary>
        [Test()]
        public void GivenGetDataHeaderTest()
        {
            //Arrnge
            PivotResultsReport pivotResultsReport = new PivotResultsReport("PM-1",x=> x.AverageExamValue,true);
            IEnumerable<string> expectedGetDataHeader = new List<string>
            {
                "NumberOfSession", "MaxExamValue", "MinExamValue", "AverageExamValue"
            };

            //Act
            var actualGetDataHeader = pivotResultsReport.GetDataHeader();

            //Assert
            Assert.AreEqual(expectedGetDataHeader, actualGetDataHeader);
        }

        /// <summary>
        /// Test for GetData method when descending is true sorted by the AverageExamValue column.
        /// </summary>
        /// <param name="groupName"></param>
        /// <param name="descending">Sort descending or ascending.</param>
        [TestCase("PM-1", true)]
        public void GivenGetDataWhenDescendingIsTrueByAverageExamValue(string groupName, bool descending)
        {
            //Arrange
            PivotResultsReport pivotResultsReport = new PivotResultsReport(groupName, x => x.AverageExamValue, descending);
            IEnumerable<IEnumerable<string>> expectedGetData = new List<List<string>>()
            {
                new List<string> { "2","98","4","47,25"},
                new List<string> { "1","96","1","36,75" }
            };

            //Act
            IEnumerable<IEnumerable<string>> actualGetData = pivotResultsReport.GetData();

            //Assert
            Assert.AreEqual(expectedGetData, actualGetData);
        }

        /// <summary>
        /// Test for GetData method when descending Is false sorted by the AverageExamValue column.
        /// </summary>
        /// <param name="groupName">Group name.</param>
        /// <param name="descending">Sort descending or ascending.</param>
        [TestCase("PM-1", false)]
        public void GivenGetDataWhenDescendingIsFalseByAverageExamValue(string groupName, bool descending)
        {
            //Arrange
            PivotResultsReport pivotResultsReport = new PivotResultsReport(groupName, x => x.AverageExamValue, descending);
            IEnumerable<IEnumerable<string>> expectedGetData = new List<List<string>>()
            {
                new List<string> { "1","96","1","36,75" },
                new List<string> { "2","98","4","47,25"}
            };

            //Act
            IEnumerable<IEnumerable<string>> actualGetData = pivotResultsReport.GetData();

            //Assert
            Assert.AreEqual(expectedGetData, actualGetData);
        }

        /// <summary>
        /// Test for GetData method sorted by the FirstName then NullReferenceException.
        /// </summary>
        /// <param name="groupName">Group name.</param>
        /// <param name="descending">Sort descending or ascending.</param>
        [TestCase("PM-10", false)]
        [TestCase("PM-20", true)]
        public void GivenGetDataWhenDescendingIsFalseByFirstNameThenNullReferenceException(string groupName, bool descending)
        {
            //Arrange
            PivotResultsReport pivotResultsReport = new PivotResultsReport(groupName, x => x.AverageExamValue, descending);

            //Assert
            Assert.That(() => pivotResultsReport.GetData(), Throws.TypeOf<NullReferenceException>());
        }

    }
}