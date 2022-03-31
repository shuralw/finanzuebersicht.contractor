using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.LogicResults;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.AdminEmailUserPasswordReset;

namespace Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.AdminEmailUsers
{
    public interface IAdminEmailUserPasswordResetLogic
    {
        ILogicResult InitializePasswordReset(string email, IBrowserInfo browserInfo);

        ILogicResult ResetPassword(string token, string newPassword);
    }
}