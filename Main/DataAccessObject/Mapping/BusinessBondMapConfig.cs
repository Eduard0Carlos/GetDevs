using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure
{
    internal class BusinessBondMapConfig : IEntityTypeConfiguration<BusinessBond>
    {
        public void Configure(EntityTypeBuilder<BusinessBond> builder)
        {
            builder.Property(b => b.CompanyName).IsRequired().IsUnicode(false).HasMaxLength(100);
            builder.Property(b => b.Role).IsRequired().IsUnicode(false).HasMaxLength(70);

            builder.HasMany(b => b.Resumes).WithMany(r => r.BusinessBonds);
        }
    }
}
