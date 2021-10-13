using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure
{
    internal class CourseMapConfig : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.Property(c => c.Name).IsRequired().IsUnicode(false).HasMaxLength(100);
            builder.Property(c => c.Degree).IsRequired();
            builder.Property(c => c.InstitutionName).IsRequired().IsUnicode(false).HasMaxLength(100);
        }
    }
}
