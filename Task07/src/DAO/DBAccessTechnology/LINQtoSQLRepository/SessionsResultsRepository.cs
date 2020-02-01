using DBModelsLinqToSql.Models;

namespace DAO.DBAccessTechnology.LINQtoSQLRepository
{
    /// <summary>
    /// Student repository which have been implemented Student model
    /// </summary>
    public class SessionsResultsRepository : Repository<SessionsResults>
    {
        /// <summary>
        /// Constructor student repository
        /// </summary>
        /// <param name="dbConStr">database connection string</param>
        public SessionsResultsRepository(string dbConStr) : base(dbConStr)
        {
        }

    }
}
