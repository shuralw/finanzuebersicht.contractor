namespace Finanzuebersicht.Backend.Admin.Core.Logic.SystemConnections.Email
{
    internal class EmailClientOptions : OptionsFromConfiguration
    {
        public override string Position => "SystemConnections:Smtp";

        public string SmtpSender { get; set; }

        public string SmtpHost { get; set; }

        public int? SmtpPort { get; set; }

        public bool EnableSsl { get; set; }
    }
}