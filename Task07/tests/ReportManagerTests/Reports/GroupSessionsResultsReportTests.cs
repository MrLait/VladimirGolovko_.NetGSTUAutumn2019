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
    /// Test fot <see cref="GroupSessionsResultsReport"/>.
    /// </summary>
    [TestFixture()]
    public class GroupSessionsResultsReportTests
    {
        /// <summary>
        /// Test for GetDataHeader method.
        /// </summary>
        [Test()]
        public void GivenGetDataHeaderTest()
        {
            //Arrnge
            GroupSessionsResultsReport groupSessionsResultsReport = new GroupSessionsResultsReport("asd", 1, x => x.FirstName, true);
            IEnumerable<string> expectedGetDataHeader = new List<string>
            {
                "ID", "NumberOfGroup", "NumberOfSession", "Surname",
                "FirstName", "MiddleName", "Gender", "DateOfBirth",
                "Subject", "ExamDate", "ExamValue", "SetOffDate",
                "SetOffValue"
            };

            //Act
            var actualGetDataHeader = groupSessionsResultsReport.GetDataHeader();

            //Assert
            Assert.AreEqual(expectedGetDataHeader, actualGetDataHeader);
        }

        /// <summary>
        /// Test for GetData method when descending is true sorted by the FirstName.
        /// </summary>
        /// <param name="groupName">Group name.</param>
        /// <param name="sessionNumber">Session number.</param>
        /// <param name="descending">Sort descending or ascending.</param>
        [TestCase("PM-2", 1, true)]
        public void GivenGetDataWhenDescendingIsTrueByFirstName(string groupName, int sessionNumber, bool descending)
        {
            //Arrange
            GroupSessionsResultsReport groupSessionsResultsReport = new GroupSessionsResultsReport(groupName, sessionNumber, x => x.FirstName, descending);
            IEnumerable<IEnumerable<string>> expectedGetData = new List<List<string>>()
            {
                new List<string> {"4","PM-2","1","Surname4","Firstname4","Middlename4","Male","02.02.2020 15:28:14","Subject-1.0","16.11.2019 15:28:14","92","29.11.2019 15:28:14","True"},
                new List<string> { "4" ,"PM-2" ,"1" ,"Surname4","Firstname4","Middlename4","Male","02.02.2020 15:28:14","Subject-2.0","01.11.2019 15:28:14","65","09.11.2019 15:28:14","True"},
                new List<string> {"10","PM-2","1","Surname10","Firstname10","Middlename10","Female","27.01.2020 15:28:14","Subject-1.0","16.11.2019 15:28:14","41","29.11.2019 15:28:14","True"},
                new List<string> {"10","PM-2","1","Surname10","Firstname10","Middlename10","Female","27.01.2020 15:28:14","Subject-2.0","01.11.2019 15:28:14","81","09.11.2019 15:28:14","True"}
            };

            //Act
            IEnumerable<IEnumerable<string>> actualGetData = groupSessionsResultsReport.GetData();

            //Assert
            Assert.AreEqual(expectedGetData, actualGetData);
        }

        /// <summary>
        /// Test for GetData method when descending is false sorted by the FirstName.
        /// </summary>
        /// <param name="groupName">Group name.</param>
        /// <param name="sessionNumber">Session number.</param>
        /// <param name="descending">Sort descending or ascending.</param>
        [TestCase("PM-2", 1, false)]
        public void GivenGetDataWhenDescendingIsFalseFirstName(string groupName, int sessionNumber, bool descending)
        {
            //Arrange
            GroupSessionsResultsReport groupSessionsResultsReport = new GroupSessionsResultsReport(groupName, sessionNumber, x => x.FirstName, descending);
            IEnumerable<IEnumerable<string>> expectedGetData = new List<List<string>>()
            {
                new List<string> {"10","PM-2","1","Surname10","Firstname10","Middlename10","Female","27.01.2020 15:28:14","Subject-1.0","16.11.2019 15:28:14","41","29.11.2019 15:28:14","True"},
                new List<string> {"10","PM-2","1","Surname10","Firstname10","Middlename10","Female","27.01.2020 15:28:14","Subject-2.0","01.11.2019 15:28:14","81","09.11.2019 15:28:14","True"},
                new List<string> {"4","PM-2","1","Surname4","Firstname4","Middlename4","Male","02.02.2020 15:28:14","Subject-1.0","16.11.2019 15:28:14","92","29.11.2019 15:28:14","True"},
                new List<string> { "4" ,"PM-2" ,"1" ,"Surname4","Firstname4","Middlename4","Male","02.02.2020 15:28:14","Subject-2.0","01.11.2019 15:28:14","65","09.11.2019 15:28:14","True"}
            };

            //Act
            IEnumerable<IEnumerable<string>> actualGetData = groupSessionsResultsReport.GetData();

            //Assert
            Assert.AreEqual(expectedGetData, actualGetData);
        }

        /// <summary>
        /// Test for GetData method when descending is false by firstName then NullReferenceException
        /// </summary>
        /// <param name="groupName">Group name.</param>
        /// <param name="sessionNumber">Session number.</param>
        /// <param name="descending">Sort descending or ascending.</param>
        [TestCase("PM-21", 1, false)]
        [TestCase("PM-31", 1, false)]
        [TestCase("PM-1", 51, false)]
        public void GivenGetDataWhenDescendingIsFalseByFirstNameThenNullReferenceException(string groupName, int sessionNumber, bool descending)
        {
            //Arrange
            GroupSessionsResultsReport groupSessionsResultsReport = new GroupSessionsResultsReport(groupName, sessionNumber, x => x.FirstName, descending);

            //Assert
            Assert.That(() => groupSessionsResultsReport.GetData(), Throws.TypeOf<NullReferenceException>());
        }

    }
}