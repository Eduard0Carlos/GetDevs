namespace Domain.Entities
{
    public class CandidateAnnoucement
    {
        public bool Registered { get; protected set; }
        public Candidate Candidate { get; protected set; }
        public Announcement Announcement { get; protected set; }

        protected CandidateAnnoucement() { }

        public CandidateAnnoucement(bool registered, Candidate candidate, Announcement announcement)
        {
            Registered = registered;
            Candidate = candidate;
            Announcement = announcement;
        }
    }
}
