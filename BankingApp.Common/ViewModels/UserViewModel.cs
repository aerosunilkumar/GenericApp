using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericApp.Common.ViewModels
{
    public class UserViewModel: ErrorBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ErrorName { get; set; }
        public string Email { get; set; }
        public string ErrorEmail { get; set; }
        public string Mobile { get; set; }
        public string ErrorMobile { get; set; }
        public string Password { get; set; }
        public string ErrorPassword { get; set; }
        public string ConfimPassword { get; set; }
        public string ErrorConfimPassword { get; set; }
        public bool RememberMe { get; set; }

        /// <summary>
        /// Validate for Register
        /// </summary>
        /// <returns>returns bool as success or failed</returns>
        public bool validateRegister()
        {
            bool flag = true;
            if (string.IsNullOrEmpty(Name))
            {
                ErrorName = "Name Reqired";
                flag = false;
            }
            if (string.IsNullOrEmpty(Email))
            {
                ErrorEmail = "Email Reqired";
                flag = false;
            }
            if (string.IsNullOrEmpty(Mobile))
            {
                ErrorMobile = "Mobile Reqired";
                flag = false;
            }
            if (string.IsNullOrEmpty(Password))
            {
                ErrorPassword = "Password Reqired";
                flag = false;
            }
            if (string.IsNullOrEmpty(ConfimPassword))
            {
                ErrorConfimPassword = "Confirm Password Reqired";
                flag = false;
            }
            if (!string.IsNullOrEmpty(Password) && !string.IsNullOrEmpty(ConfimPassword) && Password != ConfimPassword)
            {
                ErrorPassword = "Confirm Password is not matching";
                flag = false;
            }
            return flag;
        }

        /// <summary>
        /// Validate For Login
        /// </summary>
        /// <returns>returns bool as success or failed</returns>
        public bool validateLogin()
        {
            bool flag = true;
            if (string.IsNullOrEmpty(Email))
            {
                ErrorEmail = "Email Reqired";
                flag = false;
            }
           
            if (string.IsNullOrEmpty(Password))
            {
                ErrorPassword = "Password Reqired";
                flag = false;
            }
            return flag;
        }
    }
}
