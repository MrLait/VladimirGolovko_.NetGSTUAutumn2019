//using DAO.DBAccessTechnology.SqlClientUsingReflectionRepository;

//namespace DAO.Factories
//{
//    /// <summary>
//    /// Access to table with SqlClient Using Reflection techology
//    /// </summary>
//    public class SqlClientUsingReflection : DAOFactory
//    {
//        /// <summary>
//        /// Connection string to database
//        /// </summary>
//        public string DbConnectionString { get; set; }

//        /// <summary>
//        /// Constructor <see cref="SqlClientUsingReflection"/>
//        /// </summary>
//        /// <param name="dbConnectionString"><see cref="DbConnectionString"/></param>
//        public SqlClientUsingReflection(string dbConnectionString)
//        {
//            DbConnectionString = dbConnectionString;
//        }

//        /// <summary>
//        /// Create new instance ExamScheduleRepository
//        /// </summary>
//        /// <returns> returns a new instance.</returns>
//        public override ExamScheduleRepository CreateExamScheduleRepositoryDAO()
//        {
//            return new ExamScheduleRepository(DbConnectionString);
//        }

//        /// <summary>
//        /// Create new instance GroupRepository
//        /// </summary>
//        /// <returns> returns a new instance.</returns>
//        public override GroupRepository CreateGroupRepositoryDAO()
//        {
//            return new GroupRepository(DbConnectionString);
//        }

//        /// <summary>
//        /// Create new instance StudentRepository
//        /// </summary>
//        /// <returns> returns a new instance.</returns>
//        public override StudentRepository CreateStudentRepositoryDAO()
//        {
//            return new StudentRepository(DbConnectionString);
//        }

//        /// <summary>
//        /// Create new instance StudentSessionResultsRepository
//        /// </summary>
//        /// <returns> returns a new instance.</returns>
//        public override StudentSessionResultsRepository CreateStudentSessionResultsRepositoryDAO()
//        {
//            return new StudentSessionResultsRepository(DbConnectionString);
//        }

//        /// <summary>
//        /// Create new instance NumberOfSessionRepository
//        /// </summary>
//        /// <returns> returns a new instance.</returns>
//        public override NumberOfSessionRepository CreateNumberOfSessionRepositoryDAO()
//        {
//            return new NumberOfSessionRepository(DbConnectionString);
//        }
//    }
//}
