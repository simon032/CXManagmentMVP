using CXManagmentMVP.Domain.Entities;
using CXManagmentMVP.Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace CXManagmentMVP.Infrastructure.Persistence
{
    public class CXManagementDbContext : DbContext
    {
        public CXManagementDbContext(DbContextOptions<CXManagementDbContext> options)
            : base(options)
        {
        }

        public DbSet<CX_Application> Applications { get; set; }
        public DbSet<CX_Application_Keyword> ApplicationKeywords { get; set; }
        public DbSet<CX_Customer> Customers { get; set; }
        public DbSet<CX_Customer_AppKeyword_Score> CustomerAppKeywordScores { get; set; }
        public DbSet<CX_Customer_AppKeyword_Value> CustomerAppKeywordValues { get; set; }
        public DbSet<CX_JourneyEvent> JourneyEvents { get; set; }
        public DbSet<CX_Keyword> Keywords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CX_ApplicationConfiguration());
            modelBuilder.ApplyConfiguration(new CX_Application_KeywordConfiguration());
            modelBuilder.ApplyConfiguration(new CX_CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new CX_Customer_AppKeyword_ScoreConfiguration());
            modelBuilder.ApplyConfiguration(new CX_Customer_AppKeyword_ValueConfiguration());
            modelBuilder.ApplyConfiguration(new CX_JourneyEventConfiguration());
            modelBuilder.ApplyConfiguration(new CX_KeywordConfiguration());
        }
    }
}