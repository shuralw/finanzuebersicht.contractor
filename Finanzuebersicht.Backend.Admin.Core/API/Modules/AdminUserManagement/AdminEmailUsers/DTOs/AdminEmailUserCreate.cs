using System.ComponentModel.DataAnnotations;

namespace Finanzuebersicht.Backend.Admin.Core.API.Modules.AdminUserManagement.AdminEmailUsers
{
    public class AdminEmailUserCreate
    {
        [Required]
        [EmailAddress]
        [StringLength(256, MinimumLength = 1)]
        public string Email { get; set; }
    }
}