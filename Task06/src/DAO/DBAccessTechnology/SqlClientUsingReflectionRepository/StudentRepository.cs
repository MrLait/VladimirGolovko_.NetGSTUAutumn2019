using DatabaseModels.Models;

namespace DAO.DBAccessTechnology.SqlClientUsingReflectionRepository
{
    public class StudentRepository : AbstractRepository<Student>
    {
        public StudentRepository(string dbConStr) : base(dbConStr)
        {
        }
    }
}
