using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.LogicResults;

namespace Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.AdminEmailUsers
{
    public interface IAdminEmailUserPasswordChangeLogic
    {
        ILogicResult ChangePassword(string oldPassword, string newPassword);
    }
}