using NUnit.Framework;
using System.Collections.Generic;
using DAO.Factories;
using DBModelsLinqToSql.Models;
using System.Linq;
using System.Data.SqlClient;
using System;

namespace DAO.DBAccessTechnology.LINQtoSQLRepository.Tests
{
    [TestFixture()]
    public class RepositoryTests
    {
        static string _connectionString = "Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=SQLServerDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";
        private LinqToSqlSingelton _linqToSqlSingelton = LinqToSqlSingelton.GetInstance(_connectionString);

        [TestCase()]
        public void GivenGetAll()
        {
            //Arrange
            IEnumerable<Groups> _actualValue = _linqToSqlSingelton.CreateGroupsRepository().GetAll();

            //Act
            IEnumerable<Groups> expectedValue = new List<Groups>(){
                new Groups(){ GroupName = "PM-1", ID = 1, SpecialtiesID = 2},
                new Groups(){ GroupName = "PM-2", ID = 2, SpecialtiesID = 2},
                new Groups(){ GroupName = "PM-3", ID = 3, SpecialtiesID = 2},
                new Groups(){ GroupName = "PM-4", ID = 4, SpecialtiesID = 1}
            };
            //Assert
            Assert.AreEqual(expectedValue, _actualValue);
        }

        [TestCase()]
        public void GivenAdd()
        {
            //Arrange
            Groups groups = new Groups() { GroupName = "PM-15", SpecialtiesID = 2 };
            var expectedValue = new Groups() { ID = 5, GroupName = "PM-15", SpecialtiesID = 2 };

            //Act
            _linqToSqlSingelton.CreateGroupsRepository().Add(groups);
            Groups actualValue = _linqToSqlSingelton.CreateGroupsRepository().GetAll().Last();
            var getLastElementID = _linqToSqlSingelton.CreateGroupsRepository().GetAll().Last().ID;

            expectedValue.ID = getLastElementID;

            //Assert
            Assert.AreEqual(expectedValue, actualValue);
            _linqToSqlSingelton.CreateGroupsRepository().Delete(getLastElementID);
        }

        [TestCase()]
        public void GivenUpdate()
        {
            //Arrange
            Sessions sessions = new Sessions() { ID = 4, Session = 10 };

            Sessions expectedSessions = new Sessions() { ID = 4, Session = 100 };

            //Act
            _linqToSqlSingelton.CreateSessionsRepository().Add(sessions);

            var getLastElementID = _linqToSqlSingelton.CreateSessionsRepository().GetAll().Last().ID;

            Sessions updateSessions = new Sessions() { ID = getLastElementID, Session = 100 };

            var actualSession = _linqToSqlSingelton.CreateSessionsRepository().Update(updateSessions);

            var getUpdatedElement = _linqToSqlSingelton.CreateSessionsRepository().GetByID(getLastElementID);

            expectedSessions.ID = getLastElementID;

            //Assert
            Assert.AreEqual(expectedSessions.ID, actualSession.ID);
            Assert.AreEqual(expectedSessions.Session, actualSession.Session);
            _linqToSqlSingelton.CreateSessionsRepository().Delete(getLastElementID);
        }

        [TestCase()]
        public void GivenUpdateThenInvalidOperationException()
        {
            //Arrange
            Groups groups = new Groups() { ID = 8, GroupName = "PM-10", SpecialtiesID = 2 };

            //Assert
            Assert.That(() => _linqToSqlSingelton.CreateGroupsRepository().Update(groups), Throws.TypeOf<InvalidOperationException>());
        }

    }
}