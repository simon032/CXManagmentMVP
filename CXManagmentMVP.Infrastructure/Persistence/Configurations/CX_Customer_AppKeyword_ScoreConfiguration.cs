using CXManagmentMVP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CXManagmentMVP.Infrastructure.Persistence.Configurations
{
    public class CX_Customer_AppKeyword_ScoreConfiguration : IEntityTypeConfiguration<CX_Customer_AppKeyword_Score>
    {
        public void Configure(EntityTypeBuilder<CX_Customer_AppKeyword_Score> builder)
        {
            builder.HasKey(e => e.CXCAKScoreID);

            builder.Property(e => e.CXCAKCalculatedScore);

            builder.Property(e => e.CXCAKCalculatedDate);
        }
    }
}
