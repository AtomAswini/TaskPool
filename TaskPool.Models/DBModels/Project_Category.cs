using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace TaskPool.Models
{
    public class Project_Category
    {
        public int id { get; set; }
        public string Category { get; set; }
        public string Description { get; set; } 
        public bool? IsActive { get; set; }
        public string Image { get; set; }
        public bool? DeleteFlag { get; set; }
    }
}
