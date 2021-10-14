namespace Domain.Entities
{
    public class CandidateAnnouncement : EntityBase
    {
        public bool Registered { get; protected set; }
        public Candidate Candidate { get; protected set; }
        public Announcement Announcement { get; protected set; }

        protected CandidateAnnouncement() { }

        public CandidateAnnouncement(bool registered, Candidate candidate, Announcement announcement)
        {
            Registered = registered;
            Candidate = candidate;
            Announcement = announcement;
        }
    }
}
