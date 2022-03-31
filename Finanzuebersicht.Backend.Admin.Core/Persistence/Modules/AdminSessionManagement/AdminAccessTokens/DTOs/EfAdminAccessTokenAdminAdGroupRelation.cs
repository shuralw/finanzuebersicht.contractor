using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminSessionManagement.AdminAccessTokens
{
    [Table("AdminAccessTokenAdminAdGroupRelations")]
    public partial class EfAdminAccessTokenAdminAdGroupRelation
    {
        public Guid AdminAccessTokenId { get; set; }

        public Guid AdminAdGroupId { get; set; }

        public virtual EfAdminAccessToken AdminAccessToken { get; set; }
    }
}