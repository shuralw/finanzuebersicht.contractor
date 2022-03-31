using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.LogicResults;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminSessionManagement.AdminAccessTokens;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminSessionManagement.AdminRefreshTokens;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.Permissions;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Tools.Identifier;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Tools.Time;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminSessionManagement.AdminAccessTokens;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminSessionManagement.AdminRefreshTokens;
using Finanzuebersicht.Backend.Admin.Core.Logic.LogicResults;
using Finanzuebersicht.Backend.Admin.Core.Logic.Modules.AdminSessionManagement.AdminRefreshTokens;
using Finanzuebersicht.Backend.Admin.Core.Logic.Modules.AdminUserManagement.Permissions;
using System;
using System.Linq;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Modules.AdminSessionManagement.AdminAccessTokens
{
    internal class AdminAccessTokensCrudLogic : IAdminAccessTokensCrudLogic
    {
        private readonly IAdminAccessTokensCrudRepository adminAccessTokensCrudRepository;
        private readonly IAdminRefreshTokensCrudRepository adminRefreshTokensCrudRepository;
        private readonly IAdminEmailUserPermissionsCalculationLogic adminEmailUserPermissionsCalculationLogic;
        private readonly IAdPermissionsCalculationLogic adPermissionsCalculationLogic;

        private readonly IGuidGenerator guidGenerator;
        private readonly IDateTimeProvider dateTimeProvider;

        private readonly ILogger<AdminAccessTokensCrudLogic> logger;

        private readonly AdminAccessTokenOptions options;

        public AdminAccessTokensCrudLogic(
            IAdminAccessTokensCrudRepository adminAccessTokensCrudRepository,
            IAdminRefreshTokensCrudRepository adminRefreshTokensCrudRepository,
            IAdminEmailUserPermissionsCalculationLogic adminEmailUserPermissionsCalculationLogic,
            IAdPermissionsCalculationLogic adPermissionsCalculationLogic,
            IGuidGenerator guidGenerator,
            IDateTimeProvider dateTimeProvider,
            ILogger<AdminAccessTokensCrudLogic> logger,
            IOptions<AdminAccessTokenOptions> options)
        {
            this.adminAccessTokensCrudRepository = adminAccessTokensCrudRepository;
            this.adminRefreshTokensCrudRepository = adminRefreshTokensCrudRepository;
            this.adminEmailUserPermissionsCalculationLogic = adminEmailUserPermissionsCalculationLogic;
            this.adPermissionsCalculationLogic = adPermissionsCalculationLogic;

            this.guidGenerator = guidGenerator;
            this.dateTimeProvider = dateTimeProvider;

            this.logger = logger;

            this.options = options.Value;
        }

        public ILogicResult<IAdminAccessToken> CreateAdminAccessTokenFromAdminRefreshToken(Guid adminRefreshTokenId)
        {
            IDbAdminRefreshToken dbAdminRefreshToken = this.adminRefreshTokensCrudRepository.GetAdminRefreshToken(adminRefreshTokenId);
            if (dbAdminRefreshToken == null)
            {
                this.logger.LogDebug("AdminRefreshToken konnte nicht gefunden werden");
                return LogicResult<IAdminAccessToken>.NotFound("AdminRefreshToken konnte nicht gefunden werden.");
            }

            IAdminRefreshToken adminRefreshToken = AdminRefreshToken.FromDbAdminRefreshToken(dbAdminRefreshToken);

            DbAdminAccessToken dbAdminAccessToken = this.CreateDbAdminAccessTokenObject(adminRefreshToken);

            this.adminAccessTokensCrudRepository.CreateAdminAccessToken(dbAdminAccessToken);

            return LogicResult<IAdminAccessToken>.Ok(AdminAccessToken.FromDbAdminAccessToken(dbAdminAccessToken));
        }

        public ILogicResult<IAdminAccessToken> GetAdminAccessToken(Guid adminAccessTokenId)
        {
            IDbAdminAccessToken dbAdminAccessToken = this.adminAccessTokensCrudRepository.GetAdminAccessToken(adminAccessTokenId);
            if (dbAdminAccessToken == null || dbAdminAccessToken.ExpiresOn < this.dateTimeProvider.Now())
            {
                this.logger.LogDebug("AdminAccessToken konnte nicht gefunden werden");
                return LogicResult<IAdminAccessToken>.NotFound("AdminAccessToken konnte nicht gefunden werden.");
            }

            return LogicResult<IAdminAccessToken>.Ok(AdminAccessToken.FromDbAdminAccessToken(dbAdminAccessToken));
        }

        public ILogicResult<IAdminAccessTokenDetail> GetAdminAccessTokenDetail(Guid adminAccessTokenId)
        {
            IDbAdminAccessToken dbAdminAccessToken = this.adminAccessTokensCrudRepository.GetAdminAccessToken(adminAccessTokenId);
            if (dbAdminAccessToken == null || dbAdminAccessToken.ExpiresOn < this.dateTimeProvider.Now())
            {
                this.logger.LogDebug("AdminAccessToken konnte nicht gefunden werden");
                return LogicResult<IAdminAccessTokenDetail>.NotFound("AdminAccessToken konnte nicht gefunden werden.");
            }

            return LogicResult<IAdminAccessTokenDetail>.Ok(AdminAccessTokenDetail.FromDbAdminAccessTokenDetail(dbAdminAccessToken));
        }

        private DbAdminAccessToken CreateDbAdminAccessTokenObject(IAdminRefreshToken adminRefreshToken)
        {
            DbAdminAccessToken dbAdminAccessToken = new DbAdminAccessToken()
            {
                Id = this.guidGenerator.NewGuid(),
                AdminRefreshTokenId = adminRefreshToken.Id,
                AdminAdGroupIds = adminRefreshToken.AdminAdGroupIds,
                AdminAdUserId = adminRefreshToken.AdminAdUserId,
                AdminEmailUserId = adminRefreshToken.AdminEmailUserId,
                ExpiresOn = this.dateTimeProvider.Now().AddMinutes(this.options.ExpirationTimeInMinutes),
                Username = adminRefreshToken.Username,
            };

            if (adminRefreshToken.AdminEmailUserId.HasValue)
            {
                dbAdminAccessToken.CachedPermissions = this.adminEmailUserPermissionsCalculationLogic
                    .CalculateStrictPermissionsForAdminEmailUser(adminRefreshToken.AdminEmailUserId.Value);
            }
            else if (adminRefreshToken.AdminAdUserId.HasValue || adminRefreshToken.AdminAdGroupIds.Any())
            {
                dbAdminAccessToken.CachedPermissions = this.adPermissionsCalculationLogic
                    .CalculateStrictPermissionsForAd(adminRefreshToken.AdminAdUserId, adminRefreshToken.AdminAdGroupIds);
            }
            else
            {
                dbAdminAccessToken.CachedPermissions = PermissionsCalculation.GetPermissionsWithStatus(PermissionStatus.DENY);
            }

            return dbAdminAccessToken;
        }
    }
}