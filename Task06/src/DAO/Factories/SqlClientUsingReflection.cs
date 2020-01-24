using DAO.DBAccessTechnology.SqlClientUsingReflectionRepository;

namespace DAO.Factories
{
    public class SqlClientUsingReflection : DAOFactory
    {
        public string DbConnectionString { get; set; }

        public SqlClientUsingReflection(string dbConnectionString)
        {
            DbConnectionString = dbConnectionString;
        }

        public override ExamScheduleRepository CreateExamScheduleRepositoryDAO()
        {
            return new ExamScheduleRepository(DbConnectionString);
        }

        public override GroupRepository CreateGroupRepositoryDAO()
        {
            return new GroupRepository(DbConnectionString);
        }

        public override SetOffScheduleRepository CreateSetOffScheduleRepositoryDAO()
        {
            return new SetOffScheduleRepository(DbConnectionString);
        }

        public override StudentRepository CreateStudentRepositoryDAO()
        {
            return new StudentRepository(DbConnectionString);
        }

        public override StudentSessionResultsRepository CreateStudentSessionResultsRepositoryDAO()
        {
            return new StudentSessionResultsRepository(DbConnectionString);
        }
    }
}
