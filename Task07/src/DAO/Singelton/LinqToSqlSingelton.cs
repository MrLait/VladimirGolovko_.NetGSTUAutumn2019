using DAO.DBAccessTechnology.LINQtoSQLRepository;
using DAO.Interfaces;
using DBModelsLinqToSql.Models;

namespace DAO.Factories
{
    /// <summary>
    /// Implementation of the singleton pattern and abstract factory.
    /// </summary>
    public sealed class LinqToSqlSingelton : DAOFactory
    {
        private static LinqToSqlSingelton _instance = null;
        private static string _dbConnectionString = null;

        private readonly Repository<Students> _studentsRepository;
        private readonly Repository<Examiners> _examinersRepository;
        private readonly Repository<ExamSchedules> _examSchedulesRepository;
        private readonly Repository<Groups> _groupsRepository;
        private readonly Repository<Sessions> _sessionsRepository;
        private readonly Repository<SessionsResults> _sessionsResultsRepository;
        private readonly Repository<Specialties> _specialtiesRepository;
        private readonly Repository<Subjects> _subjectsRepository;


        private LinqToSqlSingelton()
        {
            _studentsRepository = new Repository<Students>(_dbConnectionString);
            _examinersRepository = new Repository<Examiners>(_dbConnectionString);
            _examSchedulesRepository = new Repository<ExamSchedules>(_dbConnectionString);
            _groupsRepository = new Repository<Groups>(_dbConnectionString);
            _sessionsRepository = new Repository<Sessions>(_dbConnectionString);
            _sessionsResultsRepository = new Repository<SessionsResults>(_dbConnectionString);
            _specialtiesRepository = new Repository<Specialties>(_dbConnectionString);
            _subjectsRepository = new Repository<Subjects>(_dbConnectionString);
        }

        /// <summary>
        /// Create instance <see cref="LinqToSqlSingelton"/>.
        /// </summary>
        /// <param name="dbConnectionStrig">Connection string.</param>
        /// <returns></returns>
        public static LinqToSqlSingelton GetInstance(string dbConnectionStrig)
        {
            if (_dbConnectionString == null)
            { 
                _dbConnectionString = dbConnectionStrig;
             
                if (_instance == null)
                    _instance = new LinqToSqlSingelton();
            }
            
            return _instance;
        }

        /// <summary>
        /// Implementation of the students repository.
        /// </summary>
        /// <returns>Returns students repository.</returns>
        public override ICRUD<Students> CreateStudentsRepository()
        {
            return _studentsRepository;
        }

        /// <summary>
        /// Implementation of the examiners repository.
        /// </summary>
        /// <returns>Returns examiners repository.</returns>
        public override ICRUD<Examiners> CreateExaminersRepository()
        {
            return _examinersRepository;
        }

        /// <summary>
        /// Implementation of the exam schedules repository.
        /// </summary>
        /// <returns>Returns exam schedules repository.</returns>
        public override ICRUD<ExamSchedules> CreateExamSchedulesRepository()
        {
            return _examSchedulesRepository;
        }

        /// <summary>
        /// Implementation of the groups repository.
        /// </summary>
        /// <returns>Returns groups repository.</returns>
        public override ICRUD<Groups> CreateGroupsRepository()
        {
            return _groupsRepository;
        }

        /// <summary>
        /// Implementation of the sessions repository.
        /// </summary>
        /// <returns>Returns sessions repository.</returns>
        public override ICRUD<Sessions> CreateSessionsRepository()
        {
            return _sessionsRepository;
        }

        /// <summary>
        /// Implementation of the sessions results repository.
        /// </summary>
        /// <returns>Returns sessions results repository.</returns>
        public override ICRUD<SessionsResults> CreateSessionsResultsRepository()
        {
            return _sessionsResultsRepository;
        }

        /// <summary>
        /// Implementation of the specialties repository.
        /// </summary>
        /// <returns>Returns specialties repository.</returns>
        public override ICRUD<Specialties> CreateSpecialtiesRepository()
        {
            return _specialtiesRepository;
        }

        /// <summary>
        /// Implementation of the subjects repository.
        /// </summary>
        /// <returns>Returns subjects repository.</returns>
        public override ICRUD<Subjects> CreateSubjectsRepository()
        {
            return _subjectsRepository;
        }
    }
}