﻿using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Candidate : EntityBase
    {
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Cep { get; protected set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; protected set; }
        public DateTime BirthDate { get; protected set; }
        public Resume Resume { get; set; }
        public int ResumeId { get; set; }
        public ICollection<CandidateAnnoucement> Announcements { get; set; }

        public int Age { get; }

        public Candidate() { }

        public Candidate(string name, string cpf, string cep, string phoneNumber, DateTime birthDate)
        {
            this.Name = name;
            this.Cpf = cpf;
            this.Cep = cep;
            this.PhoneNumber = phoneNumber;
            this.BirthDate = birthDate;
        }

        public virtual Candidate SetName(string name)
        {
            this.Name = name;
            return this;
        }

        public virtual void SetPhoneNumber(string phoneNumber)
        {
            this.PhoneNumber = phoneNumber;
        }
    }
}
