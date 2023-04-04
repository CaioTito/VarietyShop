using FluentValidation;
using VarietyShop.Application.Commands.Users.UpdateUser;

namespace VarietyShop.Application.Validators.Users;

public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator() 
    {
        RuleFor(p => p.Email)
            .NotEmpty()
            .EmailAddress()
            .WithMessage("Email inválido ou não preenchido");

        RuleFor(p => p.Id)
            .NotEmpty()
            .WithMessage("Preenchimento do ID obrigatório");

        RuleFor(p => p.Role)
            .NotEmpty()
            .WithMessage("Preenchimento da Role obrigatória");

    }
}

