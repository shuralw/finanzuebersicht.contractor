namespace Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.AdminEmailUserPasswordReset
{
    public interface IAdminEmailUserPasswordResetMailMetadata
    {
        IBrowserInfo AdminEmailUserBrowserInfo { get; set; }

        string AdminEmailUserEmail { get; set; }

        string AdminEmailUserPasswordResetToken { get; set; }

        string MailHomepageUrl { get; set; }

        string MailResetPasswordUrlPrefix { get; set; }

        string MailSupportUrl { get; set; }
    }
}