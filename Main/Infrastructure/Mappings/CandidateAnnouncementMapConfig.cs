using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mappings
{
    public class CandidateAnnouncementMapConfig : IEntityTypeConfiguration<CandidateAnnouncement>
    {
        public void Configure(EntityTypeBuilder<CandidateAnnouncement> builder)
        {
            builder.HasKey(c => new { c.AnnouncementId, c.CandidateId});
        }
    }
}
