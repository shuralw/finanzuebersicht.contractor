namespace Finanzuebersicht.Backend.Admin.Core.Logic.Modules.AdminUserManagement.AdminEmailUserPasswordReset
{
    internal class AdminEmailUserPasswordResetOptions : OptionsFromConfiguration
    {
        public override string Position => "FinanzuebersichtAdminCore:AdminUserManagement:AdminEmailUser:PasswordReset";

        public bool RunOnInitialization { get; set; }

        public int ExpirationTimeInMinutes { get; set; }

        public string MailResetPasswordUrlPrefix { get; set; }

        public string MailHomepageUrl { get; set; }

        public string MailSupportUrl { get; set; }
    }
}