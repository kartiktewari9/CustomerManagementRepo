using System.Reflection;
using Autofac;
using Module = Autofac.Module;
using CustomerManagement.Data;

namespace CustomerManagementWebsite.Infrastructure.Modules
{
    public class DatabaseModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CustomerManagementDbContext>().As<ICustomerManagementDbContext>().InstancePerRequest();
        }
    }
}