using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminSessionManagement.AdminRefreshTokens;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminSessionManagement.AdminAccessTokens
{
    [Table("AdminAccessTokens")]
    public partial class EfAdminAccessToken
    {
        public EfAdminAccessToken()
        {
            this.AdminAccessTokenAdminAdGroupRelations = new HashSet<EfAdminAccessTokenAdminAdGroupRelation>();
        }

        public Guid Id { get; set; }

        public Guid AdminRefreshTokenId { get; set; }

        public Guid? AdminEmailUserId { get; set; }

        public Guid? AdminAdUserId { get; set; }

        public string Username { get; set; }

        public DateTime ExpiresOn { get; set; }

        public virtual EfAdminRefreshToken AdminRefreshToken { get; set; }

        public virtual EfAdminAccessTokenCachedPermissionsEntry AdminAccessTokenCachedPermissions { get; set; }

        public virtual ICollection<EfAdminAccessTokenAdminAdGroupRelation> AdminAccessTokenAdminAdGroupRelations { get; set; }
    }
}