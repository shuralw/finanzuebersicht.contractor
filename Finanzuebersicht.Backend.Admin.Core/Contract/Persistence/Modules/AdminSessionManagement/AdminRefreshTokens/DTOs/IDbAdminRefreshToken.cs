using System;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminSessionManagement.AdminRefreshTokens
{
    public interface IDbAdminRefreshToken
    {
        Guid Id { get; set; }

        Guid? AdminEmailUserId { get; set; }

        Guid? AdminAdUserId { get; set; }

        IEnumerable<Guid> AdminAdGroupIds { get; set; }

        string Username { get; set; }

        DateTime ExpiresOn { get; set; }
    }
}