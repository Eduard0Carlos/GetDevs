using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure
{
    internal class CompanyMapConfig : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.Property(c => c.Name).IsRequired().IsUnicode(false).HasMaxLength(70);
            builder.Property(c => c.Url).IsRequired().IsUnicode(false).HasMaxLength(600);
            builder.Property(c => c.CompanySize).IsRequired();
            builder.Property(c => c.Slogan).IsRequired().IsUnicode(false).HasMaxLength(100);
            builder.Property(c => c.Sector).IsRequired().IsUnicode(false).HasMaxLength(100);
            builder.Property(c => c.LogoImageUrl).IsRequired().IsUnicode(false).HasMaxLength(600);

            builder.HasMany(c => c.Announcements).WithOne(a => a.Company).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
