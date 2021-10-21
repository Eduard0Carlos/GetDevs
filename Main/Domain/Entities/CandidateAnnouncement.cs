﻿namespace Domain.Entities
{
    public class CandidateAnnouncement : EntityBase
    {
        public bool Registered { get; protected set; }
        public int CandidateId { get; protected set; }
        public Candidate Candidate { get; protected set; }
        public int AnnouncementId { get; protected set; }
        public Announcement Announcement { get; protected set; }

        protected CandidateAnnouncement() { }

        public CandidateAnnouncement(bool registered, int candidateId, int announcementId)
        {
            Registered = registered;
            CandidateId = candidateId;
            AnnouncementId = announcementId;
        }

        public void SetAnnouncementId(Announcement announcement)
        {
            this.Announcement = announcement;
        }

        public CandidateAnnouncement SetRegistered(bool registered)
        {
            this.Registered = registered;
            return this;
        }
    }
}
