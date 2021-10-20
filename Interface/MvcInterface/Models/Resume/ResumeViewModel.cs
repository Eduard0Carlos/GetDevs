using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MvcInterface.Models
{
    public class ResumeViewModel
    {
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonPropertyName("score")]
        public float? Score { get; set; }
        [JsonPropertyName("skills")]
        public string[] Skills { get; set; }
        [JsonPropertyName("degrees")]
        public string[] Degrees { get; set; }
        [JsonPropertyName("educations")]
        public ICollection<EducationViewModel> Educations { get; set; }
        [JsonPropertyName("languages")]
        public string[] Languages { get; set; }
        [JsonPropertyName("businessBond")]
        public ICollection<BusinessBondViewModel> BusinessBonds { get; set; }
    }
}
