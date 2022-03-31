using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.Permissions;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminSessionManagement.AdminAccessTokens;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminUserManagement.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminSessionManagement.AdminAccessTokens
{
    public partial class DbAdminAccessToken : IDbAdminAccessToken
    {
        public Guid Id { get; set; }

        public Guid AdminRefreshTokenId { get; set; }

        public Guid? AdminEmailUserId { get; set; }

        public Guid? AdminAdUserId { get; set; }

        public IEnumerable<Guid> AdminAdGroupIds { get; set; }

        public string Username { get; set; }

        public DateTime ExpiresOn { get; set; }

        public IDictionary<string, PermissionStatus> CachedPermissions { get; set; }

        public static IDbAdminAccessToken FromEfAdminAccessToken(EfAdminAccessToken efAdminAccessToken)
        {
            if (efAdminAccessToken == null)
            {
                return null;
            }

            IDbAdminAccessToken dbAdminAccessToken = new DbAdminAccessToken()
            {
                Id = efAdminAccessToken.Id,
                AdminRefreshTokenId = efAdminAccessToken.AdminRefreshTokenId,
                AdminEmailUserId = efAdminAccessToken.AdminEmailUserId,
                AdminAdUserId = efAdminAccessToken.AdminAdUserId,
                AdminAdGroupIds = efAdminAccessToken.AdminAccessTokenAdminAdGroupRelations.Select(relation => relation.AdminAdGroupId),
                Username = efAdminAccessToken.Username,
                ExpiresOn = efAdminAccessToken.ExpiresOn,
                CachedPermissions = DbPermissionsEntry
                    .FromEfPermissionsEntry(efAdminAccessToken.AdminAccessTokenCachedPermissions),
            };

            return dbAdminAccessToken;
        }

        internal static EfAdminAccessToken ToEfAdminAccessToken(IDbAdminAccessToken dbAdminAccessToken)
        {
            return new EfAdminAccessToken()
            {
                Id = dbAdminAccessToken.Id,
                AdminRefreshTokenId = dbAdminAccessToken.AdminRefreshTokenId,
                AdminEmailUserId = dbAdminAccessToken.AdminEmailUserId,
                AdminAdUserId = dbAdminAccessToken.AdminAdUserId,
                Username = dbAdminAccessToken.Username,
                ExpiresOn = dbAdminAccessToken.ExpiresOn,
            };
        }
    }
}