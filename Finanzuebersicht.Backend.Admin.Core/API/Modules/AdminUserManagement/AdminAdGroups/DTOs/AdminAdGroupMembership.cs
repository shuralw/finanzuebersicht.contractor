using System;
using System.ComponentModel.DataAnnotations;

namespace Finanzuebersicht.Backend.Admin.Core.API.Modules.AdminUserManagement.AdminAdGroups
{
    public class AdminAdGroupMembership
    {
        [Required]
        public Guid AdminAdGroupId { get; set; }

        [Required]
        public Guid AdminUserGroupId { get; set; }
    }
}