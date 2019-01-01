using GenericApp.Common.ViewModels;
using GenericApp.DataAccess.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericApp.BusinessLogic.IService
{
    public interface IUserService
    {
        List<UserViewModel> GetUsers();
        bool CheckUserForLogin(string email,string password);
        bool CheckUserForRegister(string email);
    }
}
