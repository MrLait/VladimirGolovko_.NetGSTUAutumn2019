using DBModelsLinqToSql.Models;

namespace DAO.DBAccessTechnology.LINQtoSQLRepository
{
    /// <summary>
    /// Student repository which have been implemented Student model
    /// </summary>
    public class StudentsRepository : Repository<Students>
    {
        /// <summary>
        /// Constructor student repository
        /// </summary>
        /// <param name="dbConStr">database connection string</param>
        public StudentsRepository(string dbConStr) : base(dbConStr)
        {
        }

    }
}
