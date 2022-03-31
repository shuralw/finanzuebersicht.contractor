﻿using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminSessionManagement.AdminRefreshTokens;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminSessionManagement.AdminRefreshTokens;
using System;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Modules.AdminSessionManagement.AdminRefreshTokens
{
    internal class AdminRefreshToken : IAdminRefreshToken
    {
        public Guid Id { get; set; }

        public Guid? AdminEmailUserId { get; set; }

        public Guid? AdminAdUserId { get; set; }

        public IEnumerable<Guid> AdminAdGroupIds { get; set; }

        public string Username { get; set; }

        public DateTime ExpiresOn { get; set; }

        internal static IAdminRefreshToken FromDbAdminRefreshToken(IDbAdminRefreshToken dbAdminRefreshToken)
        {
            return new AdminRefreshToken()
            {
                Id = dbAdminRefreshToken.Id,
                AdminEmailUserId = dbAdminRefreshToken.AdminEmailUserId,
                AdminAdUserId = dbAdminRefreshToken.AdminAdUserId,
                AdminAdGroupIds = dbAdminRefreshToken.AdminAdGroupIds,
                Username = dbAdminRefreshToken.Username,
                ExpiresOn = dbAdminRefreshToken.ExpiresOn,
            };
        }
    }
}