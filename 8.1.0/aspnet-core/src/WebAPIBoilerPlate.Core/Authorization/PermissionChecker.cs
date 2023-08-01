using Abp.Authorization;
using WebAPIBoilerPlate.Authorization.Roles;
using WebAPIBoilerPlate.Authorization.Users;

namespace WebAPIBoilerPlate.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
