using CXManagmentMVP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CXManagmentMVP.Infrastructure.Persistence.Configurations
{
    public class CX_ApplicationConfiguration : IEntityTypeConfiguration<CX_Application>
    {
        public void Configure(EntityTypeBuilder<CX_Application> builder)
        {
            builder.HasKey(e => e.CXAID);

            builder.Property(e => e.CXAName)
                .HasMaxLength(200);

            builder.HasMany(e => e.ApplicationKeywords)
                .WithOne(k => k.Application)
                .HasForeignKey(k => k.CXASID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(e => e.JourneyEvents)
                .WithOne(j => j.Application)
                .HasForeignKey(j => j.CXASID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}