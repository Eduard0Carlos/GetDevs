using System;

namespace MvcInterface.Models
{
    public class CandidateSignUpViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Cep { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
