using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure
{
    internal class ResumeMapConfig : IEntityTypeConfiguration<Resume>
    {
        public void Configure(EntityTypeBuilder<Resume> builder)
        {
            builder.Property(r => r.Skills).IsRequired();
            
            builder.HasMany(r => r.Educations).WithMany(e => e.Resumes);
            builder.HasMany(r => r.BusinessBonds).WithMany(b => b.Resumes);
        }
    }
}
