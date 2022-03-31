using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.AdminUserManagement.AdminEmailUsers;
using System;

namespace Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.AdminLoginSystem.AdminEmailUserFailedLoginAttempts
{
    public class AdminEmailUserFailedLoginAttemptTestValues
    {
        public static readonly DateTime OccurredAtDbDefault = new DateTime(2018, 10, 2);
        public static readonly DateTime OccurredAtDbDefault2 = new DateTime(2015, 11, 7);
        public static readonly DateTime OccurredAtDbDefault3 = new DateTime(2013, 9, 7);
        public static readonly DateTime OccurredAtForCreate = new DateTime(2017, 1, 14);
        public static readonly DateTime OccurredAtForUpdate = new DateTime(2021, 1, 4);

        public static readonly Guid AdminEmailUserIdDbDefault = AdminEmailUserTestValues.IdDbDefault;
        public static readonly Guid AdminEmailUserIdDbDefault2 = AdminEmailUserTestValues.IdDbDefault2;
        public static readonly Guid AdminEmailUserIdDbDefault3 = AdminEmailUserTestValues.IdDbDefault;
        public static readonly Guid AdminEmailUserIdForCreate = AdminEmailUserTestValues.IdForCreate;
        public static readonly Guid AdminEmailUserIdForUpdate = AdminEmailUserTestValues.IdDbDefault2;
    }
}