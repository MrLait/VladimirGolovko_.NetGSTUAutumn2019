using DatabaseModels.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModels.Models
{
    /// <summary>
    /// Number of session table
    /// </summary>
    public class NumberOfSession : IEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        [Key]
        public int ID { get; set; }

        /// <summary>
        /// Number of session
        /// </summary>
        public int NumOfSession { get; set; }
    }
}
