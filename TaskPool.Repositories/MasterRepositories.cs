using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskPool.Models;
using TaskPool.Models.Request;

namespace TaskPool.Repositories
{
   public class MasterRepositories
    {
        TaskPoolContext db = new TaskPoolContext();

        public async Task<GetPackagesResponse> GetPackages()
        {
            var PackageList = db.Package_Plan.Select(a => a).Take(6).ToList();
            return new GetPackagesResponse() { dataList = PackageList };
        }
    }
}
