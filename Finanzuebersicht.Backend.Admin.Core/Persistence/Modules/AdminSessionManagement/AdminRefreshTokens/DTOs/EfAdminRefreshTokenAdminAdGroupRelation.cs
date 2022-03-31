using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminSessionManagement.AdminRefreshTokens
{
    [Table("AdminRefreshTokenAdminAdGroupRelations")]
    public partial class EfAdminRefreshTokenAdminAdGroupRelation
    {
        public Guid AdminRefreshTokenId { get; set; }

        public Guid AdminAdGroupId { get; set; }

        public virtual EfAdminRefreshToken AdminRefreshToken { get; set; }
    }
}