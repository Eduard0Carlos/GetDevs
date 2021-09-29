using Domain.Enums;
using System;

namespace Domain.Entities
{
    public class Education
    {
        public int Id { get; set; }
        public string InstitutionName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Degree Degree { get; set; }
    }
}
