namespace VarietyShop.Domain.InputModels;

public class CreateUserInputModel
{
    public string Cpf { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string Role { get; set; }
}
