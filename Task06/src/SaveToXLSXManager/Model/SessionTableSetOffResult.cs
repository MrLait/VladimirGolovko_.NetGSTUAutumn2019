using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveToXLSXManager.Model
{
    /// <summary>
    /// Session table setOff result
    /// </summary>
    public class SessionTableSetOffResult: SessionTableResult
    {
        /// <summary>
        /// SetOff date
        /// </summary>
        public DateTime SetOffDate { get; set; }

        /// <summary>
        /// SetOff value
        /// </summary>
        public string SetOffValue { get; set; }
    }
}
