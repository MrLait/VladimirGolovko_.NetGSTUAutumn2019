using DAO.DBAccessTechnology.LINQtoSQLRepository;
using DAO.Interfaces;
using DBModelsLinqToSql.Models;

namespace DAO.Factories
{
    public sealed class LinqToSqlSingelton : DAOFactory
    {
        private static LinqToSqlSingelton _instance = null;
        private static string _dbConnectionString = null;

        private Repository<Students> _studentsRepository;
        private Repository<Examiners> _examinersRepository;
        private Repository<ExamSchedules> _examSchedulesRepository;
        private Repository<Groups> _groupsRepository;
        private Repository<Sessions> _sessionsRepository;
        private Repository<SessionsResults> _sessionsResultsRepository;
        private Repository<Specialties> _specialtiesRepository;
        private Repository<Subjects> _subjectsRepository;


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

        public override ICRUD<Students> CreateStudentsRepository()
        {
            return _studentsRepository;
        }

        public override ICRUD<Examiners> CreateExaminersRepository()
        {
            return _examinersRepository;
        }

        public override ICRUD<ExamSchedules> CreateExamSchedulesRepository()
        {
            return _examSchedulesRepository;
        }

        public override ICRUD<Groups> CreateGroupsRepository()
        {
            return _groupsRepository;
        }

        public override ICRUD<Sessions> CreateSessionsRepository()
        {
            return _sessionsRepository;
        }

        public override ICRUD<SessionsResults> CreateSessionsResultsRepository()
        {
            return _sessionsResultsRepository;
        }

        public override ICRUD<Specialties> CreateSpecialtiesRepository()
        {
            return _specialtiesRepository;
        }

        public override ICRUD<Subjects> CreateSubjectsRepository()
        {
            return _subjectsRepository;
        }
    }
}