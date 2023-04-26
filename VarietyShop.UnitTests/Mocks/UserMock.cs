using Bogus;
using VarietyShop.Application.Commands.Users.CreateUser;
using VarietyShop.Domain.Entities;

namespace VarietyShop.UnitTests.Mocks;

public static class UserMock
{
    public static Faker<User> UserFaker => new Faker<User>()
        .CustomInstantiator(f => (
            User.From(
                f.Random.Word(),
                f.Random.Word(),
                f.Random.Word(),
                f.Random.Word(),
                f.Random.Word(),
                f.Random.Bool(),
                RoleMock.RoleFaker.Generate(3)
            )
        ));

    public static Faker<CreateUserCommand> CreateUserCommandFaker =>
            new Faker<CreateUserCommand>()
                .RuleFor(x => x.Name, f => f.Random.Word())
                .RuleFor(x => x.Cpf, f => f.Random.Word())
                .RuleFor(x => x.Email, f => f.Random.Word())
                .RuleFor(x => x.PasswordHash, f => f.Random.Word())
                .RuleFor(x => x.Slug, f => f.Random.Word())
                .RuleFor(x => x.Active, f => f.Random.Bool())
                .RuleFor(x => x.RolesId, f => new List<int>());

}

