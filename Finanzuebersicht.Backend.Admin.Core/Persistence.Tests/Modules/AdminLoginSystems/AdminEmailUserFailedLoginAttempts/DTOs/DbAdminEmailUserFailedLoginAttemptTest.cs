using Microsoft.VisualStudio.TestTools.UnitTesting;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminLoginSystem.AdminEmailUserFailedLoginAttempts;
using System;

namespace Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.AdminLoginSystem.AdminEmailUserFailedLoginAttempts
{
    internal class DbAdminEmailUserFailedLoginAttemptTest : IDbAdminEmailUserFailedLoginAttempt
    {
        public Guid Id { get; set; }

        public DateTime OccurredAt { get; set; }

        public Guid AdminEmailUserId { get; set; }

        public static IDbAdminEmailUserFailedLoginAttempt DbDefault()
        {
            return new DbAdminEmailUserFailedLoginAttemptTest()
            {
                OccurredAt = AdminEmailUserFailedLoginAttemptTestValues.OccurredAtDbDefault,
                AdminEmailUserId = AdminEmailUserFailedLoginAttemptTestValues.AdminEmailUserIdDbDefault,
            };
        }

        public static IDbAdminEmailUserFailedLoginAttempt DbDefault2()
        {
            return new DbAdminEmailUserFailedLoginAttemptTest()
            {
                OccurredAt = AdminEmailUserFailedLoginAttemptTestValues.OccurredAtDbDefault2,
                AdminEmailUserId = AdminEmailUserFailedLoginAttemptTestValues.AdminEmailUserIdDbDefault2,
            };
        }

        public static IDbAdminEmailUserFailedLoginAttempt DbDefault3()
        {
            return new DbAdminEmailUserFailedLoginAttemptTest()
            {
                OccurredAt = AdminEmailUserFailedLoginAttemptTestValues.OccurredAtDbDefault3,
                AdminEmailUserId = AdminEmailUserFailedLoginAttemptTestValues.AdminEmailUserIdDbDefault3,
            };
        }

        public static IDbAdminEmailUserFailedLoginAttempt ForCreate()
        {
            return new DbAdminEmailUserFailedLoginAttemptTest()
            {
                OccurredAt = AdminEmailUserFailedLoginAttemptTestValues.OccurredAtForCreate,
                AdminEmailUserId = AdminEmailUserFailedLoginAttemptTestValues.AdminEmailUserIdForCreate,
            };
        }

        public static IDbAdminEmailUserFailedLoginAttempt ForUpdate()
        {
            return new DbAdminEmailUserFailedLoginAttemptTest()
            {
                OccurredAt = AdminEmailUserFailedLoginAttemptTestValues.OccurredAtForUpdate,
                AdminEmailUserId = AdminEmailUserFailedLoginAttemptTestValues.AdminEmailUserIdForUpdate,
            };
        }

        public static void AssertDbDefault(IDbAdminEmailUserFailedLoginAttempt dbAdminEmailUserFailedLoginAttempt)
        {
            Assert.AreEqual(AdminEmailUserFailedLoginAttemptTestValues.OccurredAtDbDefault, dbAdminEmailUserFailedLoginAttempt.OccurredAt);
            Assert.AreEqual(AdminEmailUserFailedLoginAttemptTestValues.AdminEmailUserIdDbDefault, dbAdminEmailUserFailedLoginAttempt.AdminEmailUserId);
        }

        public static void AssertDbDefault2(IDbAdminEmailUserFailedLoginAttempt dbAdminEmailUserFailedLoginAttempt)
        {
            Assert.AreEqual(AdminEmailUserFailedLoginAttemptTestValues.OccurredAtDbDefault2, dbAdminEmailUserFailedLoginAttempt.OccurredAt);
            Assert.AreEqual(AdminEmailUserFailedLoginAttemptTestValues.AdminEmailUserIdDbDefault2, dbAdminEmailUserFailedLoginAttempt.AdminEmailUserId);
        }

        public static void AssertDbDefault3(IDbAdminEmailUserFailedLoginAttempt dbAdminEmailUserFailedLoginAttempt)
        {
            Assert.AreEqual(AdminEmailUserFailedLoginAttemptTestValues.OccurredAtDbDefault3, dbAdminEmailUserFailedLoginAttempt.OccurredAt);
            Assert.AreEqual(AdminEmailUserFailedLoginAttemptTestValues.AdminEmailUserIdDbDefault3, dbAdminEmailUserFailedLoginAttempt.AdminEmailUserId);
        }

        public static void AssertForCreate(IDbAdminEmailUserFailedLoginAttempt dbAdminEmailUserFailedLoginAttempt)
        {
            Assert.AreEqual(AdminEmailUserFailedLoginAttemptTestValues.OccurredAtForCreate, dbAdminEmailUserFailedLoginAttempt.OccurredAt);
            Assert.AreEqual(AdminEmailUserFailedLoginAttemptTestValues.AdminEmailUserIdForCreate, dbAdminEmailUserFailedLoginAttempt.AdminEmailUserId);
        }

        public static void AssertForUpdate(IDbAdminEmailUserFailedLoginAttempt dbAdminEmailUserFailedLoginAttempt)
        {
            Assert.AreEqual(AdminEmailUserFailedLoginAttemptTestValues.OccurredAtForUpdate, dbAdminEmailUserFailedLoginAttempt.OccurredAt);
            Assert.AreEqual(AdminEmailUserFailedLoginAttemptTestValues.AdminEmailUserIdForUpdate, dbAdminEmailUserFailedLoginAttempt.AdminEmailUserId);
        }
    }
}