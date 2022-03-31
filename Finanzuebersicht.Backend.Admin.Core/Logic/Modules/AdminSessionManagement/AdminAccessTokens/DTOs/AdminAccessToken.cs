using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminSessionManagement.AdminAccessTokens;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.Permissions;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminSessionManagement.AdminAccessTokens;
using System;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Modules.AdminSessionManagement.AdminAccessTokens
{
    internal class AdminAccessToken : IAdminAccessToken
    {
        public Guid Id { get; set; }

        public Guid AdminRefreshTokenId { get; set; }

        public Guid? AdminEmailUserId { get; set; }

        public Guid? AdminAdUserId { get; set; }

        public IEnumerable<Guid> AdminAdGroupIds { get; set; }

        public string Username { get; set; }

        public DateTime ExpiresOn { get; set; }

        public IDictionary<string, PermissionStatus> CachedPermissions { get; set; }

        internal static IAdminAccessToken FromDbAdminAccessToken(IDbAdminAccessToken dbAdminAccessToken)
        {
            return new AdminAccessToken()
            {
                Id = dbAdminAccessToken.Id,
                AdminRefreshTokenId = dbAdminAccessToken.AdminRefreshTokenId,
                AdminEmailUserId = dbAdminAccessToken.AdminEmailUserId,
                AdminAdUserId = dbAdminAccessToken.AdminAdUserId,
                AdminAdGroupIds = dbAdminAccessToken.AdminAdGroupIds,
                Username = dbAdminAccessToken.Username,
                ExpiresOn = dbAdminAccessToken.ExpiresOn,
                CachedPermissions = dbAdminAccessToken.CachedPermissions,
            };
        }
    }
}