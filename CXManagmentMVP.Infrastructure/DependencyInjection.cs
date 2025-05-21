using CXManagement.Application.Interfaces;
using CXManagmentMVP.Domain.Options;
using CXManagmentMVP.Infrastructure.Persistence;
using CXManagmentMVP.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace CXManagmentMVP.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection service)
        {
            service.AddDbContext<CXManagementDbContext>((provider, options) =>
            {
                options.UseSqlServer(provider.GetRequiredService<IOptionsSnapshot<ConnectionStringOptions>>().Value.DefaultConnection);
            });


            service.AddScoped<IApplicationRepository, ApplicationRepository>();
            service.AddScoped<IApplicationKeywordRepository, ApplicationKeywordRepository>();
            service.AddScoped<ICustomerRepository, CustomerRepository>();
            service.AddScoped<ICustomerAppKeywordScoreRepository, CustomerAppKeywordScoreRepository>();
            service.AddScoped<ICustomerAppKeywordValueRepository, CustomerAppKeywordValueRepository>();
            service.AddScoped<IJourneyEventRepository, JourneyEventRepository>();
            service.AddScoped<IKeywordRepository, KeywordRepository>();



            return service;
        }
    }
}
