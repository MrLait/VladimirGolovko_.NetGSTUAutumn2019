using DBModelsLinqToSql.Models;

namespace DAO.DBAccessTechnology.LINQtoSQLRepository
{
    /// <summary>
    /// Student repository which have been implemented Student model
    /// </summary>
    public class ExamSchedulesRepository : Repository<ExamSchedules>
    {
        /// <summary>
        /// Constructor student repository
        /// </summary>
        /// <param name="dbConStr">database connection string</param>
        public ExamSchedulesRepository(string dbConStr) : base(dbConStr)
        {
        }

    }
}
