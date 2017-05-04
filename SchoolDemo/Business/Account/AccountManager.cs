using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace SchoolDemo.Business.Account
{
    public class AccountManager
    {
        private static readonly Lazy<AccountManager> _instance
             = new Lazy<AccountManager>(() => new AccountManager());


        private AccountManager() { }

        public static AccountManager Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        public AccountType GetAccountType(string username)
        {
            string domain = ConfigurationManager.AppSettings["ActiveDirectoryDomainName"].ToLowerInvariant();
            username = username.ToLowerInvariant();
            if(username.Contains(domain))
            {
                return AccountType.Teachers;
            }
            // TODO: add logic to identify parents account 
            return AccountType.Students;
        }
    }
}