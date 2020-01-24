using DatabaseModels.Models;

namespace DAO.DBAccessTechnology.SqlClientUsingReflectionRepository
{
    public class SetOffScheduleRepository : AbstractRepository<SetOffSchedule>
    {
        public SetOffScheduleRepository(string dbConStr) : base(dbConStr)
        {
        }
    }
}
