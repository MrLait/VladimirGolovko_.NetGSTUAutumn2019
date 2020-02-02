using DAO.Interfaces;
using DBModelsLinqToSql.Models;

namespace DAO.Factories
{
    /// <summary>
    /// Abstract object which describes Factory
    /// </summary>
    public abstract class DAOFactory
    {
        public abstract ICRUD<Examiners> CreateExaminersRepository();
        public abstract ICRUD<ExamSchedules> CreateExamSchedulesRepository();
        public abstract ICRUD<Groups> CreateGroupsRepository();
        public abstract ICRUD<Sessions> CreateSessionsRepository();
        public abstract ICRUD<SessionsResults> CreateSessionsResultsRepository();
        public abstract ICRUD<Specialties> CreateSpecialtiesRepository();
        public abstract ICRUD<Students> CreateStudentsRepository();
        public abstract ICRUD<Subjects> CreateSubjectsRepository();
    }
}