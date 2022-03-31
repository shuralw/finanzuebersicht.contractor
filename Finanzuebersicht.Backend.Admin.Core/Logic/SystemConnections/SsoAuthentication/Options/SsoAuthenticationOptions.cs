namespace Finanzuebersicht.Backend.Admin.Core.Logic.SystemConnections.SsoAuthentication
{
    internal class SsoAuthenticationOptions : OptionsFromConfiguration
    {
        public override string Position => "SystemConnections:SsoAuthentication";

        public string SsoWebserviceBaseUrl { get; set; }
    }
}