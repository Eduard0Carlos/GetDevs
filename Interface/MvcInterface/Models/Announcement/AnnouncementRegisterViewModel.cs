using System;

namespace MvcInterface.Models.Announcement
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
    }
}
