using System;

namespace MvcInterface.Models.Announcement
{
    public class AnnouncementRegisterViewModel
    {
        public int Id { get; protected set; }
        public string Title { get; protected set; }
        public string Description { get; protected set; }
        public string[] SkillRequired { get; protected set; }
        public string[] LanguagesRequired { get; protected set; }
        public string[] DegreesRequired { get; protected set; }
        public int AvaibleVacancy { get; protected set; }
        public DateTime AnnouncementDate { get; protected set; }
        public DateTime ExpiredDate { get; protected set; }
    }
}
