using DBModelsLinqToSql.Models;
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
    public class StudentsToBeExpelledReportTests
    {
        [TestCase(5)]
        [TestCase(50)]
        public void GivenGetDataThenNotImplementedException(int minimumPassingScore)
        {
            //Arrange
            StudentsToBeExpelledReport studentsToBeExpelledReport = new StudentsToBeExpelledReport(minimumPassingScore);

            //Assert
            Assert.That(() => studentsToBeExpelledReport.GetData(), Throws.TypeOf<NotImplementedException>());
        }

        [TestCase(5)]
        [TestCase(50)]
        public void GivenGetDataHeaderThenNotImplementedException(int minimumPassingScore)
        {
            //Arrange
            StudentsToBeExpelledReport studentsToBeExpelledReport = new StudentsToBeExpelledReport(minimumPassingScore);

            //Assert
            Assert.That(() => studentsToBeExpelledReport.GetData(), Throws.TypeOf<NotImplementedException>());
        }
    }
}