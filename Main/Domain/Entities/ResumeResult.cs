namespace Domain.Entities
{
    public class ResumeResult
    {
        public uint Id { get; set; }
        public uint GroupId { get; set; }
        public uint Label { get; set; }
        public float Score { get; set; }
        public float[] Features { get; set; }
    }

    public static class ResumeResultExtension
    {
        public static Resume ConvertToResume(this ResumeResult resumeResult, Resume resume) =>
            resume.SetScore(resumeResult.Score);
    }
}
