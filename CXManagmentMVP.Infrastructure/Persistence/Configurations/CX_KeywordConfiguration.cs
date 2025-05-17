using CXManagmentMVP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CXManagmentMVP.Infrastructure.Persistence.Configurations
{
    public class CX_KeywordConfiguration : IEntityTypeConfiguration<CX_Keyword>
    {
        public void Configure(EntityTypeBuilder<CX_Keyword> builder)
        {
            builder.HasKey(e => e.CXKeywordID);

            builder.Property(e => e.CXKeywordName)
                .HasMaxLength(200);

            builder.Property(e => e.CXKeywordDescription)
                .HasMaxLength(1000);

            builder.Property(e => e.CXKeywordDataType)
                .HasMaxLength(50);

            builder.Property(e => e.CXKeywordScoringFormula)
                .HasMaxLength(500);

            builder.Property(e => e.CXKeywordIsActive);

            builder.HasMany(e => e.ApplicationKeywords)
                .WithOne(ak => ak.Keyword)
                .HasForeignKey(ak => ak.CXKeywordID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
