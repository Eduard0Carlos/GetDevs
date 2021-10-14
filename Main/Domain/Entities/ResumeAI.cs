namespace Domain.Entities
{
    public class ResumeAI
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
