using DAO.DBAccessTechnology.LINQtoSQLRepository;

namespace DAO.Factories
{
    internal class LinqToSql : DAOFactory
    {
        /// <summary>
        /// Connection string to database
        /// </summary>
        public string DbConnectionString { get; set; }

        public LinqToSql(string dbConnectionString)
        {
            DbConnectionString = dbConnectionString;
        }

        public override StudentsRepository CreateStudentsRepository()
        {
            return new StudentsRepository(DbConnectionString);
        }

        public override ExaminersRepository CreateExaminersRepository()
        {
            return new ExaminersRepository(DbConnectionString);
        }

        public override ExamSchedulesRepository CreateExamSchedulesRepositoryO()
        {
            return new ExamSchedulesRepository(DbConnectionString);
        }

        public override GroupsRepository CreateGroupsRepository()
        {
            return new GroupsRepository(DbConnectionString);
        }

        public override SessionsRepository CreateSessionsRepositoryO()
        {
            return new SessionsRepository(DbConnectionString);
        }

        public override SessionsResultsRepository CreateSessionsResultsRepository()
        {
            return new SessionsResultsRepository(DbConnectionString);
        }

        public override SpecialtiesRepository CreateSpecialtiesRepository()
        {
            return new SpecialtiesRepository(DbConnectionString);
        }

        public override SubjectsRepository CreateSubjectsRepository()
        {
            return new SubjectsRepository(DbConnectionString);
        }
    }
}