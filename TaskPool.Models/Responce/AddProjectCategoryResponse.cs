using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TaskPool.Models
{
   public class AddProjectCategoryResponse
    {
        public int id { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public List<string> invalidReasons { get; set; }
        public int? status { get; set; }
        public string Message { get; set; }
    }
}
