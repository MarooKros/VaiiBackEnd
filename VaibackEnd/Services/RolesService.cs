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
            var role = _rolesContext.Roles.FirstOrDefault(r => r.user.Id == user.Id);
            return role?.userRole ?? Role.Visitor;
        }

        public void EditUserRole(Roles roles)
        {
            var role = _rolesContext.Roles.FirstOrDefault(r => r.user.Id == roles.user.Id);
            if (role != null)
            {
                role.userRole = role.userRole;
            }
            else
            {
                role = new Roles
                {
                    user = roles.user,
                    userRole = roles.userRole
                };
                _rolesContext.Roles.Add(role);
            }
            _rolesContext.SaveChanges();
        }
    }
}
