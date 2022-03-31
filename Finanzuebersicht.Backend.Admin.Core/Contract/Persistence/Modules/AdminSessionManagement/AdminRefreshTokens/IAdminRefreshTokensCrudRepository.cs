using System;

namespace Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminSessionManagement.AdminRefreshTokens
{
    public interface IAdminRefreshTokensCrudRepository
    {
        void CreateAdminRefreshToken(IDbAdminRefreshToken dbAdminRefreshToken);

        void DeleteExpiredAdminRefreshTokens(DateTime now);

        void DeleteAdminRefreshToken(Guid id);

        void DeleteAdminRefreshTokensOfAdminEmailUser(Guid adminEmailUserId);

        bool DoesAdminRefreshTokenExist(Guid adminRefreshTokenId);

        IDbAdminRefreshToken GetAdminRefreshToken(Guid id);
    }
}