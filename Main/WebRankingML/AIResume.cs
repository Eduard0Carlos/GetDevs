using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebRankingML
{
    public class AIResume
    {
        public uint Id { get; set; }
        public uint Label { get; set; }
        public uint GroupId { get; set; }
        public float Skills { get; set; }
        public float Educations { get; set; }
        public float Idioms { get; set; }
        public float BusinessBonds { get; set; }
    }
}
