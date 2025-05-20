using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace CXManagmentMVP.Infrastructure.Persistence
{
    public class CXManagementDbContextFactory : IDesignTimeDbContextFactory<CXManagementDbContext>
    {
        public CXManagementDbContext CreateDbContext(string[] args)
        {
            //var optionsBuilder = new DbContextOptionsBuilder<CXManagementDbContext>();

            //// Use your actual connection string here or from configuration
            //optionsBuilder.UseSqlServer("Server=.;Database=CXManagment_TEST;Trusted_Connection=True;TrustServerCertificate=true;MultipleActiveResultSets=true");

            //return new CXManagementDbContext(optionsBuilder.Options);
            var basePath = Path.Combine(Directory.GetCurrentDirectory(), "../CXManagement.API");

            // Load configuration from CXManagement.API/appsettings.json
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<CXManagementDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new CXManagementDbContext(optionsBuilder.Options);
        }
    }
}
