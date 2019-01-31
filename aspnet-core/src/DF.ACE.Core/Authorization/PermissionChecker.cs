using Abp.Authorization;
using DF.ACE.Authorization.Roles;
using DF.ACE.Authorization.Users;

namespace DF.ACE.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
