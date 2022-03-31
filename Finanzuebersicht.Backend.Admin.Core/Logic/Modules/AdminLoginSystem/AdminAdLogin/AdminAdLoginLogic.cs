using Microsoft.Extensions.Logging;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.LogicResults;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminLoginSystem.Ad;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminSessionManagement.AdminRefreshTokens;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.SystemConnections.SsoAuthentication;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminAdGroups;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminAdUsers;
using Finanzuebersicht.Backend.Admin.Core.Logic.LogicResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Modules.AdminLoginSystem.AdminAdLogin
{
    internal class AdminAdLoginLogic : IAdminAdLoginLogic
    {
        private readonly IAdminRefreshTokensCrudLogic adminRefreshTokensCrudLogic;
        private readonly IAdminAdUsersCrudRepository adminAdUsersCrudRepository;
        private readonly IAdminAdGroupsCrudRepository adminAdGroupsCrudRepository;

        private readonly ISsoAuthenticationClient ssoAuthenticationClient;
        private readonly ILogger<AdminAdLoginLogic> logger;

        public AdminAdLoginLogic(
            IAdminRefreshTokensCrudLogic adminRefreshTokensCrudLogic,
            IAdminAdUsersCrudRepository adminAdUsersCrudRepository,
            IAdminAdGroupsCrudRepository adminAdGroupsCrudRepository,
            ISsoAuthenticationClient ssoAuthenticationClient,
            ILogger<AdminAdLoginLogic> logger)
        {
            this.adminRefreshTokensCrudLogic = adminRefreshTokensCrudLogic;
            this.adminAdUsersCrudRepository = adminAdUsersCrudRepository;
            this.adminAdGroupsCrudRepository = adminAdGroupsCrudRepository;

            this.ssoAuthenticationClient = ssoAuthenticationClient;
            this.logger = logger;
        }

        public async Task<ILogicResult<IAdminRefreshTokenDetail>> LoginWithSsoToken(string token)
        {
            List<IDbAdminAdGroup> adminAdGroups = this.adminAdGroupsCrudRepository.GetGlobalAdminAdGroups().ToList();
            List<string> allAdminAdGroupDns = adminAdGroups.Select(adminAdGroup => adminAdGroup.Dn).Distinct().ToList();

            ISsoValidationResponse ssoResponse = await this.ssoAuthenticationClient.GetUsernameAndAdminUserGroupsFromSsoToken(token, allAdminAdGroupDns);
            if (ssoResponse == null)
            {
                this.logger.LogWarning("SSO-Token ungültig");
                return LogicResult<IAdminRefreshTokenDetail>.Forbidden("SSO-Token ungültig");
            }

            List<IDbAdminAdUser> availableAdminAdUsers = this.adminAdUsersCrudRepository.GetGlobalAdminAdUsers(ssoResponse.Nutzername).ToList();
            List<IDbAdminAdGroup> availableAdminAdGroups = this.ExtractAdminAdGroups(adminAdGroups, ssoResponse);

            Guid? adminAdUserId = availableAdminAdUsers.FirstOrDefault()?.Id;
            List<Guid> adminAdGroupIds = availableAdminAdGroups.Select(adminAdGroup => adminAdGroup.Id).ToList();

            Guid adminRefreshTokenId = this.adminRefreshTokensCrudLogic
                .CreateAdminRefreshTokenForAd(adminAdUserId, adminAdGroupIds, ssoResponse.Nutzername);

            IAdminRefreshTokenDetail adminRefreshTokenDetail = this.adminRefreshTokensCrudLogic.GetAdminRefreshToken(adminRefreshTokenId).Data;

            this.logger.LogInformation(
                $"AD-Login erfolgreich für {adminRefreshTokenDetail.Username}");

            return LogicResult<IAdminRefreshTokenDetail>.Ok(adminRefreshTokenDetail);
        }

        private List<IDbAdminAdGroup> ExtractAdminAdGroups(List<IDbAdminAdGroup> adminAdGroups, ISsoValidationResponse response)
        {
            return response.EnthalteneGruppen
                .SelectMany(dn => adminAdGroups.FindAll(adminAdGroup => adminAdGroup.Dn == dn))
                .ToList();
        }
    }
}