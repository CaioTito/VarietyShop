namespace VarietyShop.Domain.Interfaces.Services;

public interface IAuthService
{
    string GenerateJwtToken(string email, string role);
}