using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Tools.Identifier;
using System;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Tools.Identifier
{
    internal class GuidGenerator : IGuidGenerator
    {
        public Guid NewGuid()
        {
            return Guid.NewGuid();
        }
    }
}