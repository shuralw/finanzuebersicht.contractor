namespace Finanzuebersicht.Backend.Admin.Core.Contract.Logic.SystemConnections.Email
{
    public interface IEmailClient
    {
        void Send(IEmail email);
    }
}