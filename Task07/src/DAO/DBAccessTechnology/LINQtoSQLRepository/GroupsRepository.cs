using DBModelsLinqToSql.Models;

namespace DAO.DBAccessTechnology.LINQtoSQLRepository
{
    /// <summary>
    /// Student repository which have been implemented Student model
    /// </summary>
    public class GroupsRepository : Repository<Groups>
    {
        /// <summary>
        /// Constructor student repository
        /// </summary>
        /// <param name="dbConStr">database connection string</param>
        public GroupsRepository(string dbConStr) : base(dbConStr)
        {
        }

    }
}
