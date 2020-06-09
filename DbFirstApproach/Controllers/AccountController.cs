using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DbFirstApproach.ViewModels;
using DbFirstApproach.Models;
using DbFirstApproach.Identity;
using System.Web.Helpers;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace DbFirstApproach.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel rvm)
        {
            if(ModelState.IsValid)
            {
                //register
                var appDbContext = new ApplicationDbContext();
                var userStore = new ApplicationUserStore(appDbContext);
                var userManager = new ApplicationUserManager(userStore);
                var passwordHash = Crypto.HashPassword(rvm.Password);
                var user = new ApplicationUser()
                {
                    Email = rvm.Email,
                    UserName = rvm.UserName,
                    PasswordHash = passwordHash,
                    City = rvm.City,
                    Country = rvm.Country,
                    
                    Address = rvm.Address,
                    PhoneNumber = rvm.Mobile
                };
                userManager.Create(user);
                IdentityResult result = userManager.Create(user);

                if(result.Succeeded)
                {
                    //role
                    userManager.AddToRole(user.Id, "Customer");

                    //login
                    var authenticationManager = HttpContext.GetOwinContext().Authentication;
                    var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    authenticationManager.SignIn(new AuthenticationProperties(), userIdentity);

                }
                return RedirectToAction("Index","Home" );        
            }
            else
            {
                ModelState.AddModelError("MyError", "Invaid data");
                return View();
            }

        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel lvm)
        {
            var appDbContext = new ApplicationDbContext();
            var userStore = new ApplicationUserStore(appDbContext);
            var userManager = new ApplicationUserManager(userStore);
            var user = userManager.Find(lvm.UserName, lvm.Password);
            if(user!=null)
            {
                var authenticationManager = HttpContext.GetOwinContext().Authentication;
                var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                authenticationManager.SignIn(new AuthenticationProperties(), userIdentity);
                return RedirectToAction("Index", "Home");    

            }
            else
            {
                ModelState.AddModelError("My Error", "Sai ten tai khoan hoac mat khau");
                return View();
            }
        }
        public ActionResult Logout()
        {
            var authenticationManager = HttpContext.GetOwinContext().Authentication;
            authenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }
        
    }
}