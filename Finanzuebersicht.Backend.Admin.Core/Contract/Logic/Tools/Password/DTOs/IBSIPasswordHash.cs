namespace Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Tools.Password
{
    public interface IBsiPasswordHash
    {
        string PasswordHash { get; set; }

        string Salt { get; set; }
    }
}