using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Finanzuebersicht.Backend.Admin.Core.API.Security.Authentication
{
    public static class JwtTokenAuthenticationExtensions
    {
        public static AuthenticationBuilder AddJwtTokenAuthentication(this AuthenticationBuilder builder, IConfiguration configuration)
        {
            builder.Services.AddSingleton<IJwtTokenHandler, JwtTokenHandler>();
            builder.Services.AddSingleton<IAdminRefreshTokenCookieHandler, AdminRefreshTokenCookieHandler>();
            builder.Services.AddOptionsFromConfiguration<JwtTokenAuthenticationOptions>(configuration);
            builder.Services.AddOptionsFromConfiguration<CookieHandlerOptions>(configuration);

            return builder.AddScheme<JwtTokenAuthenticationHandlerOptions, JwtTokenAuthenticationHandler>(
                JwtTokenAuthentication.Scheme,
                _ => { });
        }
    }
}