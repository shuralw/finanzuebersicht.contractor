using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.AdminUserManagement.AdminAdGroups;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.AdminUserManagement.AdminAdUsers;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.AdminUserManagement.AdminEmailUsers;
using System;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.AdminSessionManagement.AdminRefreshTokens
{
    public class AdminRefreshTokenTestValues
    {
        public static readonly Guid IdDbDefault = Guid.Parse("058fa7f4-901f-42f7-8cf4-4f5f56ac189e");
        public static readonly Guid IdDbDefault2 = Guid.Parse("8ce302a3-aae7-4538-b43c-5fe7ac090c80");
        public static readonly Guid IdForCreate = Guid.Parse("7fda15ee-b222-443e-a5fb-5e95db887f5d");
        public static readonly Guid IdForUpdate = Guid.Parse("531ebb77-d1df-46c2-b222-cfc441b571df");

        public static readonly string UsernameDbDefault = "UsernameDbDefault";
        public static readonly string UsernameDbDefault2 = "UsernameDbDefault2";
        public static readonly string UsernameForCreate = "UsernameForCreate";
        public static readonly string UsernameForUpdate = "UsernameForUpdate";

        public static readonly DateTime ExpiresOnDbDefault = new DateTime(2018, 7, 26);
        public static readonly DateTime ExpiresOnDbDefault2 = new DateTime(2014, 3, 6);
        public static readonly DateTime ExpiresOnForCreate = new DateTime(2020, 10, 31);
        public static readonly DateTime ExpiresOnForUpdate = new DateTime(2021, 1, 15);
        public static readonly DateTime ExpiresCheck = new DateTime(2016, 3, 6);

        public static readonly Guid AdminEmailUserIdDbDefault = AdminEmailUserTestValues.IdDbDefault;
        public static readonly Guid AdminEmailUserIdDbDefault2 = AdminEmailUserTestValues.IdDbDefault2;
        public static readonly Guid AdminEmailUserIdForCreate = AdminEmailUserTestValues.IdForCreate;
        public static readonly Guid AdminEmailUserIdForUpdate = AdminEmailUserTestValues.IdDbDefault;

        public static readonly Guid AdminAdUserIdDbDefault = AdminAdUserTestValues.IdDbDefault;
        public static readonly Guid AdminAdUserIdDbDefault2 = AdminAdUserTestValues.IdDbDefault2;
        public static readonly Guid AdminAdUserIdForCreate = AdminAdUserTestValues.IdForCreate;
        public static readonly Guid AdminAdUserIdForUpdate = AdminAdUserTestValues.IdDbDefault;

        public static readonly IEnumerable<Guid> AdminAdGroupIdsDbDefault = new Guid[] { AdminAdGroupTestValues.IdDbDefault };
        public static readonly IEnumerable<Guid> AdminAdGroupIdsDbDefault2 = new Guid[] { AdminAdGroupTestValues.IdDbDefault2 };
        public static readonly IEnumerable<Guid> AdminAdGroupIdsForCreate = new Guid[] { AdminAdGroupTestValues.IdForCreate };
        public static readonly IEnumerable<Guid> AdminAdGroupIdsForUpdate = new Guid[] { AdminAdGroupTestValues.IdDbDefault };
    }
}