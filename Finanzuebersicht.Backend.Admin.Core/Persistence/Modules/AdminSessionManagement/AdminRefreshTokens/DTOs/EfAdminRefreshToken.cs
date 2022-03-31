using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminSessionManagement.AdminAccessTokens;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminSessionManagement.AdminRefreshTokens
{
    [Table("AdminRefreshTokens")]
    public partial class EfAdminRefreshToken
    {
        public EfAdminRefreshToken()
        {
            this.AdminAccessTokens = new HashSet<EfAdminAccessToken>();
            this.AdminRefreshTokenAdminAdGroupRelations = new HashSet<EfAdminRefreshTokenAdminAdGroupRelation>();
        }

        public Guid Id { get; set; }

        public Guid? AdminEmailUserId { get; set; }

        public Guid? AdminAdUserId { get; set; }

        public string Username { get; set; }

        public DateTime ExpiresOn { get; set; }

        public virtual ICollection<EfAdminAccessToken> AdminAccessTokens { get; set; }

        public virtual ICollection<EfAdminRefreshTokenAdminAdGroupRelation> AdminRefreshTokenAdminAdGroupRelations { get; set; }
    }
}