using DAO.Interfaces;
using DBModelsLinqToSql.Models;

namespace DAO.Factories
{
    /// <summary>
    /// The abstract class that describes an abstract factory.
    /// </summary>
    public abstract class DAOFactory
    {
        /// <summary>
        /// An abstract method that describes creation examiners repository.
        /// </summary>
        /// <returns>Returns interface ICRUD</returns>
        public abstract ICRUD<Examiners> CreateExaminersRepository();

        /// <summary>
        /// An abstract method that describes creation exam schedules repository.
        /// </summary>
        /// <returns>Returns interface ICRUD</returns>
        public abstract ICRUD<ExamSchedules> CreateExamSchedulesRepository();

        /// <summary>
        /// An abstract method that describes creation groups repository.
        /// </summary>
        /// <returns>Returns interface ICRUD</returns>
        public abstract ICRUD<Groups> CreateGroupsRepository();

        /// <summary>
        /// An abstract method that describes creation sessions repository.
        /// </summary>
        /// <returns>Returns interface ICRUD</returns>
        public abstract ICRUD<Sessions> CreateSessionsRepository();

        /// <summary>
        /// An abstract method that describes creation sessions results repository.
        /// </summary>
        /// <returns>Returns interface ICRUD</returns>
        public abstract ICRUD<SessionsResults> CreateSessionsResultsRepository();

        /// <summary>
        /// An abstract method that describes creation specialties repository.
        /// </summary>
        /// <returns>Returns interface ICRUD</returns>
        public abstract ICRUD<Specialties> CreateSpecialtiesRepository();

        /// <summary>
        /// An abstract method that describes creation students repository.
        /// </summary>
        /// <returns>Returns interface ICRUD</returns>
        public abstract ICRUD<Students> CreateStudentsRepository();

        /// <summary>
        /// An abstract method that describes creation subjects repository.
        /// </summary>
        /// <returns>Returns interface ICRUD</returns>
        public abstract ICRUD<Subjects> CreateSubjectsRepository();
    }
}