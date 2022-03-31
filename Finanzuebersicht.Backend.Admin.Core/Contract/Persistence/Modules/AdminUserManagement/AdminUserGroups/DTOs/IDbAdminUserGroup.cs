﻿using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.Permissions;
using System;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminUserGroups
{
    public interface IDbAdminUserGroup
    {
        Guid Id { get; set; }

        string Name { get; set; }

        IDictionary<string, PermissionStatus> Permissions { get; set; }
    }
}