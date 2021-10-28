using Domain.Entities;

namespace WebAPI.Models
{
    public class CandidateAnnouncementViewModel
    {
        public bool Registered { get; set; }
        public AnnouncementRegisterViewModel Announcement { get; set; }
    }

    public static class CandidateExtension
    {
        public static CandidateAnnouncementViewModel ConvertToCandidateAnnouncementViewModel(this CandidateAnnouncement model)
        {
            return new CandidateAnnouncementViewModel
            {
                Registered = model.Registered,
                Announcement = new AnnouncementRegisterViewModel
                {
                    Id = model.Announcement.Id,
                    Title = model.Announcement.Title,
                    Description = model.Announcement.Description,
                    SkillRequired = model.Announcement.SkillRequired.ToString().Split(", "),
                    LanguagesRequired = model.Announcement.LanguagesRequired.ToString().Split(", "),
                    DegreesRequired = model.Announcement.DegreesRequired.ToString().Split(", "),
                    AvaibleVacancy = model.Announcement.AvaibleVacancy,
                    AnnouncementDate = model.Announcement.AnnouncementDate,
                    ExpiredDate = model.Announcement.ExpiredDate
                }
            };
        }
    }
}
