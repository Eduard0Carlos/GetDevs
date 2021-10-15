using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure
{
    internal class AnnouncementMapConfig : IEntityTypeConfiguration<Announcement>
    {
        public void Configure(EntityTypeBuilder<Announcement> builder)
        {
            builder.Property(a => a.Title).IsRequired().HasMaxLength(100).IsUnicode(false);
            builder.Property(a => a.Description).IsRequired().HasMaxLength(1234).IsUnicode(false);
            builder.Property(a => a.AnnouncementDate).IsRequired();
            builder.Property(a => a.SkillRequired).IsRequired();

            builder.HasOne(a => a.Company).WithMany(c => c.Announcements).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(a => a.CandidateAnnouncements).WithOne(c => c.Announcement).HasForeignKey(c => c.AnnouncementId);
        }
    }
}
