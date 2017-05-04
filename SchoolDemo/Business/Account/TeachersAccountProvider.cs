using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolDemo.Models;
using System.DirectoryServices.AccountManagement;
using System.Configuration;

namespace SchoolDemo.Business.Account
{
    class TeachersAccountProvider : AccountProvider
    {
        public string ActiveDirectoryDomainName { get; set; } = ConfigurationManager.AppSettings["ActiveDirectoryDomainName"];

        public override AccountType Type
        {
            get
            {
                return AccountType.Teachers;
            }
        }

        public override string DefaultAction
        {
            get
            {
                return "Teachers";
            }
        }

        public override bool CheckCredentials(LoginViewModel login)
        {
            using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, ActiveDirectoryDomainName))
            {
                bool isValid = pc.ValidateCredentials(login.Username, login.Password);
                return isValid;
            }
        }
    }
}