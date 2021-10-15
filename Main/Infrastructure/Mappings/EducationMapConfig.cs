using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure
{
    internal class EducationMapConfig : IEntityTypeConfiguration<Education>
    {
        public void Configure(EntityTypeBuilder<Education> builder)
        {
            builder.Property(e => e.InstitutionName).IsRequired().HasMaxLength(100).IsUnicode(false);
            builder.Property(e => e.StartDate).IsRequired();
            builder.Property(e => e.EndDate).IsRequired();
            builder.Property(e => e.Degree).IsRequired();
        }
    }
}
