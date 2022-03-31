using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.AdminEmailUserPasswordReset;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.SystemConnections.FileSystem;
using System;
using System.IO;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Modules.AdminUserManagement.AdminEmailUserPasswordReset
{
    internal class AdminEmailUserPasswordResetMailLogic : IAdminEmailUserPasswordResetMailLogic
    {
        private readonly IFileSystemClient fileSystemClient;

        private string mailContent;

        public AdminEmailUserPasswordResetMailLogic(IFileSystemClient fileSystemClient)
        {
            this.fileSystemClient = fileSystemClient;

            this.LoadMailContent();
        }

        public string GetMessage(IAdminEmailUserPasswordResetMailMetadata metadata)
        {
            var message = this.GenerateMessageFromData(metadata);
            return message;
        }

        private string GenerateMessageFromData(IAdminEmailUserPasswordResetMailMetadata metadata)
        {
            var message = this.mailContent.ToString();

            message = message.Replace("{{name}}", metadata.AdminEmailUserEmail);
            message = message.Replace("{{homepage_url}}", metadata.MailHomepageUrl);
            message = message.Replace("{{action_url}}", metadata.MailResetPasswordUrlPrefix + metadata.AdminEmailUserPasswordResetToken);
            message = message.Replace("{{support_url}}", metadata.MailSupportUrl);
            message = message.Replace("{{operating_system}}", metadata.AdminEmailUserBrowserInfo.OperatingSystem);
            message = message.Replace("{{browser_name}}", metadata.AdminEmailUserBrowserInfo.Browser);

            return message;
        }

        private void LoadMailContent()
        {
            string file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "AdminEmailUserPasswordResetMail.html");
            this.mailContent = this.fileSystemClient.ReadAllText(file);
        }
    }
}