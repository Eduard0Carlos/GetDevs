using Domain.Enums;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Resume : EntityBase    
    {
        public Candidate Candidate { get; protected set; }
        public int CandidateId { get; protected set; }
        public Skill Skills { get; protected set; }
        public ICollection<Education> Educations { get; protected set; }
        public ICollection<Idiom> Idioms { get; protected set; }
        public ICollection<BusinessBond> BusinessBonds { get; protected set; }
    }
}
