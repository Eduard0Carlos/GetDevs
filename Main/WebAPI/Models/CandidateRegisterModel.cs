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
    }

    public static class CandidateRegisterModelExtension
    {
        public static Candidate ConvertToCandidate(this CandidateRegisterModel registerModel)
        {
            return new Candidate(
                registerModel.Name,
                registerModel.Cpf,
                registerModel.Cep,
                registerModel.PhoneNumber,
                registerModel.BirthDate
                );
        }

        public static User ConvertToUser(this CandidateRegisterModel registerModel)
        {
            return new User(registerModel.Email, registerModel.Password);
        }
    }
}
