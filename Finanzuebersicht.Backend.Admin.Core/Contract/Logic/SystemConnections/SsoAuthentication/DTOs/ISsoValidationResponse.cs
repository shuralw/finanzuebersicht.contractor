using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Admin.Core.Contract.Logic.SystemConnections.SsoAuthentication
{
    public interface ISsoValidationResponse
    {
        List<string> EnthalteneGruppen { get; set; }

        List<string> NichtEnthalteneGruppen { get; set; }

        string Nutzername { get; set; }
    }
}