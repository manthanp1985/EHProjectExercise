using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Unity.Mvc5;
using MaintainContacts.Services;

namespace MaintainContacts.Main
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            //container.LoadConfiguration();
            container.RegisterType<ILoggerRepository, LoggerRepository>();
            container.RegisterType<IContactRepository, ContactRepository>();
            container.RegisterType<IStatusRepository, StatusRepository>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}