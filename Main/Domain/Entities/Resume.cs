using Domain.Enums;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Resume : EntityBase    
    {
        public Candidate Candidate { get; set; }
        public int CandidateId { get; protected set; }
        public Skill Skills { get; protected set; }
        public Degree Degrees { get; protected set; }
        public ICollection<Education> Educations { get; protected set; }
        public Language Languages { get; protected set; }
        public ICollection<BusinessBond> BusinessBonds { get; protected set; }

        protected Resume() { }

        public Resume(Candidate candidate, int candidateId, Skill skills, Degree degrees, ICollection<Education> educations, Language languages, ICollection<BusinessBond> businessBonds)
        {
            Candidate = candidate;
            CandidateId = candidateId;
            Skills = skills;
            Degrees = degrees;
            Educations = educations;
            Languages = languages;
            BusinessBonds = businessBonds;
        }
    }
}
