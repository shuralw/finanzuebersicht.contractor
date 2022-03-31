using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.LogicResults;
using System;

namespace Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminSessionManagement.AdminAccessTokens
{
    public interface IAdminAccessTokensCrudLogic
    {
        ILogicResult<IAdminAccessToken> CreateAdminAccessTokenFromAdminRefreshToken(Guid adminRefreshTokenId);

        ILogicResult<IAdminAccessToken> GetAdminAccessToken(Guid adminAccessTokenId);

        ILogicResult<IAdminAccessTokenDetail> GetAdminAccessTokenDetail(Guid adminAccessTokenId);
    }
}