using MediatR.NotificationPublishers;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CXManagement.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationDI(this IServiceCollection service)
        {
            var applicationAssembly = Assembly.GetExecutingAssembly();
            var useCasesAssembly = typeof(CXManagement.Application.UseCases.CustomerAppKeywordValue.GetCustomerAppKeywordValueViewByCustomerIdQueryHandler).Assembly;

            service.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
                cfg.RegisterServicesFromAssembly(useCasesAssembly);
                cfg.NotificationPublisher = new TaskWhenAllPublisher();

            });


            return service;
        }
    }
}
