namespace Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.AdminEmailUserPasswordReset
{
    public interface IBrowserInfo
    {
        string Browser { get; set; }

        string OperatingSystem { get; set; }
    }
}