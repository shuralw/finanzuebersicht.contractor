using System.ComponentModel.DataAnnotations;

namespace Finanzuebersicht.Backend.Admin.Core.API.Modules.AdminUserManagement.AdminAdGroups
{
    public class AdminAdGroupCreate
    {
        [Required]
        [StringLength(256, MinimumLength = 1)]
        [RegularExpression("^(?:(?<cn>CN=(?<name>(?:[^,]|\\,)*)),)?(?:(?<path>(?:(?:CN|OU)=(?:[^,]|\\,)+,?)+),)?(?<domain>(?:DC=(?:[^,]|\\,)+,?)+)$", ErrorMessage = "Distinguished Names müssen den RFC2253- und Active Directory-Benennungsregeln entsprechen.")]
        public string Dn { get; set; }
    }
}