using Microsoft.AspNetCore.Authorization;

namespace KursovayaBlazorNet6.UsersRoles
{
    public class PermissionRequirement : IAuthorizationRequirement
    {
        public string Permission { get; private set; }

        public PermissionRequirement(string permission)
        {
            Permission = permission;
        }
    }
}
