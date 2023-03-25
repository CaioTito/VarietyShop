using System.Collections.Generic;

namespace VarietyShop.Domain.Entities;

public class User : BaseEntity
{
    public User(string name, string cpf, string email, string passwordHash, string slug, bool active, List<Role> roles)
    {
        Name = name;
        Cpf = cpf;
        Email = email;
        PasswordHash = passwordHash;
        Slug = slug;
        Active = active;
        Roles = roles;
    }

    public string Cpf { get; private set; }
    public string Email { get; private set; }
    public string PasswordHash { get; private set; }
    public List<Role> Roles { get; private set; }
    public List<Activity> Activities { get; private set; }

    public void Update(string email, List<Role> role)
    {
        Email = email;
        Roles = role;
    }
}
