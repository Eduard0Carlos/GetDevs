using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Candidate : EntityBase
    {
        public string Name { get; protected set; }
        public string Cpf { get; protected set; }
        public string Cep { get; protected set; }
        public string Email { get; protected set; }
        public string Password { get; protected set; }
        public string PhoneNumber { get; protected set; }
        public DateTime BirthDate { get; protected set; }
        public Resume Resume { get; protected set; }
        public int ResumeId { get; protected set; }
        public ICollection<CandidateAnnouncement> CandidateAnnouncements { get; set; }

        public int Age { get; }

        protected Candidate() { }

        public Candidate(string name, string cpf, string cep, string phoneNumber, DateTime birthDate, string email, string password)
        {
            Name = name;
            Cpf = cpf;
            Cep = cep;
            PhoneNumber = phoneNumber;
            BirthDate = birthDate;
            Email = email;
            Password = password;
        }

        public virtual Candidate SetName(string name)
        {
            this.Name = name;
            return this;
        }

        public virtual Candidate SetPhoneNumber(string phoneNumber)
        {
            this.PhoneNumber = phoneNumber;
            return this;
        }
    }
}
