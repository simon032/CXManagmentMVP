using CXManagmentMVP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CXManagmentMVP.Infrastructure.Persistence.Configurations
{
    public class CX_Customer_AppKeyword_ValueConfiguration : IEntityTypeConfiguration<CX_Customer_AppKeyword_Value>
    {
        public void Configure(EntityTypeBuilder<CX_Customer_AppKeyword_Value> builder)
        {
            builder.HasKey(e => e.CXCAKVID);

            builder.Property(e => e.CXCAKVValueString)
                .HasMaxLength(500);

            builder.Property(e => e.CXCAKVAssignedDate);
        }
    }
}
