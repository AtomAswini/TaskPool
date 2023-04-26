using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskPool.Models;
namespace TaskPool.Repositories
{
    public class LoginRepositories
    {
        TaskPoolContext db = new TaskPoolContext();

        public async Task<LoginResponce> CreateUser(string phoneNumber )          
        {
            // Add new User else get existing user if phonenumber regeistered
            var p = db.login.FirstOrDefault(a => a.PhoneNumber == phoneNumber);
            return new LoginResponce() { id=p.id,Email=p.Email,phoneNumber=p.PhoneNumber};
        }
        public async Task<GetUserByUserNamePasswordResponce> GetUserByUserNamePassword(string userName, string password)
        {
            var user = db.Tbl_Login_Manage.FirstOrDefault(a => a.User_Name == userName && a.Password==password);
            return new GetUserByUserNamePasswordResponce() { user=user };
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
