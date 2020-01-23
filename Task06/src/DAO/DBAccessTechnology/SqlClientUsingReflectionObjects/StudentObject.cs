using DAO.Models;

namespace DAO.DBAccessTechnology.SqlClientUsingReflectionObjects
{
    public class StudentObject : BaseObject<Student>
    {
        public StudentObject(string dbConStr) : base(dbConStr)
        {
        }
    }
}
