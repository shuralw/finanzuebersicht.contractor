using System;
using System.ComponentModel.DataAnnotations;

namespace Finanzuebersicht.Backend.Admin.Core.API.Modules.AdminUserManagement.AdminAdUsers
{
    public class AdminAdUserMembership
    {
        [Required]
        public Guid AdminAdUserId { get; set; }

        [Required]
        public Guid AdminUserGroupId { get; set; }
    }
}