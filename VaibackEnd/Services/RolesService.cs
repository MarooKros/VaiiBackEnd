using VaibackEnd.Data;
using VaibackEnd.Models;

namespace VaibackEnd.Services
{
    public class RolesService
    {
        public readonly RolesDbContext _rolesContext;

        public RolesService(RolesDbContext rolesContext)
        {
            _rolesContext = rolesContext;
        }

        public Role GetCurrentUserRole(User user)
        {
            var role = _rolesContext.Roles.FirstOrDefault(r => r.UserId == user.Id);
            return role?.UserRole ?? Role.Visitor;
        }

        public void EditUserRole(int userId, Role userRole)
        {
            var role = _rolesContext.Roles.FirstOrDefault(r => r.UserId == userId);
            if (role != null)
            {
                role.UserRole = userRole;
            }
            else
            {
                role = new Roles
                {
                    UserId = userId,
                    UserRole = userRole
                };
                _rolesContext.Roles.Add(role);
            }
            _rolesContext.SaveChanges();
        }
    }
}
