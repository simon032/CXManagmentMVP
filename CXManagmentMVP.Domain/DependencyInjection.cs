using CXManagmentMVP.Domain.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CXManagmentMVP.Domain
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCoreDI(this IServiceCollection service, IConfiguration configuration)
        {
            service.Configure<ConnectionStringOptions>(configuration.GetSection(ConnectionStringOptions.SectionName));
            return service;
        }
    }
}
