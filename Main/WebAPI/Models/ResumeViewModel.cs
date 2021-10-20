using Domain.Entities;
using Domain.Enums;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public class ResumeViewModel
    {
        public ICollection<string> Skills { get; protected set; }
        public ICollection<Education> Educations { get; protected set; }
        public ICollection<string> Languages { get; protected set; }
        public ICollection<BusinessBondViewModel> BusinessBonds { get; protected set; }
    }
}
