using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.SystemConnections.SsoAuthentication
{
    internal class SsoValidationRequest
    {
        public string Sessionkey { get; set; }

        public IEnumerable<string> Groups { get; set; }
    }
}