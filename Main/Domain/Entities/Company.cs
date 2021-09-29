using System.Collections.Generic;

namespace Domain.Entities
{
    public class Company : EntityBase
    {
        public int Id { get; protected set; }
        public string Name { get; protected set; }
        public string Url { get; protected set; }
        public string Sector { get; protected set; }
        public int CompanySize { get; protected set; }
        public string LogoImageUrl { get; protected set; }
        public string Slogan { get; protected set; }
        public ICollection<Announcement> Announcements { get; protected set; }
    }
}
