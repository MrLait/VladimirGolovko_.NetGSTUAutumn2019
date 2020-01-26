using DAO.DBAccessTechnology.SqlClientUsingReflectionRepository;
using DAO.Enums;

namespace DAO.Factories
{
    public abstract class DAOFactory
    {
        public abstract ExamScheduleRepository CreateExamScheduleRepositoryDAO();
        public abstract GroupRepository CreateGroupRepositoryDAO();
        public abstract StudentRepository CreateStudentRepositoryDAO();
        public abstract StudentSessionResultsRepository CreateStudentSessionResultsRepositoryDAO();
        public abstract NumberOfSessionRepository CreateNumberOfSessionRepositoryDAO();

        public static DAOFactory CreateDAOFactory(DBAccessTechnologyEnum witchDAOenum, string dbConnectionString)
        {
            switch (witchDAOenum)
            {
                case DBAccessTechnologyEnum.SqlClientUsingReflection:
                    return new SqlClientUsingReflection(dbConnectionString);
                case DBAccessTechnologyEnum.LINQtoSQL:
                    throw new System.Exception("Not implemented");
                default:
                    return null;
            }
        }
    }


}