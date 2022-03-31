using System;
using System.ComponentModel.DataAnnotations;

namespace Finanzuebersicht.Backend.Admin.Core.API.Modules.AdminUserManagement.AdminUserGroups
{
    public class AdminUserGroupUpdate
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [StringLength(256, MinimumLength = 1)]
        public string Name { get; set; }
    }
}