using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminSessionManagement.AdminRefreshTokens;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminSessionManagement.AdminRefreshTokens
{
    internal class DbAdminRefreshToken : IDbAdminRefreshToken
    {
        public Guid Id { get; set; }

        public Guid? AdminEmailUserId { get; set; }

        public Guid? AdminAdUserId { get; set; }

        public IEnumerable<Guid> AdminAdGroupIds { get; set; }

        public string Username { get; set; }

        public DateTime ExpiresOn { get; set; }

        internal static IDbAdminRefreshToken FromEfAdminRefreshToken(EfAdminRefreshToken efAdminRefreshToken)
        {
            if (efAdminRefreshToken == null)
            {
                return null;
            }

            return new DbAdminRefreshToken()
            {
                Id = efAdminRefreshToken.Id,
                AdminEmailUserId = efAdminRefreshToken.AdminEmailUserId,
                AdminAdUserId = efAdminRefreshToken.AdminAdUserId,
                Username = efAdminRefreshToken.Username,
                ExpiresOn = efAdminRefreshToken.ExpiresOn,
                AdminAdGroupIds = efAdminRefreshToken.AdminRefreshTokenAdminAdGroupRelations.Select(relation => relation.AdminAdGroupId)
            };
        }

        internal static EfAdminRefreshToken ToEfAdminRefreshToken(IDbAdminRefreshToken dbAdminRefreshToken)
        {
            return new EfAdminRefreshToken()
            {
                Id = dbAdminRefreshToken.Id,
                AdminEmailUserId = dbAdminRefreshToken.AdminEmailUserId,
                AdminAdUserId = dbAdminRefreshToken.AdminAdUserId,
                Username = dbAdminRefreshToken.Username,
                ExpiresOn = dbAdminRefreshToken.ExpiresOn,
            };
        }
    }
}