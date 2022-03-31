namespace Finanzuebersicht.Backend.Admin.Core.API.Security.Authentication
{
    internal class CookieHandlerOptions : OptionsFromConfiguration
    {
        public override string Position => "JwtTokenAuthentication:Cookies";

        public bool Secure { get; set; }
    }
}