using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.LogicResults;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminSessionManagement.AdminRefreshTokens;

namespace Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminLoginSystem.AdminEmailUser
{
    public interface IAdminEmailUserLoginLogic
    {
        ILogicResult<IAdminRefreshTokenDetail> LoginAsAdminEmailUser(string email, string password);
    }
}