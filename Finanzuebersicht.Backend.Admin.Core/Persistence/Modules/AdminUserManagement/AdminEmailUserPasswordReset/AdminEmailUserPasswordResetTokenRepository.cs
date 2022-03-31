using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminEmailUserPasswordResetTokens;
using System;
using System.Linq;

namespace Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminUserManagement.AdminEmailUserPasswordReset
{
    internal class AdminEmailUserPasswordResetTokenRepository : IAdminEmailUserPasswordResetTokenRepository
    {
        private readonly PersistenceDbContext context;

        public AdminEmailUserPasswordResetTokenRepository(PersistenceDbContext context)
        {
            this.context = context;
        }

        public IDbAdminEmailUserPasswordResetToken GetToken(string token)
        {
            EfAdminEmailUserPasswordResetToken adminEmailUserPasswordResetToken = this.context.AdminEmailUserPasswordResetTokens.Find(token);
            return DbAdminEmailUserPasswordResetToken.FromEfAdminEmailUserPasswordResetToken(adminEmailUserPasswordResetToken);
        }

        public void CreateToken(IDbAdminEmailUserPasswordResetToken adminEmailUserPasswordResetToken)
        {
            EfAdminEmailUserPasswordResetToken efAdminEmailUserPasswordResetToken = DbAdminEmailUserPasswordResetToken.ToEfAdminEmailUserPasswordResetToken(adminEmailUserPasswordResetToken);
            this.context.AdminEmailUserPasswordResetTokens.Add(efAdminEmailUserPasswordResetToken);
            this.context.SaveChanges();
        }

        public void DeleteToken(string token)
        {
            this.context.AdminEmailUserPasswordResetTokens.Remove(this.context.AdminEmailUserPasswordResetTokens.Find(token));
            this.context.SaveChanges();
        }

        public void DeleteToken(DateTime olderThan)
        {
            var tokensToDelete = this.context.AdminEmailUserPasswordResetTokens
                .Where(attempt => attempt.ExpiresOn < olderThan);

            this.context.AdminEmailUserPasswordResetTokens.RemoveRange(tokensToDelete);
            this.context.SaveChanges();
        }
    }
}