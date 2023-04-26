using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TaskPool.Models
{
    public class TaskPoolContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public TaskPoolContext() : base("name=TaskPoolsContext")
        {
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public System.Data.Entity.DbSet<TaskPool.Models.Login> login { get; set; }
        public System.Data.Entity.DbSet<TaskPool.Models.Project_Category> Project_Category { get; set; }
        public System.Data.Entity.DbSet<TaskPool.Models.Project_Details> Project_Details { get; set; }
        public System.Data.Entity.DbSet<TaskPool.Models.Package_Plan> Package_Plan { get; set; }

        public System.Data.Entity.DbSet<TaskPool.Models.Payment_Details> Payment_Details { get; set; }
        public System.Data.Entity.DbSet<TaskPool.Models.User_Details> User_Details { get; set; }
        public System.Data.Entity.DbSet<TaskPool.Models.Logs> Logs { get; set; }
        public System.Data.Entity.DbSet<TaskPool.Models.Tbl_Mst_User_Manage> Tbl_Mst_User_Manage { get; set; }
        public System.Data.Entity.DbSet<TaskPool.Models.Tbl_Login_Manage> Tbl_Login_Manage { get; set; }
        public System.Data.Entity.DbSet<TaskPool.Models.Payment_Details_History> Payment_Details_History { get; set; }
        public System.Data.Entity.DbSet<TaskPool.Models.User_Details_History> User_Details_History { get; set; }
        public System.Data.Entity.DbSet<TaskPool.Models.Project_Details_History> Project_Details_History { get; set; }

    }
}
