using System;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Admin.Core.Contract.Contexts
{
    public interface ISessionContext
    {
        bool IsAuthenticated { get; }

        Guid? AdminEmailUserId { get; }

        Guid? AdminAdUserId { get; }

        IEnumerable<Guid> AdminAdGroupIds { get; }

        Guid AdminAccessTokenId { get; }

        Guid AdminRefreshTokenId { get; }

        string UserName { get; }

        bool HasPermission(string permissionName);
    }
}