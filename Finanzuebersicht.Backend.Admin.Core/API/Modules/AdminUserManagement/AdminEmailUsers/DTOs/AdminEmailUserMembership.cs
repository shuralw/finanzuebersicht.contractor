using System;
using System.ComponentModel.DataAnnotations;

namespace Finanzuebersicht.Backend.Admin.Core.API.Modules.AdminUserManagement.AdminEmailUsers
{
    public class AdminEmailUserMembership
    {
        [Required]
        public Guid AdminEmailUserId { get; set; }

        [Required]
        public Guid AdminUserGroupId { get; set; }
    }
}