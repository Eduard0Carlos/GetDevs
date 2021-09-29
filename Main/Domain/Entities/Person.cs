using System;

namespace Domain.Entities
{
    public class Person
    {
        public int Id { get; protected set; }
        public string Name { get; protected set; }
        public string Cpf { get; protected set; }
        public string Cep { get; protected set; }
        public string PhoneNumber { get; protected set; }
        public DateTime BirthDate { get; protected set; }
        public Resume Resume { get; set; }
        public int ResumeId { get; set; }

        public int Age { get; }

        public Person() { }

        public Person(string name, string cpf, string cep, string phoneNumber, DateTime birthDate)
        {
            this.Name = name;
            this.Cpf = cpf;
            this.Cep = cep;
            this.PhoneNumber = phoneNumber;
            this.BirthDate = birthDate;
            var test = this.Name;
            this.Name = "ljasdfghagfas";
        }

        public virtual void SetName(string name)
        {
            this.Name = name;
        }

        public virtual void SetPhoneNumber(string phoneNumber)
        {
            this.PhoneNumber = phoneNumber;
        }
    }
}
