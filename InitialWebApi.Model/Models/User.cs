using MongoDB.Bson;
using System;

namespace InitialWebApi.Model.Models
{
    public class User
    {
        protected User() { }

        public User(string name, string cpf, string email)
        {
            Id = Guid.NewGuid();
            Name = name;
            Cpf = cpf;
            Email = email;
        }

        public ObjectId _id { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
    }
}
