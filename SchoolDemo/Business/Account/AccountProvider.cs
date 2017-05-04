using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolDemo.Models;

namespace SchoolDemo.Business.Account
{
    abstract class AccountProvider : IAccountProvider
    {
        public virtual string DefaultAction { get; } = "Parents";

        public virtual string DefaultController { get; } = "Home";

        public abstract AccountType Type { get; }

        /// <summary>
        /// Check credentials via System Database
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public virtual bool CheckCredentials(LoginViewModel login)
        {
            return login.Username == "admin" && login.Password == "admin";
        }
    }
}