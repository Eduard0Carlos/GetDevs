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

        public User(string email, string password, int? companyId, Company company, int? candidateId, Candidate candidate)
        {
            Email = email;
            Password = password;
            CompanyId = companyId;
            Company = company;
            CandidateId = candidateId;
            Candidate = candidate;
        }
    }
}
