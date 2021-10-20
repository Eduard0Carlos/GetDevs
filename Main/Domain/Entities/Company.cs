using System.Collections.Generic;

namespace Domain.Entities
{
    public class Company : EntityBase
    {
        public string Name { get; protected set; }
        public string Url { get; protected set; }
        public string Sector { get; protected set; }
        public string Cnpj {  get; protected set; } 
        public int CompanySize { get; protected set; }
        public string LogoImageUrl { get; protected set; }
        public string Slogan { get; protected set; }
        public ICollection<Announcement> Announcements { get; protected set; }

        protected Company() { }

        public Company(string name, string url, string sector, string cnpj, int companySize, string slogan, string logoImageUrl)
        {
            LogoImageUrl = logoImageUrl;
            Name = name;
            Url = url;
            Sector = sector;
            Cnpj = cnpj;
            CompanySize = companySize;
            Slogan = slogan;
        }
    }
}
