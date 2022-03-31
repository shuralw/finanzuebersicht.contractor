using System;

namespace Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminEmailUserPasswordResetTokens
{
    public interface IDbAdminEmailUserPasswordResetToken
    {
        DateTime ExpiresOn { get; set; }

        string Token { get; set; }

        Guid AdminEmailUserId { get; set; }
    }
}