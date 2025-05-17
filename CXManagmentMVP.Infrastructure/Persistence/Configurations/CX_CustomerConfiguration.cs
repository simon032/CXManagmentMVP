using CXManagmentMVP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CXManagmentMVP.Infrastructure.Persistence.Configurations
{
    public class CX_CustomerConfiguration : IEntityTypeConfiguration<CX_Customer>
    {
        public void Configure(EntityTypeBuilder<CX_Customer> builder)
        {
            builder.HasKey(e => e.CXCustomerID);

            builder.Property(e => e.CXCustomerFullName)
                .HasMaxLength(250);

            builder.Property(e => e.CXCustomerEmail)
                .HasMaxLength(150);

            builder.Property(e => e.CXCustomerPhone)
                .HasMaxLength(50);

            builder.HasMany(e => e.Scores)
                .WithOne(s => s.Customer)
                .HasForeignKey(s => s.CXCustomerID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(e => e.Values)
                .WithOne(v => v.Customer)
                .HasForeignKey(v => v.CXCustomerID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
