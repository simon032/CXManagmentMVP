using CXManagmentMVP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CXManagmentMVP.Infrastructure.Persistence.Configurations
{
    public class CX_JourneyEventConfiguration : IEntityTypeConfiguration<CX_JourneyEvent>
    {
        public void Configure(EntityTypeBuilder<CX_JourneyEvent> builder)
        {
            builder.HasKey(e => e.CXCJEID);

            builder.Property(e => e.CXJEKeywordIDs)
                .HasMaxLength(500);

            builder.Property(e => e.CXJEScoreSnapshot);

            builder.Property(e => e.CXJERequestedDate);
            builder.Property(e => e.CXJEFromDate);
            builder.Property(e => e.CXJEToDate);
            builder.Property(e => e.CreateAt).IsRequired();

            builder.HasOne(e => e.Application)
                .WithMany(a => a.JourneyEvents)
                .HasForeignKey(e => e.CXASID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
