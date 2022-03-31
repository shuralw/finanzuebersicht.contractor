namespace Finanzuebersicht.Backend.Admin.Core.Logic.Modules.AdminSessionManagement.AdminAccessTokens
{
    internal class AdminAccessTokenOptions : OptionsFromConfiguration
    {
        public override string Position => "JwtTokenAuthentication:AdminAccessToken:Expiration";

        public bool RunOnInitialization { get; set; }

        public int ExpirationTimeInMinutes { get; set; }
    }
}