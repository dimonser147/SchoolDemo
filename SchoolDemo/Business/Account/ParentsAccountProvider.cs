using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolDemo.Models;
using System.DirectoryServices.AccountManagement;
using System.Configuration;

namespace SchoolDemo.Business.Account
{
    class ParentsAccountProvider : AccountProvider
    {
        
        public override AccountType Type
        {
            get
            {
                return AccountType.Parents;
            }
        }

        public override string DefaultAction
        {
            get
            {
                return "Parents";
            }
        }

        public override bool CheckCredentials(LoginViewModel login)
        {
            string authMethod = ConfigurationManager.AppSettings["ParentsAuthMethod"];
            return string.Equals(authMethod, "ActiveDirectory", StringComparison.OrdinalIgnoreCase)
                ? CheckAdCredentials(login) 
                : CheckDbCredentials(login);
        }
    }
}