using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessObject.Mapping
{
    internal class ResumeMapConfig : IEntityTypeConfiguration<Resume>
    {
        public void Configure(EntityTypeBuilder<Resume> builder)
        {
            builder.Property(r => r.Skills).IsRequired();
            
            builder.HasOne(r => r.Candidate).WithOne(p => p.Resume).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(r => r.Idioms).WithMany(i => i.Resumes);
            builder.HasMany(r => r.Educations).WithMany(e => e.Resumes);
            builder.HasMany(r => r.BusinessBonds).WithMany(b => b.Resumes);
        }
    }
}
