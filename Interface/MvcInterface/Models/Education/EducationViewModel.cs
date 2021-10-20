using System;
using System.Text.Json.Serialization;

namespace MvcInterface.Models
{
    public class EducationViewModel
    {
        public string InstitutionName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Degree { get; set; }
    }
}
