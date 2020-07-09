using DAO.DBAccessTechnology.SqlClientUsingReflectionRepository;
using DAO.Enums;

namespace DAO.Factories
{
    /// <summary>
    /// Abstract object which describes Factory
    /// </summary>
    public abstract class DAOFactory
    {
        /// <summary>
        /// Create ExamSchedule instance
        /// </summary>
        /// <returns></returns>
        public abstract ExamScheduleRepository CreateExamScheduleRepositoryDAO();

        /// <summary>
        /// Abstract method to create CreateGroupRepositoryDAO
        /// </summary>
        /// <returns></returns>
        public abstract GroupRepository CreateGroupRepositoryDAO();

        /// <summary>
        /// Abstract method to create CreateStudentRepositoryDAO
        /// </summary>
        /// <returns></returns>
        public abstract StudentRepository CreateStudentRepositoryDAO();

        /// <summary>
        /// Abstract method to create CreateStudentSessionResultsRepositoryDAO
        /// </summary>
        /// <returns></returns>
        public abstract StudentSessionResultsRepository CreateStudentSessionResultsRepositoryDAO();

        /// <summary>
        /// Abstract method to create CreateNumberOfSessionRepositoryDAO
        /// </summary>
        /// <returns></returns>
        public abstract NumberOfSessionRepository CreateNumberOfSessionRepositoryDAO();

        /// <summary>
        /// Factory to switch DAO technology
        /// </summary>
        /// <param name="witchDAOenum">Type of Dao technology.</param>
        /// <param name="dbConnectionString">data base connection sting</param>
        /// <returns></returns>
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