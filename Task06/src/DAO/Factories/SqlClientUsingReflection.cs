using DAO.DBAccessTechnology.SqlClientUsingReflectionObjects;

namespace DAO.Factories
{
    public class SqlClientUsingReflection : DAOFactory
    {
        public string DbConnectionString { get; set; }

        public SqlClientUsingReflection(string dbConnectionString)
        {
            DbConnectionString = dbConnectionString;
        }

        public override SessionScheduleObject CreateSessionScheduleObjectDAO()
        {
            return new SessionScheduleObject(DbConnectionString);
        }

        public override StudentObject CreateStudentObjectDAO()
        {
            return new StudentObject(DbConnectionString);
        }
    }
}
