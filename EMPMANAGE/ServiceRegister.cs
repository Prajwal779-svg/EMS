using System.Reflection;
using EMPMANAGE.Application;
using EMPMANAGE.Database;
using EMPMANAGE.Domain.Infrastructure;

namespace EMPMANAGE
{
    public static class ServiceRegister
    {
        public static IServiceCollection AddApplicationServices(
           this IServiceCollection @this)
        {
            var serviceType = typeof(Service);
            var definedTypes = serviceType.Assembly.DefinedTypes;

            var services = definedTypes
                .Where(x => x.GetTypeInfo().GetCustomAttribute<Service>() != null);

            foreach (var service in services)
            {
                @this.AddTransient(service);
            }
            @this.AddScoped<IEmployeeManager,EmployeeManager>();
            return @this;
        }
    }
}
