using System.ComponentModel.DataAnnotations;

namespace Finanzuebersicht.Backend.Admin.Core.API.Modules.AdminUserManagement.AdminUserGroups
{
    public class AdminUserGroupCreate
    {
        [Required]
        [StringLength(256, MinimumLength = 1)]
        public string Name { get; set; }
    }
}