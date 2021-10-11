using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessObject.Mapping
{
    internal class CandidateMapConfig : IEntityTypeConfiguration<Candidate>
    {
        public void Configure(EntityTypeBuilder<Candidate> builder)
        {
            builder.Property(p => p.Name).IsRequired().IsUnicode(false).HasMaxLength(70);
            builder.Property(p => p.Cpf).IsRequired().IsUnicode(false).IsFixedLength().HasMaxLength(11);
            builder.Property(p => p.PhoneNumber).IsRequired().HasMaxLength(13).IsUnicode();
            builder.Property(p => p.BirthDate).IsRequired();
            builder.Property(p => p.Cep).IsRequired().IsFixedLength().HasMaxLength(8).IsUnicode(false);

            builder.HasOne(p => p.Resume).WithOne(r => r.Candidate).OnDelete(DeleteBehavior.NoAction);
            //builder.HasMany(p => p.Announcements).WithMany(a => a.Candidates);
        }
    }
}
