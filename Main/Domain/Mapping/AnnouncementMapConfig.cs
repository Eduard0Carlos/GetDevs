using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessObject.Mapping
{
    internal class AnnouncementMapConfig : IEntityTypeConfiguration<Announcement>
    {
        public void Configure(EntityTypeBuilder<Announcement> builder)
        {
            builder.Property(a => a.Title).IsRequired().HasMaxLength(100).IsUnicode(false);
            builder.Property(a => a.Description).IsRequired().HasMaxLength(1234).IsUnicode(false);
            builder.Property(a => a.AnnouncementDate).IsRequired();
            builder.Property(a => a.SkillRequired).IsRequired();

            builder.HasMany(a => a.EducationsRequired).WithMany(e => e.Announcements);
            builder.HasMany(a => a.IdiomsRequired).WithMany(e => e.Announcements);
            builder.HasOne(a => a.Company).WithMany(c => c.Announcements).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
