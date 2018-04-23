using System.Linq;
using System.Reflection;
using Autofac;
using Module = Autofac.Module;
using CustomerManagementServices;

namespace CustomerManagementWebsite.Infrastructure.Modules
{
    public class ServiceModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly(), typeof(ICustomerService).Assembly).Where(x => x.Name.EndsWith("Service")).AsImplementedInterfaces();
        }
    }
}