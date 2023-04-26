using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskPool.Models
{
    public class Package_Plan
    {
        public int id { get; set; }
        public string PackageName { get; set; }
        public decimal? Price { get; set; }
        public int? Days { get; set; }
        public bool? DeleteFlag { get; set; }
    }
}
