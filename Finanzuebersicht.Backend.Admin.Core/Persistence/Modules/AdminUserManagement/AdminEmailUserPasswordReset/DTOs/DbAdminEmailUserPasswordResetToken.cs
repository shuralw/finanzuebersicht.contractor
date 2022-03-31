using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminEmailUserPasswordResetTokens;
using System;

namespace Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminUserManagement.AdminEmailUserPasswordReset
{
    internal class DbAdminEmailUserPasswordResetToken : IDbAdminEmailUserPasswordResetToken
    {
        public string Token { get; set; }

        public Guid AdminEmailUserId { get; set; }

        public DateTime ExpiresOn { get; set; }

        public static IDbAdminEmailUserPasswordResetToken FromEfAdminEmailUserPasswordResetToken(EfAdminEmailUserPasswordResetToken efAdminEmailUserPasswordResetToken)
        {
            if (efAdminEmailUserPasswordResetToken == null)
            {
                return null;
            }

            return new DbAdminEmailUserPasswordResetToken()
            {
                Token = efAdminEmailUserPasswordResetToken.Token,
                AdminEmailUserId = efAdminEmailUserPasswordResetToken.AdminEmailUserId,
                ExpiresOn = efAdminEmailUserPasswordResetToken.ExpiresOn
            };
        }

        public static EfAdminEmailUserPasswordResetToken ToEfAdminEmailUserPasswordResetToken(IDbAdminEmailUserPasswordResetToken adminEmailUserPasswordResetToken)
        {
            return new EfAdminEmailUserPasswordResetToken()
            {
                Token = adminEmailUserPasswordResetToken.Token,
                AdminEmailUserId = adminEmailUserPasswordResetToken.AdminEmailUserId,
                ExpiresOn = adminEmailUserPasswordResetToken.ExpiresOn
            };
        }
    }
}