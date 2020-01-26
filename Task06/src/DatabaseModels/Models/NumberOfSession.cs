using DatabaseModels.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModels.Models
{
    public class NumberOfSession : IEntity
    {
        [Key]
        public int ID { get; set; }

        public int NumOfSession { get; set; }
    }
}
