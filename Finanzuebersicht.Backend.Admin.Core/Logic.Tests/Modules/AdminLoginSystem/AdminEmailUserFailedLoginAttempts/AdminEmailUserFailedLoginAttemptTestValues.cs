using System;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.AdminLoginSystem.AdminEmailUserFailedLoginAttempts
{
    public class AdminEmailUserFailedLoginAttemptTestValues
    {
        public static readonly Guid AdminEmailUserId = Guid.Parse("a4533231-7b3d-44c5-b843-3cc5e6ddc3c6");

        public static readonly int MaxCount = 3;

        public static readonly DateTime OccuredAt1 = new DateTime(2020, 1, 1, 11, 15, 0);
        public static readonly DateTime OccuredAt2 = new DateTime(2020, 1, 1, 11, 30, 0);
        public static readonly DateTime OccuredAt3 = new DateTime(2020, 1, 1, 11, 45, 0);
        public static readonly DateTime OccuredAt4 = new DateTime(2020, 1, 1, 10, 0, 0);

        public static readonly DateTime Now = new DateTime(2020, 1, 1, 12, 0, 0);
        public static readonly DateTime OlderThan = new DateTime(2020, 1, 1, 11, 0, 0);

        public static readonly bool RunOnInitialization = true;

        public static readonly int ThresholdInMinutes = 60;
    }
}