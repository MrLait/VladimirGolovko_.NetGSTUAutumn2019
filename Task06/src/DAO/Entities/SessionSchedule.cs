﻿using DAO.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAO.Entities
{
    [Table("SessionSchedule")]
    public class SessionSchedule
    {
        [Key]
        public int ID { get; set; }

        public int StudentGroup { get; set; }
        public DateTime ExamDate { get; set; }
        public DateTime OffsetDate { get; set; }
        public int NumberOfSession { get; set; }
        public string Subject { get; set; }
    }
}