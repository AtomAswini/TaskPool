using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskPool.Models
{
    public class GoogleLocation
    {
        public string LocationDetails { get; set; }
        public List<string> invalidReasons { get; set; }
    }
}
