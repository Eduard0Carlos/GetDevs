namespace Domain.Entities
{
    public class CandidateAnnoucement
    {
        public bool Registered { get; protected set; }
        public Candidate Candidate { get; protected set; }
        public Announcement Announcement { get; protected set; }

        public CandidateAnnoucement() { }

        public CandidateAnnoucement(Candidate candidate, Announcement announcement)
        {
            Candidate = candidate;
            Announcement = announcement;
        }
    }
}
