using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Tools.Pagination;
using System;

namespace Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminEmailUsers
{
    public interface IAdminEmailUsersCrudRepository
    {
        void CreateAdminEmailUser(IDbAdminEmailUser adminEmailUser);

        void DeleteAdminEmailUser(Guid adminEmailUserId);

        bool DoesAdminEmailUserExist(string mail);

        bool DoesAdminEmailUserExist(Guid adminEmailUserId);

        IDbAdminEmailUser GetAdminEmailUser(Guid adminEmailUserId);

        IDbAdminEmailUser GetAdminEmailUser(string mail);

        IDbPagedResult<IDbAdminEmailUser> GetPagedAdminEmailUsers();

        IDbAdminEmailUser GetGlobalAdminEmailUser(Guid adminEmailUserId);

        void UpdateAdminEmailUser(IDbAdminEmailUser adminEmailUser);

        void UpdateGlobalAdminEmailUser(IDbAdminEmailUser dbAdminEmailUser);
    }
}