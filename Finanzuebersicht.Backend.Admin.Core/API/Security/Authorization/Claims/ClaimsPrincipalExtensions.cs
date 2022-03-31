using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Finanzuebersicht.Backend.Admin.Core.API.Security.Authorization
{
    public static class ClaimsPrincipalExtensions
    {
        public static Guid? GetAdminEmailUserId(this ClaimsPrincipal principal)
        {
            if (!Guid.TryParse(principal.FindFirstValue(CustomClaimTypes.AdminEmailUserId), out Guid adminEmailUserId))
            {
                return null;
            }

            return adminEmailUserId;
        }

        public static Guid? GetAdminAdUserId(this ClaimsPrincipal principal)
        {
            if (!Guid.TryParse(principal.FindFirstValue(CustomClaimTypes.AdminAdUserId), out Guid adminAdUserId))
            {
                return null;
            }

            return adminAdUserId;
        }

        public static IEnumerable<Guid> GetAdminAdGroupIds(this ClaimsPrincipal principal)
        {
            string adminAdGroupIdsString = principal.FindFirstValue(CustomClaimTypes.AdminAdGroupIds);
            if (!adminAdGroupIdsString.Trim().Any())
            {
                return Array.Empty<Guid>();
            }

            return adminAdGroupIdsString.Split(CustomClaimTypesConstants.AdminAdGroupIdsSeperator)
                .Select(adminAdGroupId => Guid.Parse(adminAdGroupId));
        }

        public static Guid GetAdminRefreshTokenId(this ClaimsPrincipal principal)
        {
            return Guid.Parse(principal.FindFirstValue(CustomClaimTypes.AdminRefreshTokenId));
        }

        public static Guid GetAdminAccessTokenId(this ClaimsPrincipal principal)
        {
            return Guid.Parse(principal.FindFirstValue(CustomClaimTypes.AdminAccessTokenId));
        }

        public static string GetName(this ClaimsPrincipal principal)
        {
            return principal.FindFirstValue(ClaimTypes.Name);
        }

        public static bool HasPermission(this ClaimsPrincipal principal, string permissionName)
        {
            return principal.FindAll(CustomClaimTypes.Permissions)
                .Select(claim => claim.Value)
                .Contains(permissionName);
        }
    }
}