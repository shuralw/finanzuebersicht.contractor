using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminSessionManagement.AdminAccessTokens;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.Permissions;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminSessionManagement.AdminAccessTokens;
using System;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Modules.AdminSessionManagement.AdminAccessTokens
{
    internal class AdminAccessTokenDetail : IAdminAccessTokenDetail
    {
        public Guid Id { get; set; }

        public Guid AdminRefreshTokenId { get; set; }

        public Guid? AdminEmailUserId { get; set; }

        public Guid? AdminAdUserId { get; set; }

        public IEnumerable<Guid> AdminAdGroupIds { get; set; }

        public string Username { get; set; }

        public DateTime ExpiresOn { get; set; }

        public IDictionary<string, PermissionStatus> CachedPermissions { get; set; }

        internal static IAdminAccessTokenDetail FromDbAdminAccessTokenDetail(IDbAdminAccessToken dbAdminAccessTokenDetail)
        {
            return new AdminAccessTokenDetail()
            {
                Id = dbAdminAccessTokenDetail.Id,
                AdminRefreshTokenId = dbAdminAccessTokenDetail.AdminRefreshTokenId,
                AdminEmailUserId = dbAdminAccessTokenDetail.AdminEmailUserId,
                AdminAdUserId = dbAdminAccessTokenDetail.AdminAdUserId,
                AdminAdGroupIds = dbAdminAccessTokenDetail.AdminAdGroupIds,
                Username = dbAdminAccessTokenDetail.Username,
                ExpiresOn = dbAdminAccessTokenDetail.ExpiresOn,
                CachedPermissions = dbAdminAccessTokenDetail.CachedPermissions,
            };
        }
    }
}