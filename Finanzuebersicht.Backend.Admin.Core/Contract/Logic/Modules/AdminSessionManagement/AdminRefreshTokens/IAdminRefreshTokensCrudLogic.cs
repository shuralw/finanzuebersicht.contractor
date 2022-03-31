using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.LogicResults;
using System;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminSessionManagement.AdminRefreshTokens
{
    public interface IAdminRefreshTokensCrudLogic
    {
        Guid CreateAdminRefreshTokenForAd(Guid? adminAdUserId, IEnumerable<Guid> adminAdGroupIds, string username);

        Guid CreateAdminRefreshTokenForAdminEmailUser(Guid adminEmailUserId, string username);

        ILogicResult<IAdminRefreshTokenDetail> GetAdminRefreshToken(Guid id);

        ILogicResult DeleteAdminRefreshToken(Guid adminRefreshTokenId);
    }
}