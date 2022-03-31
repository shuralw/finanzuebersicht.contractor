using System;

namespace Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Tools.Identifier
{
    public interface IGuidGenerator
    {
        Guid NewGuid();
    }
}