using System.Collections.Generic;
using GenericApp.BusinessLogic.IService;
using GenericApp.DataAccess.DBContext;
using System.Linq;
using GenericApp.Common.ViewModels;

namespace GenericApp.BusinessLogic.Service
{
    public class UserService : IUserService
    {
        private readonly GenericAppEntities GenericAppEntities;
        public UserService(GenericAppEntities _GenericAppEntities)
        {
            GenericAppEntities = _GenericAppEntities;
        }
        public bool CheckUserForLogin(string email, string password)
        {
            return true;
            //return GenericAppEntities.Users.Where(q => q.Email == email && q.Password == password).Any();
        }

        public bool CheckUserForRegister(string email)
        {
            return true;
            //return GenericAppEntities.Users.Where(q => q.Email == email).Any();
        }

        public List<UserViewModel> GetUsers()
        {
            return GenericAppEntities.Users.Select(q => new UserViewModel()
            {
                Name = q.Name,
                Email = q.Email,
                Mobile = q.Mobile,
                Password = q.Password
            }).ToList();
        }
    }
}
