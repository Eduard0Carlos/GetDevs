using Domain.Enums;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Announcement : EntityBase
    {
        public string Title { get; protected set; }
        public string Description { get; protected set; }
        public Skill SkillRequired { get; protected set; }
        public Language LanguagesRequired { get; protected set; }       
        public Degree DegreesRequired { get; protected set; }
        public int AvaibleVacancy { get; protected set; }
        public DateTime AnnouncementDate { get; protected set; }
        public DateTime ExpiredDate { get; protected set; }
        public Company Company { get; protected set; }
        public int CompanyId { get; protected set; }
        public ICollection<CandidateAnnouncement> Candidates { get; protected set; }

        public int RequiredCandidates
        {
            get => AvaibleVacancy * 2;
        }

        protected Announcement() { }

        public Announcement(string title, string description, Skill skillRequired, Language languagesRequired, Degree degreesRequired, int avaibleVacancy, DateTime announcementDate, DateTime expiredDate, Company company, int companyId, ICollection<CandidateAnnouncement> candidates)
        {
            Title = title;
            Description = description;
            SkillRequired = skillRequired;
            LanguagesRequired = languagesRequired;
            DegreesRequired = degreesRequired;
            AvaibleVacancy = avaibleVacancy;
            AnnouncementDate = announcementDate;
            ExpiredDate = expiredDate;
            Company = company;
            CompanyId = companyId;
            Candidates = candidates;
        }

        public override bool Equals(object obj) =>
            (obj as Announcement).Id == this.Id;
    }
}
