namespace VarietyShop.Domain.Entities
{
    public class UserRole
    {
        public UserRole(int roleId, int userId)
        {
            RoleId = roleId;
            UserId = userId;
        }

        public int RoleId { get; private set; }
        public int UserId { get; private set; }
    }
}
