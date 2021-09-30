using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class BusinessBond : EntityBase
    {
        public DateTime StartDate { get; protected set; }
        public DateTime EndDate { get; protected set; }
        public string CompanyName { get; protected set; }
        public string Role { get; protected set; }
        public ICollection<Resume> Resumes { get; protected set; }
    }
}
