using System;

namespace Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.AdminUserGroups
{
    public interface IAdminUserGroup
    {
        Guid Id { get; set; }

        string Name { get; set; }
    }
}