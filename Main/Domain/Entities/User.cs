namespace Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? CompanyId { get; set; }
        public Company Company { get; set; }
        public int? CandidateId { get; set; }
        public Candidate Candidate { get; set; }
    }
}
