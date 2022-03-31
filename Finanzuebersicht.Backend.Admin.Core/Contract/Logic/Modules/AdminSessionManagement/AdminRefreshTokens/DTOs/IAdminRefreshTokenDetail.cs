using System;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminSessionManagement.AdminRefreshTokens
{
    public interface IAdminRefreshTokenDetail
    {
        Guid Id { get; set; }

        Guid? AdminEmailUserId { get; set; }

        Guid? AdminAdUserId { get; set; }

        IEnumerable<Guid> AdminAdGroupIds { get; set; }

        string Username { get; set; }

        DateTime ExpiresOn { get; set; }
    }
}