using Bogus;
using VarietyShop.Application.Commands.Users.CreateUser;
using VarietyShop.Application.Commands.Users.DeleteUser;
using VarietyShop.Application.Commands.Users.LoginUser;
using VarietyShop.Application.Commands.Users.UpdateUser;
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
                RoleMock.RoleWithoutUsersFaker.Generate(3)
            )
        ));

    public static Faker<User> UserEmptyFaker => new Faker<User>()
        .CustomInstantiator(f => (
            new User()
        ));

    public static Faker<CreateUserCommand> CreateUserCommandFaker =>
            new Faker<CreateUserCommand>()
                .RuleFor(x => x.Name, f => f.Random.Word())
                .RuleFor(x => x.Cpf, f => f.Random.Word())
                .RuleFor(x => x.Email, f => f.Random.Word())
                .RuleFor(x => x.PasswordHash, f => f.Random.Word())
                .RuleFor(x => x.Slug, f => f.Random.Word())
                .RuleFor(x => x.Active, f => f.Random.Bool())
                .RuleFor(x => x.RolesId, f => new List<int> { 1, 2, 3 });

    public static Faker<DeleteUserCommand> DeleteUserCommandFaker => new Faker<DeleteUserCommand>()
        .CustomInstantiator(f => (
            new DeleteUserCommand(f.Random.Int())
        ));

    public static Faker<UpdateUserCommand> UpdateUserCommandFaker => new Faker<UpdateUserCommand>()
        .CustomInstantiator(f => (
            new UpdateUserCommand(
                f.Random.Int(),
                f.Random.Word(),
                f.Random.Word())
        ));

    public static Faker<LoginUserCommand> LoginUserCommandFaker =>
            new Faker<LoginUserCommand>()
                .RuleFor(x => x.Email, f => f.Random.Word())
                .RuleFor(x => x.Password, f => f.Random.Word());
}

