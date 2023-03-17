using VarietyShop.Domain.Entities;

namespace VarietyShop.Domain.Models;

public class User : BaseEntity
{
    public User(string cpf, string email, string passwordHash)
    {
        Cpf = cpf;
        Email = email;
        PasswordHash = passwordHash;
    }

    public string Cpf { get; private set; }
    public string Email { get; private set; }
    public string PasswordHash { get; private set; }
    public string Slug { get; set; }
    public bool Active { get; private set; }
    public List<Role> Roles { get; private set; }
    public List<Activity> Activities { get; private set; }
}
