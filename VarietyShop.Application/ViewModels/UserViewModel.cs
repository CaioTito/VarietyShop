using System.Collections.Generic;
using VarietyShop.Domain.Entities;

namespace VarietyShop.Application.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel(string name, string cpf, string email, List<Role> role)
        {
            Name = name;
            Cpf = cpf;
            Email = email;
            Role = role;
        }

        public string Name { get; private set; }
        public string Cpf { get; private set; }
        public string Email { get; private set; }
        public List<Role> Role { get; private set; }
    }
}
