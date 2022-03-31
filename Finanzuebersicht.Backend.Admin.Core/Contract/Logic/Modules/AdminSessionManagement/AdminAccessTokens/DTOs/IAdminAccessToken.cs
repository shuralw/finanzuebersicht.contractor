using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.Permissions;
using System;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminSessionManagement.AdminAccessTokens
{
    public interface IAdminAccessToken
    {
        IEnumerable<Guid> AdminAdGroupIds { get; set; }

        Guid? AdminAdUserId { get; set; }

        IDictionary<string, PermissionStatus> CachedPermissions { get; set; }

        Guid? AdminEmailUserId { get; set; }

        DateTime ExpiresOn { get; set; }

        Guid Id { get; set; }

        Guid AdminRefreshTokenId { get; set; }

        string Username { get; set; }
    }
}