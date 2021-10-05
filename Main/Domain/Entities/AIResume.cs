using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class AIResume : EntityBase
    {
        public int GroupId{ get; protected set; }
        public float Skills { get; protected set; }
        public float Educations { get; protected set; }
        public float Idioms { get; protected set; }
        public float BusinessBonds { get; protected set; }
    }
}
