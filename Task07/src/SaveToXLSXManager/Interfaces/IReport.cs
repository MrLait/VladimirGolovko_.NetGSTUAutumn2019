using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveToXLSXManager.Interfaces
{
    public interface IReport
    {
        IEnumerable<string> GetDataHeader();
        IEnumerable<IEnumerable<string>> GetData();
    }
}
