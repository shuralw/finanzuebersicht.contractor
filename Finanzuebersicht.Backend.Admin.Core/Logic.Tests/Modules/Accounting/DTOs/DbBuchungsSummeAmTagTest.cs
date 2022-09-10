using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.Accounting.AccountingEntries;
using System;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.Accounting.DTOs
{
    internal class DbBuchungssummeAmTagTest : IDbBuchungssummeAmTag
    {
        public Guid Id { get; set; }

        public DateTime Buchungsdatum { get; set; }

        public decimal Summe { get; set; }

        public static IEnumerable<DbBuchungssummeAmTagTest> Regular()
        {
            return new List<DbBuchungssummeAmTagTest>()
            {
                new DbBuchungssummeAmTagTest
                {
                    Id = BuchungssummeAmTagTestValues.IdSecondRegular,
                    Summe = BuchungssummeAmTagTestValues.SummeSecondRegular,
                    Buchungsdatum = BuchungssummeAmTagTestValues.BuchungsdatumSecondRegular,
                },
            };
        }

        public static IEnumerable<DbBuchungssummeAmTagTest> EdgeDays()
        {
            return new List<DbBuchungssummeAmTagTest>()
            {

                new DbBuchungssummeAmTagTest
                {
                    Id = BuchungssummeAmTagTestValues.IdFirstDay1,
                    Summe = BuchungssummeAmTagTestValues.SummeFirstDay1,
                    Buchungsdatum = BuchungssummeAmTagTestValues.BuchungsdatumFirstDay1,
                },

                new DbBuchungssummeAmTagTest
                {
                    Id = BuchungssummeAmTagTestValues.IdFifthDay28,
                    Summe = BuchungssummeAmTagTestValues.SummeFifthFifthDay28,
                    Buchungsdatum = BuchungssummeAmTagTestValues.BuchungsdatumFifthDay28,
                },
            };
        }

        public static IEnumerable<DbBuchungssummeAmTagTest> RegularPlusNegative()
        {
            return new List<DbBuchungssummeAmTagTest>()
            {
                new DbBuchungssummeAmTagTest
                {
                    Id = BuchungssummeAmTagTestValues.IdSecondRegular,
                    Summe = BuchungssummeAmTagTestValues.SummeSecondRegular,
                    Buchungsdatum = BuchungssummeAmTagTestValues.BuchungsdatumSecondRegular,
                },
                new DbBuchungssummeAmTagTest
                {
                    Id = BuchungssummeAmTagTestValues.IdThirdNegative,
                    Summe = BuchungssummeAmTagTestValues.SummeThirdNegative,
                    Buchungsdatum = BuchungssummeAmTagTestValues.BuchungsdatumThirdNegative,
                },
            };
        }

        public static IEnumerable<DbBuchungssummeAmTagTest> RegularPlusOutOfRange()
        {
            return new List<DbBuchungssummeAmTagTest>()
            {
                new DbBuchungssummeAmTagTest
                {
                    Id = BuchungssummeAmTagTestValues.IdSecondRegular,
                    Summe = BuchungssummeAmTagTestValues.SummeSecondRegular,
                    Buchungsdatum = BuchungssummeAmTagTestValues.BuchungsdatumSecondRegular,
                },
                new DbBuchungssummeAmTagTest
                {
                    Id = BuchungssummeAmTagTestValues.IdSixthOutOfRange,
                    Summe = BuchungssummeAmTagTestValues.SummeSixthSixthOutOfRange,
                    Buchungsdatum = BuchungssummeAmTagTestValues.BuchungsdatumSixthOutOfRange,
                },
            };
        }

        public static IEnumerable<DbBuchungssummeAmTagTest> RegularPlusTwoAtSameDay()
        {
            return new List<DbBuchungssummeAmTagTest>()
            {
                new DbBuchungssummeAmTagTest
                {
                    Id = BuchungssummeAmTagTestValues.IdSecondRegular,
                    Summe = BuchungssummeAmTagTestValues.SummeSecondRegular,
                    Buchungsdatum = BuchungssummeAmTagTestValues.BuchungsdatumSecondRegular,
                },
                new DbBuchungssummeAmTagTest
                {
                    Id = BuchungssummeAmTagTestValues.IdThirdNegative,
                    Summe = BuchungssummeAmTagTestValues.SummeThirdNegative,
                    Buchungsdatum = BuchungssummeAmTagTestValues.BuchungsdatumThirdNegative,
                },
                new DbBuchungssummeAmTagTest
                {
                    Id = BuchungssummeAmTagTestValues.IdFourthSameDayAsThird,
                    Summe = BuchungssummeAmTagTestValues.SummeFourtFourthSameDayAsThird,
                    Buchungsdatum = BuchungssummeAmTagTestValues.BuchungsdatumFourthSameDayAsThird,
                },
            };
        }
    }
}
