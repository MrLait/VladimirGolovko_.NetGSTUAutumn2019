using DatabaseModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.DBAccessTechnology.SqlClientUsingReflectionRepository
{
    public class NumberOfSessionRepository : AbstractRepository<NumberOfSession>
    {
        public NumberOfSessionRepository(string dbConStr) : base(dbConStr)
        {
        }
    }
}
