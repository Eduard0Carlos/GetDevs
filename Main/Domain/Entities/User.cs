namespace Domain.Entities
{
    public class User : EntityBase
    {
        public string Email { get; protected set; }
        public string Password { get; protected set; }
        public int? CompanyId { get; protected set; }
        public Company Company { get; protected set; }
        public int? CandidateId { get; protected set; }
        public Candidate Candidate { get; protected set; }

        protected User() { }

        public User(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public User SetCompanyId(int companyId)
        {
            this.CompanyId = companyId;
            return this;
        }

        public User SetCandidate(int candidateId)
        {
            this.CandidateId = candidateId;
            return this;
        }
    }
}
