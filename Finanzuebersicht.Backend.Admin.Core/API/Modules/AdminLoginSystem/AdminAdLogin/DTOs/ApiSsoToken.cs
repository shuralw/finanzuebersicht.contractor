using System.ComponentModel.DataAnnotations;

namespace Finanzuebersicht.Backend.Admin.Core.API.Modules.AdminLoginSystem.AdminAdLogin
{
    public class ApiSsoToken
    {
        [Required]
        [MinLength(1)]
        [MaxLength(64)]
        public string SsoToken { get; set; }
    }
}