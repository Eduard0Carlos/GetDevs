using System.Text.Json.Serialization;

namespace MvcInterface.Models.Company
{
    public class CompanyViewModel
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("url")]
        public string Url { get; set; }
        [JsonPropertyName("sector")]
        public string Sector { get; set; }
        [JsonPropertyName("cnpj")]
        public string Cnpj { get; set; }
        [JsonPropertyName("companySize")]
        public int CompanySize { get; set; }
        [JsonPropertyName("logoImageUrl")]
        public string LogoImageUrl { get; set; }
        [JsonPropertyName("slogan")]
        public string Slogan { get; set; }
    }
}
