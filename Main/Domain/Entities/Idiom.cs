using Domain.Enums;

namespace Domain.Entities
{
    public class Idiom
    {
        public int Id { get; set; }
        public Language Language { get; set; }
        public Proficiency ReadProficiency { get; set; }
        public Proficiency WriteProficiency { get; set; }
        public Proficiency SpeechProficiency { get; set; }
    }
}
