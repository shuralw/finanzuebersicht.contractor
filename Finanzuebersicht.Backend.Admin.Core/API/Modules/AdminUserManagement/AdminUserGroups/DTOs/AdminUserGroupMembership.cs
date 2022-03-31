using System;
using System.ComponentModel.DataAnnotations;

namespace Finanzuebersicht.Backend.Admin.Core.API.Modules.AdminUserManagement.AdminUserGroups
{
    public class AdminUserGroupMembership
    {
        [Required]
        public Guid AdminUserGroupId { get; set; }

        [Required]
        public Guid ParentAdminUserGroupId { get; set; }
    }
}