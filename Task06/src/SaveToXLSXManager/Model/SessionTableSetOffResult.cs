using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveToXLSXManager.Model
{
    public class SessionTableSetOffResult: SessionTableResult
    {
        public DateTime SetOffDate { get; set; }
        public string SetOffValue { get; set; }
    }
}
