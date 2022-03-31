using System;

namespace Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminLoginSystem.AdminEmailUser
{
    public interface IAdminEmailUserFailedLoginAttemptsLogic
    {
        void AddFailedLoginAttempt(Guid adminEmailUserId);

        bool HasAdminEmailUserTooManyFailedLoginAttempts(Guid adminEmailUserId);

        void RemoveExpiredFailedLoginAttempts();

        void RemoveFailedLoginAttempts(Guid adminEmailUserId);
    }
}