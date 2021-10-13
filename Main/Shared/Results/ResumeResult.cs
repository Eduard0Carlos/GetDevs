namespace WebRankingML
{
    public class ResumeResult
    {
        public uint Id { get; set; }
        public uint GroupId { get; set; }
        public uint Label { get; set; }
        public float Score { get; set; }
        public float[] Features { get; set; }

    }
}
