using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveToXLSXManager.Model
{
    /// <summary>
    /// Session table result
    /// </summary>
    public class SessionTableResult
    {

        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// NumberOfGroup
        /// </summary>
        public string NumberOfGroup { get; set; }

        /// <summary>
        /// NumberOfSession
        /// </summary>
        public int NumberOfSession { get; set; }

        /// <summary>
        /// Surname
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// FirstName
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// MiddleName
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Gender
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// DateOfBirth
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Subject
        /// </summary>
        public string Subject { get; set; }
    }
}
