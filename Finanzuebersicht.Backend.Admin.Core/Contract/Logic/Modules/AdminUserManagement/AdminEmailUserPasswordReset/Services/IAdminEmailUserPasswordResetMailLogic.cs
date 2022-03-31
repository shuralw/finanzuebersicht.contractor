namespace Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.AdminEmailUserPasswordReset
{
    public interface IAdminEmailUserPasswordResetMailLogic
    {
        string GetMessage(IAdminEmailUserPasswordResetMailMetadata metadata);
    }
}