using System;

namespace MvcInterface.Models.Announcement
{
    public class AnnouncementViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int AvaibleVacancy { get; set; }
        public DateTime AnnouncementDate { get; set; }
        public DateTime ExpiredDate { get; set; }
    }
}
