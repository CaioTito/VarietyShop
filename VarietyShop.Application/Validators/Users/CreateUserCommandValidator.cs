using FluentValidation;
using System.Text.RegularExpressions;
using VarietyShop.Application.Commands.Users.CreateUser;

namespace VarietyShop.Application.Validators.Users;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(p => p.Email)
            .NotEmpty()
            .EmailAddress()
            .WithMessage("Email inválido ou não preenchido");

        RuleFor(p => p.Name)
            .NotEmpty()
            .MaximumLength(80)
            .WithMessage("Nome obrigatório com tamanha máximo de 80 caracteres");

        RuleFor(p => p.Cpf)
           .NotEmpty()
           .Must(ValidCPF)
           .WithMessage("CPF obrigatório e com formatação (123.456.789-11)");

        RuleFor(p => p.PasswordHash) 
            .NotEmpty()
            .Must(ValidPassword)
            .WithMessage("Senha é obrigatória e deve conter 8 caracteres, com no minimo um numero, uma letra minuscula, uma letra maiuscula e uma caracter especial");

        RuleFor(p => p.Slug)
            .NotEmpty()
            .MaximumLength(20)
            .WithMessage("Slug obrigatório com tamanha máximo de 20 caracteres");

        RuleFor(p=> p.Active)
            .NotEmpty()
            .WithMessage("Preenchimento de Active obrigatório");
    }

    public bool ValidCPF(string cpf) => Regex.IsMatch(cpf, "^[0-9]{3}.?[0-9]{3}.?[0-9]{3}-?[0-9]{2}");

    //TODO Abstrair método para tirar repetição de código
    public bool ValidPassword(string password)
    {
        var regex = new Regex(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%&+=]).*$");

        return regex.IsMatch(password);
    }
}
