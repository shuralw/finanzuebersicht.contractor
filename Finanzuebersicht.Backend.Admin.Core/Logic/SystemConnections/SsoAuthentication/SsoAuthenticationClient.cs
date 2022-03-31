using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RestSharp;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.SystemConnections.SsoAuthentication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.SystemConnections.SsoAuthentication
{
    internal class SsoAuthenticationClient : ISsoAuthenticationClient
    {
        private readonly ILogger<SsoAuthenticationClient> logger;

        private readonly RestClient restClient;

        public SsoAuthenticationClient(
            ILogger<SsoAuthenticationClient> logger,
            IOptions<SsoAuthenticationOptions> options)
        {
            this.logger = logger;
            this.restClient = new RestClient(options.Value.SsoWebserviceBaseUrl);
        }

        public async Task<ISsoValidationResponse> GetUsernameAndAdminUserGroupsFromSsoToken(string token, IEnumerable<string> adminUserGroups)
        {
            var restRequest = new RestRequest("/validate")
            {
                Resource = "/validate",
                Method = Method.POST
            };

            restRequest.AddQueryParameter("type", "distinguishedname");
            restRequest.AddJsonBody(new SsoValidationRequest()
            {
                Sessionkey = token,
                Groups = adminUserGroups
            });

            this.logger.LogInformation("Zwecks SSO-Authentication wird {url} angefragt", this.restClient.BaseUrl + restRequest.Resource);
            var response = await this.restClient.ExecuteAsync<SsoValidationResponse>(restRequest);
            if (!response.IsSuccessful)
            {
                this.logger.LogInformation("SSO-Authentication nicht erfolgreich");
                return null;
            }

            this.logger.LogInformation("SSO-Authentication erfolgreich für DN ({dn})", response.Data.Nutzername);
            return response.Data;
        }
    }
}