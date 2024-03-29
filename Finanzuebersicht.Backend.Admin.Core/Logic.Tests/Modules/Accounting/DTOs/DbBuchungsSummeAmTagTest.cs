﻿using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.Accounting.AccountingEntries;
using System;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.Accounting.DTOs
{
    internal class DbBuchungssummeAmTagTest : IDbBuchungssummeAmTag
    {
        public DateTime Buchungsdatum { get; set; }

        public decimal Summe { get; set; }

        public static IEnumerable<DbBuchungssummeAmTagTest> Regular()
        {
            return new List<DbBuchungssummeAmTagTest>()
            {
                new DbBuchungssummeAmTagTest
                {
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
                    Summe = BuchungssummeAmTagTestValues.SummeFirstDay1,
                    Buchungsdatum = BuchungssummeAmTagTestValues.BuchungsdatumFirstDay1,
                },

                new DbBuchungssummeAmTagTest
                {
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
                    Summe = BuchungssummeAmTagTestValues.SummeSecondRegular,
                    Buchungsdatum = BuchungssummeAmTagTestValues.BuchungsdatumSecondRegular,
                },
                new DbBuchungssummeAmTagTest
                {
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
                    Summe = BuchungssummeAmTagTestValues.SummeSecondRegular,
                    Buchungsdatum = BuchungssummeAmTagTestValues.BuchungsdatumSecondRegular,
                },
                new DbBuchungssummeAmTagTest
                {
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
                    Summe = BuchungssummeAmTagTestValues.SummeSecondRegular,
                    Buchungsdatum = BuchungssummeAmTagTestValues.BuchungsdatumSecondRegular,
                },
                new DbBuchungssummeAmTagTest
                {
                    Summe = BuchungssummeAmTagTestValues.SummeThirdNegative,
                    Buchungsdatum = BuchungssummeAmTagTestValues.BuchungsdatumThirdNegative,
                },
                new DbBuchungssummeAmTagTest
                {
                    Summe = BuchungssummeAmTagTestValues.SummeFourtFourthSameDayAsThird,
                    Buchungsdatum = BuchungssummeAmTagTestValues.BuchungsdatumFourthSameDayAsThird,
                },
            };
        }
    }
}
