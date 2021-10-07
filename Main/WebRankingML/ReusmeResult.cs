using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebRankingML
{
    public class ReusmeResult
    {
        public uint Id { get; set; }
        public uint GroupId { get; set; }
        public uint Label { get; set; }
        public float Score { get; set; }
        public float[] Features { get; set; }

    }
}
