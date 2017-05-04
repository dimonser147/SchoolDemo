using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolDemo.Models;
using System.DirectoryServices.AccountManagement;
using System.Configuration;

namespace SchoolDemo.Business.Account
{
    class StudentsAccountProvider : AccountProvider
    {
        public override AccountType Type
        {
            get
            {
                return AccountType.Students;
            }
        }

        public override string DefaultAction
        {
            get
            {
                return "Students";
            }
        }
    }
}