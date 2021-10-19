using Domain.Entities;
using System;

namespace WebAPI.Models
{
    public class CandidateRegisterModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get;  set; }
        public string Cpf { get; set; }
        public string Cep { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }

        public Candidate ConvertToCandidate()
        {
            return new Candidate(
                this.Name,
                this.Cpf,
                this.Cep,
                this.PhoneNumber,
                this.BirthDate
                );
        }

        public User ConvertToUser()
        {
            return new User(this.Email, this.Password);
        }
    }
}
