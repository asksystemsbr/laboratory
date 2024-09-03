using Microsoft.AspNetCore.Authorization;

namespace LaboratoryBackEnd.Extensions
{
    public class DynamicPermissionRequirement : IAuthorizationRequirement
    {
        public string PermissionType { get; }

        public DynamicPermissionRequirement(string permissionType)
        {
            PermissionType = permissionType;
        }
    }
}
