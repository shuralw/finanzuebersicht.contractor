using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Finanzuebersicht.Backend.Admin.Core.API.Security.Authentication
{
    internal class JwtTokenHandler : IJwtTokenHandler
    {
        private readonly JwtTokenAuthenticationOptions options;

        private readonly JwtSecurityTokenHandler jwtSecurityTokenHandler;
        private readonly SymmetricSecurityKey securityKey;
        private readonly TokenValidationParameters tokenValidationParameters;

        public JwtTokenHandler(IOptions<JwtTokenAuthenticationOptions> options)
        {
            this.options = options.Value;

            this.jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            this.securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(this.options.Secret));
            this.tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidIssuer = this.options.Issuer,
                ValidAudience = this.options.Audience,
                IssuerSigningKey = this.securityKey
            };
        }

        public string GenerateJwtToken(IAdminRefreshTokenJwtData adminRefreshTokenJwtData)
        {
            return this.GenerateJwtToken(
                TokenType.AdminRefreshToken,
                adminRefreshTokenJwtData.Id,
                adminRefreshTokenJwtData.Username,
                adminRefreshTokenJwtData.ExpiresOn);
        }

        public string GenerateJwtToken(IAdminAccessTokenJwtData adminAccessTokenJwtData)
        {
            return this.GenerateJwtToken(
                TokenType.AdminAccessToken,
                adminAccessTokenJwtData.Id,
                adminAccessTokenJwtData.Username,
                adminAccessTokenJwtData.ExpiresOn);
        }

        public IAdminRefreshTokenJwtData ExtractAdminRefreshToken(string jwtToken)
        {
            this.jwtSecurityTokenHandler.ValidateToken(jwtToken, this.tokenValidationParameters, out SecurityToken validatedToken);

            JwtSecurityToken jwtSecurityToken = validatedToken as JwtSecurityToken;

            string tokenType = jwtSecurityToken.Payload[JwtTokenClaimKeys.TokenType].ToString();
            if (tokenType != TokenType.AdminRefreshToken)
            {
                throw new SecurityTokenException("TokenType not valid");
            }

            AdminRefreshTokenJwtData adminRefreshTokenJwtData = new AdminRefreshTokenJwtData()
            {
                ExpiresOn = jwtSecurityToken.ValidTo,
                Id = Guid.Parse(jwtSecurityToken.Payload[JwtTokenClaimKeys.Id].ToString()),
                Username = jwtSecurityToken.Payload[JwtTokenClaimKeys.Username].ToString(),
            };

            return adminRefreshTokenJwtData;
        }

        public IAdminAccessTokenJwtData ExtractAdminAccessToken(string jwtToken)
        {
            this.jwtSecurityTokenHandler.ValidateToken(jwtToken, this.tokenValidationParameters, out SecurityToken validatedToken);

            JwtSecurityToken jwtSecurityToken = validatedToken as JwtSecurityToken;

            string tokenType = jwtSecurityToken.Payload[JwtTokenClaimKeys.TokenType].ToString();
            if (tokenType != TokenType.AdminAccessToken)
            {
                throw new SecurityTokenException("TokenType not valid");
            }

            AdminAccessTokenJwtData adminRefreshTokenJwtData = new AdminAccessTokenJwtData()
            {
                ExpiresOn = jwtSecurityToken.ValidTo,
                Id = Guid.Parse(jwtSecurityToken.Payload[JwtTokenClaimKeys.Id].ToString()),
                Username = jwtSecurityToken.Payload[JwtTokenClaimKeys.Username].ToString(),
            };

            return adminRefreshTokenJwtData;
        }

        private string GenerateJwtToken(string tokenType, Guid id, string username, DateTime expiresOn)
        {
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(JwtTokenClaimKeys.TokenType, tokenType),
                    new Claim(JwtTokenClaimKeys.Id, id.ToString()),
                    new Claim(JwtTokenClaimKeys.Username, username),
                }),
                Expires = expiresOn,
                Issuer = this.options.Issuer,
                Audience = this.options.Audience,
                SigningCredentials = new SigningCredentials(this.securityKey, SecurityAlgorithms.HmacSha256Signature)
            };

            var jwtToken = this.jwtSecurityTokenHandler.CreateToken(tokenDescriptor);
            string jwtTokenString = this.jwtSecurityTokenHandler.WriteToken(jwtToken);

            return jwtTokenString;
        }
    }
}