using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace TaskPool.Models
{
    public class Project_Details_History
    {
        public int id { get; set; }
        public int UserId { get; set; }
        public int CagegoryId { get; set; }
        public int ProjectBudgetTo { get; set; }
        public int ProjectBudgetFrom { get; set; }
        public string ProjectTitle { get; set; }
        public string Address { get; set; }
        public string ProjectDescription { get; set; }
        public decimal CommitionAmount { get; set; }
        public string LocationName { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public bool CommitionPaidStatus { get; set; }
        public decimal CommitionPaidAmount { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public bool IsComplete { get; set; }
        public string Image { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool? DeleteFlag { get; set; }
        public string ReviewComment { get; set; }
        public int? ReviewerUserId { get; set; }
        public bool? IsProjectReject { get; set; }
        public int? Project_Ref_Id { get; set; }
        public DateTime? ReviewDate { get; set; }
    }
}
