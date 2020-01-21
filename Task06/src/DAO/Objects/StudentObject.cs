using DAO.Entities;

namespace DAO.Objects
{
    public class StudentObject : BaseObject<Student>
    {
        public StudentObject(string dbConStr) : base(dbConStr)
        {
        }
    }
}
