using DAO.DBAccessTechnology.LINQtoSQLRepository;
using DAO.Interfaces;
using DBModelsLinqToSql.Models;

namespace DAO.Factories
{
    internal class LinqToSqlSingelton : DAOFactory
    {
        private static LinqToSqlSingelton instance;
        
        public static string DbConnectionString { get; private set; }

        private LinqToSqlSingelton(){}


        public static LinqToSqlSingelton GetInstance(string dbConnectionStrig)
        {
            if (DbConnectionString == null)
            {
                DbConnectionString = dbConnectionStrig;
                instance = new LinqToSqlSingelton();
            }
            return instance;
        }

        public override ICRUD<Students> CreateStudentsRepository()
        {
            return new StudentsRepository(DbConnectionString);
        }

        public override ICRUD<Examiners> CreateExaminersRepository()
        {
            return new ExaminersRepository(DbConnectionString);
        }

        public override ICRUD<ExamSchedules> CreateExamSchedulesRepositoryO()
        {
            return new ExamSchedulesRepository(DbConnectionString);
        }

        public override ICRUD<Groups> CreateGroupsRepository()
        {
            return new GroupsRepository(DbConnectionString);
        }

        public override ICRUD<Sessions> CreateSessionsRepositoryO()
        {
            return new SessionsRepository(DbConnectionString);
        }

        public override ICRUD<SessionsResults> CreateSessionsResultsRepository()
        {
            return new SessionsResultsRepository(DbConnectionString);
        }

        public override ICRUD<Specialties> CreateSpecialtiesRepository()
        {
            return new SpecialtiesRepository(DbConnectionString);
        }

        public override ICRUD<Subjects> CreateSubjectsRepository()
        {
            return new SubjectsRepository(DbConnectionString);
        }


    }
}