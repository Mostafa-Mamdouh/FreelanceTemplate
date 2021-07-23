using AutoMapper;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using System.Web.Http;
using Unity;
using Unity.WebApi;
using Vendor.Portal.Code;

namespace Vendor.Portal
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType(typeof(IGenericRepository<>), typeof( GenericRepository<>));
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            var mapper = AutoMapperProfile.InitializeAutoMapper().CreateMapper();
            container.RegisterInstance<IMapper>(mapper);



            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}