using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.Permissions;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminSessionManagement.AdminAccessTokens;
using System;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Modules.AdminSessionManagement.AdminAccessTokens
{
    internal class DbAdminAccessToken : IDbAdminAccessToken
    {
        public IEnumerable<Guid> AdminAdGroupIds { get; set; }

        public Guid? AdminAdUserId { get; set; }

        public IDictionary<string, PermissionStatus> CachedPermissions { get; set; }

        public Guid? AdminEmailUserId { get; set; }

        public DateTime ExpiresOn { get; set; }

        public Guid Id { get; set; }

        public Guid AdminRefreshTokenId { get; set; }

        public string Username { get; set; }
    }
}