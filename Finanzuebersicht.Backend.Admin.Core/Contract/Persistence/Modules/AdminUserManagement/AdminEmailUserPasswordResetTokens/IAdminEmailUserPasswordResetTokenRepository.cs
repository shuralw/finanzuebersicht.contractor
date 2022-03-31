using System;

namespace Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminEmailUserPasswordResetTokens
{
    public interface IAdminEmailUserPasswordResetTokenRepository
    {
        void CreateToken(IDbAdminEmailUserPasswordResetToken adminEmailUserPasswordResetToken);

        void DeleteToken(string token);

        void DeleteToken(DateTime olderThan);

        IDbAdminEmailUserPasswordResetToken GetToken(string token);
    }
}