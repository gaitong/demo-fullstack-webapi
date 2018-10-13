using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using HelloMVC;
using HelloMVC.Repositories;
using Service.Services;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using WebApi.Controllers;

namespace WebApi
{
    public class AutofacConfig
    {
        public static void Build()
        {
            var builder = new ContainerBuilder();
  
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<UsersController>();

            var container = builder.Build();
            container.Resolve<UsersController>();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            var resolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }
    }
}