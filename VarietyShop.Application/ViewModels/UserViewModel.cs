using System.Collections.Generic;
using VarietyShop.Domain.Entities;

namespace VarietyShop.Application.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel(string name, string cpf, string email, List<RoleViewModel> roles)
        {
            Name = name;
            Cpf = cpf;
            Email = email;
            Roles = roles;
        }

        public string Name { get; private set; }
        public string Cpf { get; private set; }
        public string Email { get; private set; }
        public List<RoleViewModel> Roles { get; private set; }
    }
}
