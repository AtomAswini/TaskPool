using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskPool.Services.Interfaces;
using TaskPool.Repositories;
using TaskPool.Models;
using TaskPool.Common;

namespace TaskPool.Services
{
    public class LoginService:ILoginService
    {
        LoginRepositories _loginRepositories;
        public LoginService()
        {
            _loginRepositories = new LoginRepositories();
        }
        public async Task<LoginResponce> CreateUser( string phoneNumber)           
        {
            var logininfo = await _loginRepositories.CreateUser(phoneNumber); 
            return logininfo;
        }
        public async Task<GetUserByUserNamePasswordResponce> GetUserByUserNamePassword(string userName, string password)
        {
            var logininfo = await _loginRepositories.GetUserByUserNamePassword(userName, password);
            return logininfo;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

       
    }
}
