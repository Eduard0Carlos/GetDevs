using System;

namespace MvcInterface.Models
{
    public class BusinessBondViewModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string CompanyName { get; set; }
        public string Role { get; set; }
    }
}
