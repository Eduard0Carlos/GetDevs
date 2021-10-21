using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

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
        [JsonIgnore]
        public Company Company { get; protected set; }
        public int CompanyId { get; protected set; }
        [JsonIgnore]
        public ICollection<CandidateAnnouncement> CandidateAnnouncements { get; protected set; }

        public int RequiredCandidates
        {
            get => AvaibleVacancy * 2;
        }

        protected Announcement() { }

        public Announcement(string title, string description, Skill skillRequired, Language languagesRequired, Degree degreesRequired, int avaibleVacancy, DateTime announcementDate, DateTime expiredDate)
        {
            Title = title;
            Description = description;
            SkillRequired = skillRequired;
            LanguagesRequired = languagesRequired;
            DegreesRequired = degreesRequired;
            AvaibleVacancy = avaibleVacancy;
            AnnouncementDate = announcementDate;
            ExpiredDate = expiredDate;
        }

        public Announcement SetCompanyId(int companyId)
        {
            this.CompanyId = companyId;
            return this;
        }

        public override bool Equals(object obj) =>
            (obj as Announcement).Id == this.Id;
    }
}
