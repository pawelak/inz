using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DBL.Models
{
    public class Stat
    {
        [Key]
        public int Id { get; set; }
        public int YesCounter { get; set; }
        public int NoCounter { get; set; }
        public DateTime LastUsage { get; set; }
        public DateTime NextUsage { get; set; }
        public double KnowLevel { get; set; }

        public Word Word { get; set; }
    }
}