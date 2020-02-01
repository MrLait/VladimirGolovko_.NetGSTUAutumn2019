using DBModelsLinqToSql.Models;

namespace DAO.DBAccessTechnology.LINQtoSQLRepository
{
    /// <summary>
    /// Student repository which have been implemented Student model
    /// </summary>
    public class SubjectsRepository : Repository<Subjects>
    {
        /// <summary>
        /// Constructor student repository
        /// </summary>
        /// <param name="dbConStr">database connection string</param>
        public SubjectsRepository(string dbConStr) : base(dbConStr)
        {
        }

    }
}
