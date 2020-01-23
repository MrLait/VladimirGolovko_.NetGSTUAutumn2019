using DAO.Models;

namespace DAO.DBAccessTechnology.SqlClientUsingReflectionObjects
{
    public class SessionScheduleObject : BaseObject<SessionSchedule>
    {
        public SessionScheduleObject(string dbConStr) : base(dbConStr)
        {
        }
    }
}
