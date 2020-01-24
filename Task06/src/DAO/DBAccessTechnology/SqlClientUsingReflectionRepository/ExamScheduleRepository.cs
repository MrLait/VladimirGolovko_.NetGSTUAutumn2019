using DatabaseModels.Models;

namespace DAO.DBAccessTechnology.SqlClientUsingReflectionRepository
{
    public class ExamScheduleRepository : AbstractRepository<ExamSchedule>
    {
        public ExamScheduleRepository(string dbConStr) : base(dbConStr)
        {
        }
    }
}
