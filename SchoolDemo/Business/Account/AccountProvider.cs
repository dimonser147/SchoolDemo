using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolDemo.Models;
using System.DirectoryServices.AccountManagement;
using System.Configuration;

namespace SchoolDemo.Business.Account
{
    abstract class AccountProvider : IAccountProvider
    {
        public string ActiveDirectoryDomainName { get; set; } = ConfigurationManager.AppSettings["ActiveDirectoryDomainName"];

        public virtual string DefaultAction { get; } = "Parents";

        public virtual string DefaultController { get; } = "Home";

        public abstract AccountType Type { get; }

        /// <summary>
        /// Check credentials (System Database method is default)
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public virtual bool CheckCredentials(LoginViewModel login)
        {
            return CheckDbCredentials(login);
        }

        /// <summary>
        /// Check credentials via System Database
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        protected bool CheckDbCredentials(LoginViewModel login)
        {
            return login.Username == "admin" && login.Password == "admin";
        }

        /// <summary>
        /// Check credentials via Active Directory
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        protected bool CheckAdCredentials(LoginViewModel login)
        {
            using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, ActiveDirectoryDomainName))
            {
                bool isValid = pc.ValidateCredentials(login.Username, login.Password);
                return isValid;
            }
        }
    }
}