using Microsoft.Practices.Unity;
using SchoolDemo.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolDemo.Controllers
{
    public class BaseController : Controller
    {
        public IUnityContainer Container => UnityConfig.GetConfiguredContainer();
    }
}