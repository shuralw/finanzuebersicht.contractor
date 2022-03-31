using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.LogicResults;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminSessionManagement.AdminRefreshTokens;
using System.Threading.Tasks;

namespace Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminLoginSystem.Ad
{
    public interface IAdminAdLoginLogic
    {
        Task<ILogicResult<IAdminRefreshTokenDetail>> LoginWithSsoToken(string token);
    }
}