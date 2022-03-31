using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Tools.Password;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Tools.Password
{
    internal class BsiPasswordHash : IBsiPasswordHash
    {
        public string PasswordHash { get; set; }

        public string Salt { get; set; }
    }
}