using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.SystemConnections.SsoAuthentication;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.SystemConnections.SsoAuthentication
{
    internal class SsoValidationResponse : ISsoValidationResponse
    {
        public string Nutzername { get; set; }

        public List<string> EnthalteneGruppen { get; set; }

        public List<string> NichtEnthalteneGruppen { get; set; }
    }
}