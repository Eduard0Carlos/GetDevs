using MvcInterface.Models.Announcement;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MvcInterface.Models
{
    public class CandidateHeaderAnnouncementViewModel
    {
        [JsonPropertyName("$values")]
        public CandidateAnnouncementViewModel[] Value { get; set; }
    }
    public class CandidateAnnouncementViewModel
    {
        [JsonPropertyName("registered")]
        public bool Registered { get; set; }
        [JsonPropertyName("announcement")]
        public AnnouncementViewModel Announcement { get; set; }
    }
}
