using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Tools.Password;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Tools.Password
{
    internal class BsiPasswordHasher : IBsiPasswordHasher
    {
        public bool ComparePasswords(string passwordToHash, string passwordHash, string passwordSalt)
        {
            PBKDF2Service cryptoService = new PBKDF2Service();

            string passwordHash2 = cryptoService.Compute(passwordToHash, passwordSalt);

            bool isPasswordValid = cryptoService.Compare(passwordHash, passwordHash2);

            return isPasswordValid;
        }

        public IBsiPasswordHash HashPassword(string password)
        {
            BsiPasswordHash passwordHash = new BsiPasswordHash();

            PBKDF2Service cryptoService = new PBKDF2Service();
            passwordHash.Salt = cryptoService.GenerateSalt();
            passwordHash.PasswordHash = cryptoService.Compute(password);

            return passwordHash;
        }

        public IBsiPasswordHash HashPassword(string password, string salt)
        {
            BsiPasswordHash passwordHash = new BsiPasswordHash();

            PBKDF2Service cryptoService = new PBKDF2Service();
            passwordHash.Salt = salt;
            passwordHash.PasswordHash = cryptoService.Compute(password, salt);

            return passwordHash;
        }
    }
}