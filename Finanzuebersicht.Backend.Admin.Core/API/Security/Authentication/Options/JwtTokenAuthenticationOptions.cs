namespace Finanzuebersicht.Backend.Admin.Core.API.Security.Authentication
{
    internal class JwtTokenAuthenticationOptions : OptionsFromConfiguration
    {
        public override string Position => "JwtTokenAuthentication:Jwt";

        public string Secret { get; set; }

        public string Issuer { get; set; }

        public string Audience { get; set; }
    }
}