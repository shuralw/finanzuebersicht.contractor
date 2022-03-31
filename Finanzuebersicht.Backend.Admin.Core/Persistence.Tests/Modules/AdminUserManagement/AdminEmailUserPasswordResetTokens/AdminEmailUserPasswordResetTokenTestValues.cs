using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.AdminUserManagement.AdminEmailUsers;
using System;

namespace Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.AdminUserManagement.AdminEmailUserPasswordResetTokens
{
    public class AdminEmailUserPasswordResetTokenTestValues
    {
        public static readonly string TokenDbDefault = "TokenDbDefault";
        public static readonly string TokenDbDefault2 = "TokenDbDefault2";
        public static readonly string TokenForCreate = "TokenForCreate";
        public static readonly string TokenForUpdate = "TokenForUpdate";

        public static readonly DateTime ExpiresOnDbDefault = new DateTime(2019, 2, 1);
        public static readonly DateTime ExpiresOnDbDefault2 = new DateTime(2012, 6, 11);
        public static readonly DateTime ExpiresOnForCreate = new DateTime(2011, 6, 7);
        public static readonly DateTime ExpiresOnForUpdate = new DateTime(2014, 10, 21);

        public static readonly Guid AdminEmailUserIdDbDefault = AdminEmailUserTestValues.IdDbDefault;
        public static readonly Guid AdminEmailUserIdDbDefault2 = AdminEmailUserTestValues.IdDbDefault2;
        public static readonly Guid AdminEmailUserIdForCreate = AdminEmailUserTestValues.IdForCreate;
        public static readonly Guid AdminEmailUserIdForUpdate = AdminEmailUserTestValues.IdDbDefault2;
    }
}