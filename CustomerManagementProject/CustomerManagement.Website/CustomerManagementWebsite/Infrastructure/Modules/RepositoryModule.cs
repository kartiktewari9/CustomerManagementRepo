using System.Linq;
using System.Reflection;
using Autofac;
using Module = Autofac.Module;
using CustomerManagement.Repositories;

namespace CustomerManagementWebsite.Infrastructure.Modules
{
    public class RepositoryModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly(), typeof(ICustomerRepository).Assembly).Where(x => x.Name.EndsWith("Repository")).AsImplementedInterfaces();
        }
    }
}