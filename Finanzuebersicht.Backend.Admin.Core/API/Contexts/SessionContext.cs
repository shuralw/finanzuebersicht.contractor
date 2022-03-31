using Microsoft.AspNetCore.Http;
using Finanzuebersicht.Backend.Admin.Core.API.Security.Authorization;
using Finanzuebersicht.Backend.Admin.Core.Contract.Contexts;
using System;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Admin.Core.API.Contexts
{
    public class SessionContext : ISessionContext
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public SessionContext(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public bool IsAuthenticated
        {
            get
            {
                return this.httpContextAccessor.HttpContext.User.Identity.IsAuthenticated;
            }
        }

        public Guid? AdminEmailUserId
        {
            get
            {
                return this.httpContextAccessor.HttpContext.User.GetAdminEmailUserId();
            }
        }

        public Guid? AdminAdUserId
        {
            get
            {
                return this.httpContextAccessor.HttpContext.User.GetAdminAdUserId();
            }
        }

        public IEnumerable<Guid> AdminAdGroupIds
        {
            get
            {
                return this.httpContextAccessor.HttpContext.User.GetAdminAdGroupIds();
            }
        }

        public Guid AdminAccessTokenId
        {
            get
            {
                return this.httpContextAccessor.HttpContext.User.GetAdminAccessTokenId();
            }
        }

        public Guid AdminRefreshTokenId
        {
            get
            {
                return this.httpContextAccessor.HttpContext.User.GetAdminRefreshTokenId();
            }
        }

        public string UserName
        {
            get
            {
                return this.httpContextAccessor.HttpContext.User.GetName();
            }
        }

        public bool HasPermission(string permissionName)
        {
            if (this.httpContextAccessor.HttpContext != null)
            {
                return false;
            }

            return this.httpContextAccessor.HttpContext.User.HasPermission(permissionName);
        }
    }
}