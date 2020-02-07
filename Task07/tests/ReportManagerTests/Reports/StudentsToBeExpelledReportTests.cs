using NUnit.Framework;
using System;

namespace SaveToXLSXManager.Tests
{
    /// <summary>
    /// Test for <see cref="StudentsToBeExpelledReport"/>.
    /// </summary>
    [TestFixture()]
    public class StudentsToBeExpelledReportTests
    {
        /// <summary>
        /// Test for GetData property then NotImplementedException.
        /// </summary>
        /// <param name="minimumPassingScore">Minimum assessment threshold field.</param>
        [TestCase(5)]
        [TestCase(50)]
        public void GivenGetDataThenNotImplementedException(int minimumPassingScore)
        {
            //Arrange
            StudentsToBeExpelledReport studentsToBeExpelledReport = new StudentsToBeExpelledReport(minimumPassingScore);

            //Assert
            Assert.That(() => studentsToBeExpelledReport.GetData(), Throws.TypeOf<NotImplementedException>());
        }

        /// <summary>
        /// Test for GetDataHeader propery then NotImplementedException.
        /// </summary>
        /// <param name="minimumPassingScore">Minimum assessment threshold field.</param>
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