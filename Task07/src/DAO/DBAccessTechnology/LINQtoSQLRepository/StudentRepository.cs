using DBModelsLinqToSql.Models;
using System.Collections.Generic;
using System.Data.Linq;

namespace DAO.DBAccessTechnology.LINQtoSQLRepository
{
    /// <summary>
    /// Student repository which have been implemented Student model
    /// </summary>
    public class StudentRepository : Repository<Student>
    {
        /// <summary>
        /// Constructor student repository
        /// </summary>
        /// <param name="dbConStr">database connection string</param>
        public StudentRepository(string dbConStr) : base(dbConStr)
        {
            DbDataContext = new DataContext(dbConStr);
            DbDataContext.DeferredLoadingEnabled = false;
        }


        //public override IEnumerable<Student> GetAll()
        //{
        //    Table<Student> students = LinqToSqlDataContext.GetTable<Student>();
        //    return students;
        //}
    }
}
