namespace Finanzuebersicht.Backend.Admin.Core.API.Security.Authorization
{
    public static class CustomClaimTypes
    {
        public const string Permissions = "ClaimTypes.Finanzuebersicht.Backend.Admin.Core.Permissions";
        public const string AdminEmailUserId = "ClaimTypes.Finanzuebersicht.Backend.Admin.Core.AdminEmailUserId";
        public const string AdminAdUserId = "ClaimTypes.Finanzuebersicht.Backend.Admin.Core.AdminAdUserId";
        public const string AdminAdGroupIds = "ClaimTypes.Finanzuebersicht.Backend.Admin.Core.AdminAdGroupIds";
        public const string AdminAccessTokenId = "ClaimTypes.Finanzuebersicht.Backend.Admin.Core.AdminAccessTokenId";
        public const string AdminRefreshTokenId = "ClaimTypes.Finanzuebersicht.Backend.Admin.Core.AdminRefreshTokenId";
    }
}