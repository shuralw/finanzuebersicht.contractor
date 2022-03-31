using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Tools.Time;

namespace Finanzuebersicht.Backend.Admin.Core.API.Security.Authentication
{
    internal class AdminRefreshTokenCookieHandler : IAdminRefreshTokenCookieHandler
    {
        private const string AdminRefreshTokenCookieKey = "refresh_token";

        private readonly IJwtTokenHandler jwtTokenHandler;

        private readonly IDateTimeProvider dateTimeProvider;

        private readonly IHttpContextAccessor httpContextAccessor;

        private readonly CookieHandlerOptions cookieOptions;

        public AdminRefreshTokenCookieHandler(
            IJwtTokenHandler jwtTokenHandler,
            IDateTimeProvider dateTimeProvider,
            IHttpContextAccessor httpContextAccessor,
            IOptions<CookieHandlerOptions> options)
        {
            this.jwtTokenHandler = jwtTokenHandler;

            this.dateTimeProvider = dateTimeProvider;

            this.httpContextAccessor = httpContextAccessor;

            this.cookieOptions = options.Value;
        }

        public void SetAdminRefreshTokenToCookie(IAdminRefreshTokenJwtData adminRefreshTokenJwtData)
        {
            string jwtToken = this.jwtTokenHandler.GenerateJwtToken(adminRefreshTokenJwtData);

            this.httpContextAccessor.HttpContext.Response.Cookies.Append(AdminRefreshTokenCookieKey, jwtToken, new CookieOptions()
            {
                HttpOnly = true,
                Secure = this.cookieOptions.Secure,
                MaxAge = adminRefreshTokenJwtData.ExpiresOn - this.dateTimeProvider.Now(),
            });
        }

        public IAdminRefreshTokenJwtData GetAdminRefreshTokenFromCookie()
        {
            string jwtToken = this.httpContextAccessor.HttpContext.Request.Cookies[AdminRefreshTokenCookieKey];

            IAdminRefreshTokenJwtData adminRefreshTokenJwtData = this.jwtTokenHandler.ExtractAdminRefreshToken(jwtToken);
            return adminRefreshTokenJwtData;
        }

        public void RemoveAdminRefreshTokenFromCookie()
        {
            this.httpContextAccessor.HttpContext.Response.Cookies.Delete(AdminRefreshTokenCookieKey);
        }
    }
}