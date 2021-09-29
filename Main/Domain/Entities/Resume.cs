using Domain.Enums;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Resume
    {
        public int Id { get; set; }
        public Person Person { get; set; }
        public int PersonId { get; set; }
        public Skill Skills { get; set; }
        public ICollection<Education> Educations { get; set; }
        public ICollection<Idiom> Idioms { get; set; }
        public ICollection<BusinessBond> BusinessBonds { get; set; }
    }
}
