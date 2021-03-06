﻿using System;
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
            return CheckAdCredentials(login);
        }
    }
}