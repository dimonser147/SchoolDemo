using SchoolDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDemo.Business.Account
{
    interface IAccountProvider
    {
        bool CheckCredentials(LoginViewModel login);

        AccountType Type { get; }

        string DefaultController { get; }

        string DefaultAction{ get; }
    }
}
