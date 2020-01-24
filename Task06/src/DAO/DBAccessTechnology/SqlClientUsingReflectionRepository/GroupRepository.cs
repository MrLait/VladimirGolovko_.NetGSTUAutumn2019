using DatabaseModels.Models;

namespace DAO.DBAccessTechnology.SqlClientUsingReflectionRepository
{
    public class GroupRepository : AbstractRepository<Group>
    {
        public GroupRepository(string dbConStr) : base(dbConStr)
        {
        }
    }
}
