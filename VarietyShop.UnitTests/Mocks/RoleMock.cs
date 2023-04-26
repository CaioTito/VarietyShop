using Bogus;
using VarietyShop.Application.Commands.Roles.CreateRole;
using VarietyShop.Application.Commands.Users.CreateUser;
using VarietyShop.Domain.Entities;

namespace VarietyShop.UnitTests.Mocks;

public static class RoleMock
{
    public static Faker<Role> RoleFaker =>
            new Faker<Role>()
                .RuleFor(x => x.Name, f => f.Random.Word())
                .RuleFor(x => x.Slug, f => f.Random.Word())
                .RuleFor(x => x.Active, f => f.Random.Bool());

    public static Faker<CreateRoleCommand> CreateRoleCommandFaker =>
            new Faker<CreateRoleCommand>()
                .RuleFor(x => x.Name, f => f.Random.Word())
                .RuleFor(x => x.Active, f => f.Random.Bool());

}

