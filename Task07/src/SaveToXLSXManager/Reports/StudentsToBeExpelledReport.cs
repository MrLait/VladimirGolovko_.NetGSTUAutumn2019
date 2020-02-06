using DAO.Factories;
using DAO.Interfaces;
using DBModelsLinqToSql.Models;
using SaveToXLSXManager.Interfaces;
using SaveToXLSXManager.Model;
using SaveToXLSXManager.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveToXLSXManager
{
    public class StudentsToBeExpelledReport : Report
    {
        private int _minimumPassingScore;

        public StudentsToBeExpelledReport(int minimumPassingScore) : base()
        {
            _minimumPassingScore = minimumPassingScore;
        }

        public override IEnumerable<IEnumerable<string>> GetData()
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<string> GetDataHeader()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IGrouping<int, Students>> GetStudentsToBeExpelled()
        {
            IEnumerable<Students> expelledStudentsQuere =
                (from sessionsResults in _sessionsResults
                 join students in _students on sessionsResults.StudentsID equals students.ID
                 join examSchedules in _examSchedules on sessionsResults.ExamSchedulesID equals examSchedules.ID
                 join subjects in _subjects on examSchedules.SubjectsID equals subjects.ID
                 where sessionsResults.ExamValue <= _minimumPassingScore & subjects.IsAssessment == "True"
                 select students).Distinct();

            IEnumerable<IGrouping<int, Students>> expelledStudentsGroupedByGroup =
                (from ExpelledStudentsQuere in expelledStudentsQuere
                group ExpelledStudentsQuere by ExpelledStudentsQuere.GroupsID);

            if (expelledStudentsGroupedByGroup == null)
                throw new NullReferenceException("Data not found.");

            return expelledStudentsGroupedByGroup;
        }
    }
}
