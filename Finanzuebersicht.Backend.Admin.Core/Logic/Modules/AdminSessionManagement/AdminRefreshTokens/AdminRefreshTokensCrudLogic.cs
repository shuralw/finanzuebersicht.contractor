using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.LogicResults;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminSessionManagement.AdminRefreshTokens;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Tools.Identifier;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Tools.Time;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminSessionManagement.AdminRefreshTokens;
using Finanzuebersicht.Backend.Admin.Core.Logic.LogicResults;
using System;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Modules.AdminSessionManagement.AdminRefreshTokens
{
    internal class AdminRefreshTokensCrudLogic : IAdminRefreshTokensCrudLogic
    {
        private readonly IAdminRefreshTokensCrudRepository adminRefreshTokensCrudRepository;

        private readonly IDateTimeProvider dateTimeProvider;
        private readonly IGuidGenerator guidGenerator;

        private readonly ILogger<AdminRefreshTokensCrudLogic> logger;

        private readonly AdminRefreshTokenOptions options;

        public AdminRefreshTokensCrudLogic(
            IAdminRefreshTokensCrudRepository adminRefreshTokensCrudRepository,
            IGuidGenerator guidGenerator,
            IDateTimeProvider dateTimeProvider,
            ILogger<AdminRefreshTokensCrudLogic> logger,
            IOptions<AdminRefreshTokenOptions> options)
        {
            this.adminRefreshTokensCrudRepository = adminRefreshTokensCrudRepository;

            this.guidGenerator = guidGenerator;
            this.dateTimeProvider = dateTimeProvider;

            this.logger = logger;

            this.options = options.Value;
        }

        public Guid CreateAdminRefreshTokenForAd(Guid? adminAdUserId, IEnumerable<Guid> adminAdGroupIds, string username)
        {
            Guid adminRefreshTokenId = this.CreateDbAdminRefreshToken(null, adminAdUserId, adminAdGroupIds, username);
            this.logger.LogDebug("AdminRefreshToken für AD-User erstellt");
            return adminRefreshTokenId;
        }

        public Guid CreateAdminRefreshTokenForAdminEmailUser(Guid adminEmailUserId, string username)
        {
            Guid adminRefreshTokenId = this.CreateDbAdminRefreshToken(adminEmailUserId, null, null, username);
            this.logger.LogDebug("AdminRefreshToken für Email-User erstellt");
            return adminRefreshTokenId;
        }

        public ILogicResult<IAdminRefreshTokenDetail> GetAdminRefreshToken(Guid id)
        {
            IDbAdminRefreshToken dbAdminRefreshToken = this.adminRefreshTokensCrudRepository.GetAdminRefreshToken(id);
            if (dbAdminRefreshToken == null || dbAdminRefreshToken.ExpiresOn <= this.dateTimeProvider.Now())
            {
                this.logger.LogDebug("AdminRefreshToken konnte nicht gefunden werden.");
                return LogicResult<IAdminRefreshTokenDetail>.NotFound("AdminRefreshToken konnte nicht gefunden werden.");
            }

            IAdminRefreshTokenDetail adminRefreshTokenDetail = AdminRefreshTokenDetail.FromDbAdminRefreshTokenDetail(dbAdminRefreshToken);

            this.logger.LogDebug("AdminRefreshToken wurde geladen");
            return LogicResult<IAdminRefreshTokenDetail>.Ok(adminRefreshTokenDetail);
        }

        public ILogicResult DeleteAdminRefreshToken(Guid adminRefreshTokenId)
        {
            if (!this.adminRefreshTokensCrudRepository.DoesAdminRefreshTokenExist(adminRefreshTokenId))
            {
                this.logger.LogDebug("AdminRefreshToken konnte nicht gefunden werden");
                return LogicResult.NotFound("AdminRefreshToken konnte nicht gefunden werden.");
            }

            this.adminRefreshTokensCrudRepository.DeleteAdminRefreshToken(adminRefreshTokenId);

            this.logger.LogDebug("AdminRefreshToken wurde gelöscht");
            return LogicResult.Ok();
        }

        private Guid CreateDbAdminRefreshToken(Guid? adminEmailUserId, Guid? adminAdUserId, IEnumerable<Guid> adminAdGroupIds, string username)
        {
            IDbAdminRefreshToken dbAdminRefreshToken = new DbAdminRefreshToken()
            {
                Id = this.guidGenerator.NewGuid(),
                AdminEmailUserId = adminEmailUserId,
                AdminAdUserId = adminAdUserId,
                AdminAdGroupIds = adminAdGroupIds ?? new List<Guid>(),
                ExpiresOn = this.dateTimeProvider.Now().AddMinutes(this.options.ExpirationTimeInMinutes),
                Username = username,
            };
            this.adminRefreshTokensCrudRepository.CreateAdminRefreshToken(dbAdminRefreshToken);

            return dbAdminRefreshToken.Id;
        }
    }
}