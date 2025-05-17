using CXManagement.Application;
using CXManagmentMVP.Domain;
using CXManagmentMVP.Infrastructure;

namespace CXManagement.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAppDI(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddApplicationDI().AddInfrastructureDI().AddCoreDI(configuration);
            return service;
        }
    }
}
