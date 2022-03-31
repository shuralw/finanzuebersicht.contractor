using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Tools.Pagination;
using System;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminAdUsers
{
    public interface IAdminAdUsersCrudRepository
    {
        void CreateAdminAdUser(IDbAdminAdUser adminAdUser);

        void DeleteAdminAdUser(Guid adminAdUserId);

        bool DoesAdminAdUserExist(string dn);

        IDbAdminAdUser GetAdminAdUser(Guid adminAdUserId);

        IDbPagedResult<IDbAdminAdUser> GetPagedAdminAdUsers();

        IDbAdminAdUser GetGlobalAdminAdUser(Guid adminAdUserId);

        IEnumerable<IDbAdminAdUser> GetGlobalAdminAdUsers(string dn);

        void UpdateAdminAdUser(IDbAdminAdUser adminAdUser);
    }
}