using Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.AdminUserManagement.AdminEmailUsers;
using System;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.AdminUserManagement.AdminEmailUserPasswordReset
{
    public class AdminEmailUserPasswordResetTokenTestValues
    {
        public static readonly string TokenDefault = "TokenDefault";
        public static readonly string TokenDefault2 = "TokenDefault2";
        public static readonly string TokenForCreate = "TokenForCreate";

        public static readonly DateTime ExpiresOnDefault = new DateTime(2019, 7, 31);
        public static readonly DateTime ExpiresOnDefault2 = new DateTime(2015, 7, 31);
        public static readonly DateTime ExpiresOnForCreate = new DateTime(2018, 1, 9, 1, 0, 0);

        public static readonly DateTime ExpirationNow = new DateTime(2018, 1, 9);

        public static readonly Guid AdminEmailUserIdDefault = AdminEmailUserTestValues.IdDefault;
        public static readonly Guid AdminEmailUserIdDefault2 = AdminEmailUserTestValues.IdDefault;
        public static readonly Guid AdminEmailUserIdForCreate = AdminEmailUserTestValues.IdDefault;
    }
}