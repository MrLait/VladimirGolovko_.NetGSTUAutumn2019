using DAO.Factories;
using DBModelsLinqToSql.Models;
using SaveToXLSXManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveToXLSXManager.Reports
{
    public abstract class Report : IReport
    {
        static string _connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SQLServerDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        protected LinqToSqlSingelton _linqToSqlSingelton;

        protected IEnumerable<Examiners> _examiners;
        protected IEnumerable<ExamSchedules> _examSchedules;
        protected IEnumerable<Groups> _groups;
        protected IEnumerable<Sessions> _sessions;
        protected IEnumerable<SessionsResults> _sessionsResults;
        protected IEnumerable<Specialties> _specialties;
        protected IEnumerable<Students> _students;
        protected IEnumerable<Subjects> _subjects;

        protected bool _descending;
        protected List<List<string>> _getDataRows;
        protected string _groupName;
        protected int _sessionNumber;

        public Report()
        {
            _linqToSqlSingelton = LinqToSqlSingelton.GetInstance(_connectionString);

            _examiners = _linqToSqlSingelton.CreateExaminersRepository().GetAll();
            _examSchedules = _linqToSqlSingelton.CreateExamSchedulesRepository().GetAll();
            _groups = _linqToSqlSingelton.CreateGroupsRepository().GetAll();
            _sessions = _linqToSqlSingelton.CreateSessionsRepository().GetAll();
            _sessionsResults = _linqToSqlSingelton.CreateSessionsResultsRepository().GetAll();
            _specialties = _linqToSqlSingelton.CreateSpecialtiesRepository().GetAll();
            _students = _linqToSqlSingelton.CreateStudentsRepository().GetAll();
            _subjects = _linqToSqlSingelton.CreateSubjectsRepository().GetAll();
        }


        public Report(bool descending) : this()
        {
            _descending = descending;
            _getDataRows = new List<List<string>>();
        }

        public Report(string groupName, bool descending) : this(descending)
        {
            _groupName = groupName;
        }

        public Report(int sessionNumber, bool descending) : this(descending)
        {
            _sessionNumber = sessionNumber;
        }

        public Report(string groupName, int sessionNumber, bool descending) : this(groupName, descending)
        {
            _sessionNumber = sessionNumber;
        }


        public abstract IEnumerable<IEnumerable<string>> GetData();

        public abstract IEnumerable<string> GetDataHeader();
    }
}
