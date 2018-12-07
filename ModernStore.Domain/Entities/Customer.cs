using System;
using FluentValidator;
using ModernStore.Shared.Entities;

namespace ModernStore.Domain.Entities
{
    public class Customer : Entity
    {
        public Customer(string firstName, string lastName,  string email, User user)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            User = user;

            //TODO: Validações
            new ValidationContract<Customer>(this)
                .IsRequired(x => x.FirstName, "O nome é obrigatório.")
                .HasMaxLenght(x => x.FirstName, 60, "O nome pode ter no máximo 60 caracteres.")
                .HasMinLenght(x => x.FirstName, 3, "O nome pode ter no minimo 3 caracteres.")
                .IsRequired(x => x.LastName, "O sobrenome é obrigatório.")
                .HasMaxLenght(x => x.LastName, 60, "O sobrenome pode ter no máximo 60 caracteres.")
                .HasMinLenght(x => x.LastName, 3, "O sobrenome pode ter no minimo 3 caracteres.")
                .IsEmail(x => x.Email, "O email inválido.");
        }
        
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime? BirthDate { get; private set; }
        public User User { get; private set; }
        public string Email { get; private set; }

        public void Update(string firstName, string lastName, DateTime birthDate)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}