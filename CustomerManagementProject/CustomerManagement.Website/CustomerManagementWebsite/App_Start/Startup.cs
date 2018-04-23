using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Autofac;
using AutoMapper;
using CustomerManagement.Common.Converters;
using CustomerManagementWebsite.Infrastructure.Modules;
using Autofac.Integration.Mvc;
using System.Web.Mvc;

namespace CustomerManagementWebsite.App_Start
{
    public class Startup
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                //Common Mappers
                Bootstrap.InitMappingConfig(cfg);
            });

            var builder = new ContainerBuilder();

            builder.RegisterAssemblyModules(typeof(DatabaseModule).Assembly, typeof(RepositoryModule).Assembly, typeof(ServiceModule).Assembly);

            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}