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

     //   public override ExamScheduleRepository CreateExamScheduleRepositoryDAO()
     //   {
     //       throw new System.NotImplementedException();
     //   }
     //
     //   public override GroupRepository CreateGroupRepositoryDAO()
     //   {
     //       throw new System.NotImplementedException();
     //   }
     //
     //   public override NumberOfSessionRepository CreateNumberOfSessionRepositoryDAO()
     //   {
     //       throw new System.NotImplementedException();
     //   }

        public override StudentRepository CreateStudentRepositoryDAO()
        {
            return new StudentRepository(DbConnectionString);
        }

    //   public override StudentSessionResultsRepository CreateStudentSessionResultsRepositoryDAO()
    //   {
    //       throw new System.NotImplementedException();
    //   }
    }
}