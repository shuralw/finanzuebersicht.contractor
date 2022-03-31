using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.AdminEmailUserPasswordReset;
using System.ComponentModel.DataAnnotations;

namespace Finanzuebersicht.Backend.Admin.Core.API.Modules.AdminUserManagement.AdminEmailUserPasswordReset
{
    public class BrowserInfo : IBrowserInfo
    {
        [Required]
        [StringLength(64, MinimumLength = 1)]
        public string Browser { get; set; }

        [Required]
        [StringLength(64, MinimumLength = 1)]
        public string OperatingSystem { get; set; }
    }
}