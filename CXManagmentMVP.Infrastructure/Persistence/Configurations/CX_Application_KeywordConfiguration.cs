using CXManagmentMVP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CXManagmentMVP.Infrastructure.Persistence.Configurations
{
    public class CX_Application_KeywordConfiguration : IEntityTypeConfiguration<CX_Application_Keyword>
    {
        public void Configure(EntityTypeBuilder<CX_Application_Keyword> builder)
        {
            builder.HasKey(e => e.CXAKID);

            builder.Property(e => e.CXAKWeight);

            builder.HasOne(e => e.Application)
                .WithMany(a => a.ApplicationKeywords)
                .HasForeignKey(e => e.CXASID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Keyword)
                .WithMany(k => k.ApplicationKeywords)
                .HasForeignKey(e => e.CXKeywordID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(e => e.Values)
                .WithOne(v => v.ApplicationKeyword)
                .HasForeignKey(v => v.CXASKID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(e => e.Scores)
                .WithOne(s => s.ApplicationKeyword)
                .HasForeignKey(s => s.CXASKID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
