using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminEmailUserPasswordResetTokens;
using System;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Modules.AdminUserManagement.AdminEmailUserPasswordReset
{
    internal class DbAdminEmailUserPasswordResetToken : IDbAdminEmailUserPasswordResetToken
    {
        public DateTime ExpiresOn { get; set; }

        public string Token { get; set; }

        public Guid AdminEmailUserId { get; set; }
    }
}