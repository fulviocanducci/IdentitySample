using System;
using System.Collections.Generic;
using System.Text;

namespace IdentitySample.Domain.Entities
{
   public class User
    {
        public User(Guid id, string name, string email, DateTime birthDate)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
        }
        protected User()
        {

        }
        public Guid Id { get; private set; }
        public string  Name { get; private set; }
        public string Email { get; private set; }
        public DateTime? BirthDate { get; private set; }
    }
}
