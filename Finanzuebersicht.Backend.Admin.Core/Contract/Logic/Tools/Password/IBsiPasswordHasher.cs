namespace Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Tools.Password
{
    public interface IBsiPasswordHasher
    {
        bool ComparePasswords(string passwordToHash, string passwordHash, string passwordSalt);

        IBsiPasswordHash HashPassword(string password);

        IBsiPasswordHash HashPassword(string password, string salt);
    }
}