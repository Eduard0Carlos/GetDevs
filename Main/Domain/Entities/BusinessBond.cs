using System;

namespace Domain.Entities
{
    public class BusinessBond
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string CompanyName { get; set; }
        public string Role { get; set; }
    }
}
