using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NLog;
using Finanzuebersicht.Backend.Admin.Core.API.Security.Authorization;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.LogicResults;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminSessionManagement.AdminAccessTokens;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.Permissions;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously

namespace Finanzuebersicht.Backend.Admin.Core.API.Security.Authentication
{
    public class JwtTokenAuthenticationHandler : AuthenticationHandler<JwtTokenAuthenticationHandlerOptions>
    {
        private readonly IJwtTokenHandler jwtTokenHandler;
        private readonly IAdminAccessTokensCrudLogic adminAccessTokenCrudLogic;

        public JwtTokenAuthenticationHandler(
            IOptionsMonitor<JwtTokenAuthenticationHandlerOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            IJwtTokenHandler jwtTokenHandler,
            IAdminAccessTokensCrudLogic adminAccessTokenCrudLogic)
            : base(options, logger, encoder, clock)
        {
            this.jwtTokenHandler = jwtTokenHandler;
            this.adminAccessTokenCrudLogic = adminAccessTokenCrudLogic;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            Logger logger = LogManager.GetCurrentClassLogger();

            // Validate authorization header format
            if (this.IsNoTokenProvided(this.Request.Headers))
            {
                return AuthenticateResult.NoResult();
            }

            // Extract JWT-Token from authorization header
            var jwtToken = this.ExtractJwtToken(this.Request.Headers);
            if (jwtToken == null)
            {
                logger.Warn("Format des Authorization-Headers ungültig für {request-method} {request-path}.", this.Request.Method, this.Request.Path);
                return AuthenticateResult.Fail("Format of authorization header invalid");
            }

            // Parse and validate JWT-Token
            IAdminAccessTokenJwtData adminAccessTokenJwtData;
            try
            {
                adminAccessTokenJwtData = this.jwtTokenHandler.ExtractAdminAccessToken(jwtToken);
            }
            catch
            {
                logger.Info("Ungültiger oder abgelaufener Session-Token für {request-method} {request-path}.", this.Request.Method, this.Request.Path);
                return AuthenticateResult.Fail("Token invalid");
            }

            // Get AdminAccessToken from database (Whitelist-Check)
            ILogicResult<IAdminAccessToken> adminAccessTokenResult = this.adminAccessTokenCrudLogic.GetAdminAccessToken(adminAccessTokenJwtData.Id);
            if (!adminAccessTokenResult.IsSuccessful)
            {
                logger.Info("Ungültiger oder abgelaufener Session-Token für {request-method} {request-path}.", this.Request.Method, this.Request.Path);
                return AuthenticateResult.Fail("Token invalid");
            }

            // Create AuthenticationTicket from Access Token
            AuthenticationTicket ticket = this.CreateAuthenticationTicketFromValidAdminAccessToken(adminAccessTokenResult.Data);

            return AuthenticateResult.Success(ticket);
        }

        private bool IsNoTokenProvided(IHeaderDictionary headers)
        {
            return !headers["Authorization"].Any();
        }

        private string ExtractJwtToken(IHeaderDictionary headers)
        {
            var authorizationHeaderValue = headers["Authorization"].ToString().Split(" ");

            if (authorizationHeaderValue.Length != 2 || authorizationHeaderValue[0] != "Bearer")
            {
                return null;
            }

            string token = authorizationHeaderValue[1];
            return token;
        }

        private AuthenticationTicket CreateAuthenticationTicketFromValidAdminAccessToken(IAdminAccessToken adminAccessToken)
        {
            List<Claim> claims = this.GenerateClaimsFromAdminAccessToken(adminAccessToken);

            ClaimsPrincipal principal = new ClaimsPrincipal();
            principal.AddIdentity(new ClaimsIdentity(claims, JwtTokenAuthentication.Scheme));

            var ticket = new AuthenticationTicket(principal, this.Scheme.Name);
            return ticket;
        }

        private List<Claim> GenerateClaimsFromAdminAccessToken(IAdminAccessToken adminAccessToken)
        {
            // Detault Claims
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, adminAccessToken.Username),
                new Claim(CustomClaimTypes.AdminAccessTokenId, adminAccessToken.Id.ToString()),
                new Claim(CustomClaimTypes.AdminRefreshTokenId, adminAccessToken.AdminRefreshTokenId.ToString()),
                new Claim(CustomClaimTypes.AdminEmailUserId, adminAccessToken.AdminEmailUserId.ToString()),
                new Claim(CustomClaimTypes.AdminAdUserId, adminAccessToken.AdminAdUserId.ToString()),
                new Claim(CustomClaimTypes.AdminAdGroupIds, string.Join(CustomClaimTypesConstants.AdminAdGroupIdsSeperator, adminAccessToken.AdminAdGroupIds)),
            };

            // Permission-Claims
            List<string> permissions = this.ExtractAllowedPermissions(adminAccessToken.CachedPermissions);
            claims.AddRange(permissions.Select(permissions => new Claim(CustomClaimTypes.Permissions, permissions)));

            return claims;
        }

        private List<string> ExtractAllowedPermissions(IDictionary<string, PermissionStatus> permissions)
        {
            return permissions
                .Where(keyValue => keyValue.Value == PermissionStatus.ALLOW)
                .Select(keyValue => keyValue.Key)
                .ToList();
        }
    }
}

#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously