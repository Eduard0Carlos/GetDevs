using Domain.Entities;
using Domain.Enums;
using Shared.Extension;
using System;

namespace WebAPI.Models
{
    public class AnnouncementRegisterViewModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string[] SkillRequired { get; set; }
        public string[] LanguagesRequired { get; set; }
        public string[] DegreesRequired { get; set; }
        public int AvaibleVacancy { get; set; }
        public DateTime AnnouncementDate { get; set; }
        public DateTime ExpiredDate { get; set; }

        public Announcement ConvertToAnnouncement()
        {
            Language language = 0;
            foreach (var item in this.LanguagesRequired)
                language = language | item.ConvertToEnum<Language>();

            Skill skill = 0;
            foreach (var item in this.SkillRequired)
                skill = skill | item.ConvertToEnum<Skill>();

            Degree degree = 0;
            foreach (var item in this.DegreesRequired)
                degree = degree | item.ConvertToEnum<Degree>();


            return new Announcement(
                    Title,
                    Description,
                    skill,
                    language,
                    degree,
                    AvaibleVacancy,
                    AnnouncementDate,
                    ExpiredDate
                );
        }
    }
}
