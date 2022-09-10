using System;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.Accounting
{
    public class BuchungssummeAmTagTestValues
    {
        public static readonly Guid IdFirstDay1 = Guid.Parse("4b8e4f37-969e-4321-bd75-4d96ee416ed0");
        public static readonly Guid IdSecondRegular = Guid.Parse("3a4c5b62-fd90-43cd-8c82-e7191222b10f");
        public static readonly Guid IdThirdNegative = Guid.Parse("ec84fa40-d428-43b3-8010-63e24a570891");
        public static readonly Guid IdFourthSameDayAsThird = Guid.Parse("890d8066-3010-443b-91de-5e7a7f1a4810");
        public static readonly Guid IdFifthDay28 = Guid.Parse("9a32fc16-7940-4d47-945c-2714e6c2574e");
        public static readonly Guid IdSixthOutOfRange = Guid.Parse("25688735-e8b8-40d4-9d12-8594a63604a5");

        public static readonly DateTime BuchungsdatumFirstDay1 = new DateTime(2022, 02, 01);
        public static readonly DateTime BuchungsdatumSecondRegular = new DateTime(2022, 02, 11);
        public static readonly DateTime BuchungsdatumThirdNegative = new DateTime(2022, 02, 19);
        public static readonly DateTime BuchungsdatumFourthSameDayAsThird = new DateTime(2022, 02, 19);
        public static readonly DateTime BuchungsdatumFifthDay28 = new DateTime(2022, 02, 28);
        public static readonly DateTime BuchungsdatumSixthOutOfRange = new DateTime(2022, 04, 01);

        public static readonly decimal SummeFirstDay1 = 1.00M;
        public static readonly decimal SummeSecondRegular = 20.50M;
        public static readonly decimal SummeThirdNegative = -300.00M;
        public static readonly decimal SummeFourtFourthSameDayAsThird = 4000.00M;
        public static readonly decimal SummeFifthFifthDay28 = 50000.00M;
        public static readonly decimal SummeSixthSixthOutOfRange = 600000.00M;

        public static readonly DateTime FromDate = new DateTime(2022, 02, 01);
        public static readonly DateTime ToDate = new DateTime(2022, 02, 28);
    }
}
