using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.AdminEmailUserPasswordReset;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Modules.AdminUserManagement.AdminEmailUserPasswordReset
{
    internal class AdminEmailUserPasswordResetMailMetadata : IAdminEmailUserPasswordResetMailMetadata
    {
        public string MailResetPasswordUrlPrefix { get; set; }

        public string MailHomepageUrl { get; set; }

        public string MailSupportUrl { get; set; }

        public string AdminEmailUserEmail { get; set; }

        public string AdminEmailUserPasswordResetToken { get; set; }

        public IBrowserInfo AdminEmailUserBrowserInfo { get; set; }
    }
}