using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskPool.Repositories;
using TaskPool.Models;

namespace TaskPool.Services.Interfaces
{
    public interface ILoginService  : IDisposable
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        Task<LoginResponce> CreateUser(string phoneNumber);
        Task<GetUserByUserNamePasswordResponce> GetUserByUserNamePassword(string userName, string password);
    }
}
