using Microsoft.Practices.Unity;
using ShareYourTrip.Business;
using ShareYourTrip.Data.Context;
using ShareYourTrip.Data.IRepositories;
using ShareYourTrip.Data.Repositories;
using System.Web.Http;
using Unity.WebApi;

namespace ShareYourTrip.WebAPI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterType<IShareYourTripService, ShareYourTripService>();
            //container.RegisterType<ShareYourTripContext>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}