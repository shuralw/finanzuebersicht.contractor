using System.Collections.Generic;
using System.Threading.Tasks;

namespace Finanzuebersicht.Backend.Admin.Core.Contract.Logic.SystemConnections.SsoAuthentication
{
    public interface ISsoAuthenticationClient
    {
        Task<ISsoValidationResponse> GetUsernameAndAdminUserGroupsFromSsoToken(string token, IEnumerable<string> adminUserGroups);
    }
}