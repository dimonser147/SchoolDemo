using Microsoft.Practices.Unity;
using SchoolDemo.Business.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolDemo.App_Start
{
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below. Make sure to add a Microsoft.Practices.Unity.Configuration to the using statements.
            // container.LoadConfiguration();
            //container.RegisterType<AccountController>(new InjectionConstructor());
            //container.RegisterType<ManageController>(new InjectionConstructor());

            // TODO: Register your types here
            container
                .RegisterType<IAccountProvider, TeachersAccountProvider>(nameof(AccountType.Teachers))
                .RegisterType<IAccountProvider, ParentsAccountProvider>(nameof(AccountType.Parents))
                .RegisterType<IAccountProvider, StudentsAccountProvider>(nameof(AccountType.Students));
        }
    }
}