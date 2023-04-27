using System.Collections.Generic;

namespace VarietyShop.Domain.Entities;

public class Role : BaseEntity
{
    public Role(string name, string slug, bool active, List<User> users)
    {
        Name = name;
        Slug = slug;
        Active = active;
        Users = users;
    }

    public Role(string name, string slug, bool active)
    {
        Name = name;
        Slug = slug;
        Active = active;
    }

    public List<User> Users { get; private set; }

    public static Role From(string name, string slug, bool active, List<User> users)
    {
        return new Role(
        name,
        slug,
        active,
        users);
    }

    public static Role From(string name, string slug, bool active)
    {
        return new Role(
        name,
        slug,
        active);
    }
}
