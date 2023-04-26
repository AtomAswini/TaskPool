using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace TaskPool.Models
{
    public class ProjectDetailsResponce
    {
        public int id { get; set; }
        public int? UserId { get; set; }
        public string UserName { get; set; }
        public int? CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int? ProjectBudgetTo { get; set; }
        public int? ProjectBudgetFrom { get; set; }
        public string ProjectTitle { get; set; }
        public string Address { get; set; }
        public string ProjectDescription { get; set; }
        public string LocationName { get; set; }
        public bool? IsDelete { get; set; }
        public bool? IsComplete { get; set; }
        public bool? IsActive { get; set; }
        public string Image { get; set; }
        public decimal? CommitionAmount { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public decimal? CommitionPaidAmount { get; set; }
        public bool? CommitionPaidStatus { get; set; }
        public string ReviewComment { get; set; }
    }
}