using DAO.Factories;
using DBModelsLinqToSql.Models;
using SaveToXLSXManager.Interfaces;
using System.Collections.Generic;

namespace SaveToXLSXManager.Reports
{
    /// <summary>
    /// Base abstract class report that implemented IReport interfaca.
    /// </summary>
    public abstract class Report : IReport
    {
        /// <summary>
        /// Database connection string.
        /// </summary>
        static readonly string _connectionString = "Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=SQLServerDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";

        /// <summary>
        /// Linq to sql singlton field.
        /// </summary>
        protected LinqToSqlSingelton _linqToSqlSingelton;

        /// <summary>
        /// Examiners field.
        /// </summary>
        protected IEnumerable<Examiners> _examiners;

        /// <summary>
        /// Exam shedule field.
        /// </summary>
        protected IEnumerable<ExamSchedules> _examSchedules;

        /// <summary>
        /// Groups field.
        /// </summary>
        protected IEnumerable<Groups> _groups;

        /// <summary>
        /// Sessions field.
        /// </summary>
        protected IEnumerable<Sessions> _sessions;

        /// <summary>
        /// Sessions resulds field.
        /// </summary>
        protected IEnumerable<SessionsResults> _sessionsResults;

        /// <summary>
        /// Spcialties field.
        /// </summary>
        protected IEnumerable<Specialties> _specialties;

        /// <summary>
        /// Students field.
        /// </summary>
        protected IEnumerable<Students> _students;

        /// <summary>
        /// Subjects field.
        /// </summary>
        protected IEnumerable<Subjects> _subjects;

        /// <summary>
        /// Sort descending or ascending.
        /// </summary>
        protected bool _descending;

        /// <summary>
        /// Get data row list
        /// </summary>
        protected List<List<string>> _getDataRows;

        /// <summary>
        /// Group name  field.
        /// </summary>
        protected string _groupName;

        /// <summary>
        /// Session number field.
        /// </summary>
        protected int _sessionNumber;

        /// <summary>
        /// Constructor without parameters <see cref="Report"/> which initializes the fields.
        /// </summary>
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

        /// <summary>
        /// Constructor with parameters <see cref="Report"/> which initializes the fields.
        /// </summary>
        /// <param name="descending">Sort descending or ascending.</param>
        public Report(bool descending) : this()
        {
            _descending = descending;
            _getDataRows = new List<List<string>>();
        }

        /// <summary>
        /// Constructor with parameters <see cref="Report"/> which initializes the fields.
        /// </summary>
        /// <param name="groupName">Group name.</param>
        /// <param name="descending">Sort descending or ascending.</param>
        public Report(string groupName, bool descending) : this(descending)
        {
            _groupName = groupName;
        }

        /// <summary>
        /// Constructor with parameters <see cref="Report"/> which initializes the fields.
        /// </summary>
        /// <param name="sessionNumber">Session number.</param>
        /// <param name="descending">Sort descending or ascending.</param>
        public Report(int sessionNumber, bool descending) : this(descending)
        {
            _sessionNumber = sessionNumber;
        }

        /// <summary>
        /// Constructor with parameters <see cref="Report"/> which initializes the fields.
        /// </summary>
        /// <param name="groupName">Group name.</param>
        /// <param name="sessionNumber">Session number.</param>
        /// <param name="descending">Sort descending or ascending.</param>
        public Report(string groupName, int sessionNumber, bool descending) : this(groupName, descending)
        {
            _sessionNumber = sessionNumber;
        }

        /// <summary>
        /// Table data.
        /// </summary>
        /// <returns>Returns data list.</returns>
        public abstract IEnumerable<IEnumerable<string>> GetData();

        /// <summary>
        /// Table header.
        /// </summary>
        /// <returns>Returns header.</returns>
        public abstract IEnumerable<string> GetDataHeader();
    }
}
