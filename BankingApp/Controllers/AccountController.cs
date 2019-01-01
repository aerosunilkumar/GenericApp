using GenericApp.BusinessLogic.IService;
using GenericApp.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace GenericApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService userService;
        public AccountController(IUserService userService)
        {
            this.userService = userService;
        }

        // GET: Account
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(UserViewModel userViewModel)
        {
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                if (userViewModel.validateLogin())
                {
                    if (userService.CheckUserForLogin(userViewModel.Email, userViewModel.Password))
                    {
                        FormsAuthentication.SetAuthCookie(userViewModel.Email, true);
                    }
                    else
                    {
                        userViewModel.GeneralError = "Login credentials are invalid ";
                        return View(userViewModel);
                    }
                }
                else
                {
                    return View(userViewModel);
                }
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Signout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}