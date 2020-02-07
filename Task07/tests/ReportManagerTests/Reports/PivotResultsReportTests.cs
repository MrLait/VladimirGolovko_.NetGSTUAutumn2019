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
    public class PivotResultsReportTests
    {
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