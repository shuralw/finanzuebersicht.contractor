using Finanzuebersicht.Backend.Generated.Persistence.Tests.Modules.UserManagement.EmailUsers;
using System;

namespace Finanzuebersicht.Backend.Generated.Persistence.Tests.Modules.Accounting.StartSalden
{
    public class StartSaldoTestValues
    {
        public static readonly Guid IdDbDefault = Guid.Parse("ef30a8a6-faa7-c1a7-1bee-ee71816a9a26");
        public static readonly Guid IdDbDefault2 = Guid.Parse("88bd5dde-e2b6-e598-68d3-d8fd1ba6067a");
        public static readonly Guid IdForCreate = Guid.Parse("1ff4943c-ab43-d575-919e-1114074febcb");

        public static readonly Guid EmailUserIdDbDefault = EmailUserTestValues.IdDbDefault;

        public static readonly double BetragDbDefault = 56.30165;
        public static readonly double BetragDbDefault2 = 85.38635;
        public static readonly double BetragForCreate = 94.85030;
        public static readonly double BetragForUpdate = 10.63794;

        public static readonly DateTime DatumAmDbDefault = new DateTime(2015, 3, 27);
        public static readonly DateTime DatumAmDbDefault2 = new DateTime(2018, 12, 8);
        public static readonly DateTime DatumAmForCreate = new DateTime(2011, 12, 9);
        public static readonly DateTime DatumAmForUpdate = new DateTime(2016, 11, 9);
    }
}