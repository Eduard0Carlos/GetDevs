using System;
using System.Text.Json.Serialization;

namespace MvcInterface.Models
{
    public class CandidateViewModel
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("cpf")]
        public string Cpf { get; set; }
        [JsonPropertyName("cep")]
        public string Cep { get; set; }
        [JsonPropertyName("phoneNumber")]
        public string PhoneNumber { get; set; }
        [JsonPropertyName("birthDate")]
        public DateTime BirthDate { get; set; }
    }
}
