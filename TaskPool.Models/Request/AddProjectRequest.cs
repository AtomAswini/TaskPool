using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskPool.Models.Request
{
    public class AddProjectRequest
    {
        public int UserId { get; set; }
        public string Address { get; set; }
        public string ProjectBudgetTo { get; set; }
        public string ProjectBudgetFrom { get; set; }
        public string ProjectDescription { get; set; }
        public string ProjectTitle { get; set; }
        public decimal CommitionAmount { get; set; }
        public string Image { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string LocationName { get; set; }
        public int CagegoryId { get; set; }
       
        
    }
}
