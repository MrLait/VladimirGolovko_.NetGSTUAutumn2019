using DAO.DBAccessTechnology.LINQtoSQLRepository;
//using DAO.DBAccessTechnology.SqlClientUsingReflectionRepository;
using DAO.Enums;

namespace DAO.Factories
{
    /// <summary>
    /// Abstract object which describes Factory
    /// </summary>
    public abstract class DAOFactory
    {
        public abstract ExaminersRepository CreateExaminersRepository();
        public abstract ExamSchedulesRepository CreateExamSchedulesRepositoryO();
        public abstract GroupsRepository CreateGroupsRepository();
        public abstract SessionsRepository CreateSessionsRepositoryO();
        public abstract SessionsResultsRepository CreateSessionsResultsRepository();
        public abstract SpecialtiesRepository CreateSpecialtiesRepository();
        public abstract StudentsRepository CreateStudentsRepository();
        public abstract SubjectsRepository CreateSubjectsRepository();

        /// <summary>
        /// Factory to switch DAO technology
        /// </summary>
        /// <param name="dbConnectionString">data base connection sting</param>
        /// <returns></returns>
        public static DAOFactory CreateDAOFactory( string dbConnectionString)
        {
            return new LinqToSql(dbConnectionString);
        }
    }


}