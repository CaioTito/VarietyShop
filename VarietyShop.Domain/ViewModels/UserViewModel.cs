namespace VarietyShop.Domain.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel(string name, string cpf, string email, string role)
        {
            Name = name;
            Cpf = cpf;
            Email = email;
            Role = role;
        }

        public string Name { get; private set; }
        public string Cpf { get; private set; }
        public string Email { get; private set; }
        public string Role { get; private set; }
    }
}
