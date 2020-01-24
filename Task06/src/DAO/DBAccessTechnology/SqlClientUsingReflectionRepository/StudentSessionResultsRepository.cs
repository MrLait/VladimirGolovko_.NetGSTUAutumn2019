using DatabaseModels.Models;

namespace DAO.DBAccessTechnology.SqlClientUsingReflectionRepository
{
    public class StudentSessionResultsRepository : AbstractRepository<StudentSessionResults>
    {
        public StudentSessionResultsRepository(string dbConStr) : base(dbConStr)
        {
        }
    }
}
