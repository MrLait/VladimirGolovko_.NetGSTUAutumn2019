using DBModelsLinqToSql.Models;

namespace DAO.DBAccessTechnology.LINQtoSQLRepository
{
    /// <summary>
    /// Student repository which have been implemented Student model
    /// </summary>
    public class SpecialtiesRepository : Repository<Specialties>
    {
        /// <summary>
        /// Constructor student repository
        /// </summary>
        /// <param name="dbConStr">database connection string</param>
        public SpecialtiesRepository(string dbConStr) : base(dbConStr)
        {
        }

    }
}
