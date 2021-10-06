using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebRankingML
{
    public class AIResume
    {
        public uint Label { get; set; }
        public uint GroupId { get; protected set; }
        public float Skills { get; protected set; }
        public float Educations { get; protected set; }
        public float Idioms { get; protected set; }
        public float BusinessBonds { get; protected set; }
    }
}
