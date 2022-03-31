using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.SystemConnections.Email;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.SystemConnections.Email
{
    internal class Email : IEmail
    {
        public string To { get; set; }

        public string Subject { get; set; }

        public string Message { get; set; }
    }
}