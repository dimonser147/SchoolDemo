using SchoolDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.DirectoryServices.AccountManagement;
using System.Configuration;
using SchoolDemo.Business.Account;
using Microsoft.Practices.Unity;
using System.Security.Claims;

namespace SchoolDemo.Controllers
{
    public class AccountController : BaseController
    {
        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            // validate input data
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            // validate credentials
            string accountType = AccountManager.Instance.GetAccountType(model.Username).ToString();
            IAccountProvider accountProvider = Container.Resolve<IAccountProvider>(accountType);
            if (!accountProvider.CheckCredentials(model))
            {
                ModelState.AddModelError("", "Invalid credentials.");
                return View(model);
            }
            // sign in user
            var identity = new ClaimsIdentity(new[] {
                new Claim("MyClaimName", model.Username),
                new Claim("MyClaimType", accountType),                
            }, "ApplicationCookie");
            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;
            authManager.SignIn(identity);
            // redirect to an appropriate page
            return RedirectToAction(accountProvider.DefaultAction, accountProvider.DefaultController);
        }

        [HttpPost]
        public async Task<ActionResult> LogOff()
        {
            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;
            authManager.SignOut();
            return RedirectToAction("Login");
        }
    }
}