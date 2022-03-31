using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Tools.Pagination;
using System;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminAdGroups
{
    public interface IAdminAdGroupsCrudRepository
    {
        void CreateAdminAdGroup(IDbAdminAdGroup adminAdGroup);

        void DeleteAdminAdGroup(Guid adminAdGroupId);

        bool DoesAdminAdGroupExist(string dn);

        IDbAdminAdGroup GetAdminAdGroup(Guid adminAdGroupId);

        IDbPagedResult<IDbAdminAdGroup> GetPagedAdminAdGroups();

        IDbAdminAdGroup GetGlobalAdminAdGroup(Guid adminAdGroupId);

        IEnumerable<IDbAdminAdGroup> GetGlobalAdminAdGroups();

        IEnumerable<IDbAdminAdGroup> GetGlobalAdminAdGroups(string dn);

        void UpdateAdminAdGroup(IDbAdminAdGroup adminAdGroup);
    }
}