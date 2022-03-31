using System;

namespace Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminSessionManagement.AdminAccessTokens
{
    public interface IAdminAccessTokensCrudRepository
    {
        void CreateAdminAccessToken(IDbAdminAccessToken dbAdminAccessToken);

        void DeleteAdminAccessToken(Guid id);

        void DeleteAdminAccessTokensOfAdminEmailUser(Guid adminEmailUserId);

        void DeleteAdminAccessTokensOfAdminAdUsersAndAdminAdGroups();

        void DeleteAllAdminAccessTokens();

        void DeleteExpiredAdminAccessTokens(DateTime now);

        bool DoesAdminAccessTokenExist(Guid adminAccessTokenId);

        IDbAdminAccessToken GetAdminAccessToken(Guid id);
    }
}