using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.Permissions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Finanzuebersicht.Backend.Admin.Core.API.Modules.AdminUserManagement.Permissions
{
    public class ApiPermissions
    {
        [Required]
        [Permissions]
        public Dictionary<string, PermissionStatus> Permissions { get; set; }
    }
}