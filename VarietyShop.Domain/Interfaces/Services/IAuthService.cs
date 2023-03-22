using VarietyShop.Domain.Models;

namespace VarietyShop.Domain.Interfaces.Services;

public interface IAuthService
{
    string GenerateJwtToken(string email, List<Role> role);
    string GeneratePasswordHash(string password);
}