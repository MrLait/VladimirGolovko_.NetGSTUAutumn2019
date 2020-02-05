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
        protected DAOFactory _linqToSqlSingelton;

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

        public Report(LinqToSqlSingelton linqToSqlSingelton)
        {
            _linqToSqlSingelton = linqToSqlSingelton;

            _examiners = _linqToSqlSingelton.CreateExaminersRepository().GetAll();
            _examSchedules = _linqToSqlSingelton.CreateExamSchedulesRepository().GetAll();
            _groups = _linqToSqlSingelton.CreateGroupsRepository().GetAll();
            _sessions = _linqToSqlSingelton.CreateSessionsRepository().GetAll();
            _sessionsResults = _linqToSqlSingelton.CreateSessionsResultsRepository().GetAll();
            _specialties = _linqToSqlSingelton.CreateSpecialtiesRepository().GetAll();
            _students = _linqToSqlSingelton.CreateStudentsRepository().GetAll();
            _subjects = _linqToSqlSingelton.CreateSubjectsRepository().GetAll();
        }


        public Report(LinqToSqlSingelton linqToSqlSingelton, bool descending) : this(linqToSqlSingelton)
        {
            _descending = descending;
            _getDataRows = new List<List<string>>();
        }

        public Report(LinqToSqlSingelton linqToSqlSingelton, string groupName, bool descending) : this(linqToSqlSingelton, descending)
        {
            _groupName = groupName;
        }

        public Report(LinqToSqlSingelton linqToSqlSingelton, int sessionNumber, bool descending) : this(linqToSqlSingelton, descending)
        {
            _sessionNumber = sessionNumber;
        }

        public Report(LinqToSqlSingelton linqToSqlSingelton, string groupName, int sessionNumber, bool descending) : this(linqToSqlSingelton, groupName, descending)
        {
            _sessionNumber = sessionNumber;
        }


        public abstract IEnumerable<IEnumerable<string>> GetData();

        public abstract IEnumerable<string> GetDataHeader();
    }
}
