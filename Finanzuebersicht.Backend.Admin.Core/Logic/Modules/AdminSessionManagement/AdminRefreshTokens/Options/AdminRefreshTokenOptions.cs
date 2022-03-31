namespace Finanzuebersicht.Backend.Admin.Core.Logic.Modules.AdminSessionManagement.AdminRefreshTokens
{
    internal class AdminRefreshTokenOptions : OptionsFromConfiguration
    {
        public override string Position => "JwtTokenAuthentication:AdminRefreshToken:Expiration";

        public bool RunOnInitialization { get; set; }

        public int ExpirationTimeInMinutes { get; set; }
    }
}