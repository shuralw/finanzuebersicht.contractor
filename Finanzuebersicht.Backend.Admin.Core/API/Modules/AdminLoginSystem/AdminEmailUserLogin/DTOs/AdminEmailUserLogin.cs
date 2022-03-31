using System.ComponentModel.DataAnnotations;

namespace Finanzuebersicht.Backend.Admin.Core.API.Modules.AdminLoginSystem.AdminEmailUserLogin
{
    public class AdminEmailUserLogin
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Passwort { get; set; }
    }
}