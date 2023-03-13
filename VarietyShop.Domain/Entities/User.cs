using VarietyShop.Domain.Entities;

namespace VarietyShop.Domain.Models;

public class User : BaseEntity
{
    public User(string cpf, string email, string passwordHash, string role)
    {
        Cpf = cpf;
        Email = email;
        PasswordHash = passwordHash;
        Role = role;
    }

    public string Cpf { get; private set; }
    public string Email { get; private set; }
    public string PasswordHash { get; private set; }
    public string Role { get; private set; }
}
