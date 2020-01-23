using DAO.DBAccessTechnology.SqlClientUsingReflectionObjects;
using DAO.Enums;

namespace DAO.Factories
{
    public abstract class DAOFactory
    {
        public abstract StudentObject CreateStudentObjectDAO();
        public abstract SessionScheduleObject CreateSessionScheduleObjectDAO();

        public static DAOFactory CreateDAOFactory(DBAccessTechnologyEnum witchDAOenum, string dbConnectionString)
        {
            switch (witchDAOenum)
            {
                case DBAccessTechnologyEnum.SqlClientUsingReflection:
                    return new SqlClientUsingReflection(dbConnectionString);
                case .DBAccessTechnologyEnum.LINQtoSQL:
                    throw new System.Exception("Not implemented");
                default:
                    return null;
            }
        }
    }


}