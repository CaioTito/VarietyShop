using FluentValidation;
using System.Text.RegularExpressions;
using VarietyShop.Application.Commands.Users.LoginUser;

namespace VarietyShop.Application.Validators.Users
{
    public class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
    {
        public LoginUserCommandValidator()
        {
            RuleFor(p => p.Email)
               .NotEmpty()
               .EmailAddress()
               .WithMessage("Email inválido ou não preenchido");

            RuleFor(p => p.Password)
                .NotEmpty()
                .Must(ValidPassword)
                .WithMessage("Senha é obrigatória e deve conter 8 caracteres, com no minimo um numero, uma letra minuscula, uma letra maiuscula e uma caracter especial");
        }

        //TODO Abstrair método para tirar repetição de código
        public bool ValidPassword(string password)
        {
            var regex = new Regex(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%&+=]).*$");

            return regex.IsMatch(password);
        }
    }
}
