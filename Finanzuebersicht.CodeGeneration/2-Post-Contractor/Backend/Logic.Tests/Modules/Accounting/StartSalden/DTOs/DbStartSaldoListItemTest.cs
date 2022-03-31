using Contract.Architecture.Backend.Common.Contract.Persistence;
using Contract.Architecture.Backend.Common.Persistence;
using Finanzuebersicht.Backend.Generated.Contract.Persistence.Modules.Accounting.StartSalden;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Generated.Logic.Tests.Modules.Accounting.StartSalden
{
    internal class DbStartSaldoListItemTest : IDbStartSaldoListItem
    {
        public Guid Id { get; set; }

        public double Betrag { get; set; }

        public DateTime DatumAm { get; set; }

        public static IDbStartSaldoListItem Default()
        {
            return new DbStartSaldoListItemTest()
            {
                Id = StartSaldoTestValues.IdDefault,
                Betrag = StartSaldoTestValues.BetragDefault,
                DatumAm = StartSaldoTestValues.DatumAmDefault,
            };
        }

        public static IDbStartSaldoListItem Default2()
        {
            return new DbStartSaldoListItemTest()
            {
                Id = StartSaldoTestValues.IdDefault2,
                Betrag = StartSaldoTestValues.BetragDefault2,
                DatumAm = StartSaldoTestValues.DatumAmDefault2,
            };
        }

        public static IDbPagedResult<IDbStartSaldoListItem> ForPaged()
        {
            return new DbPagedResult<IDbStartSaldoListItem>()
            {
                Data = new List<IDbStartSaldoListItem>()
                {
                    Default(),
                    Default2()
                },
                TotalCount = 2,
                Count = 2,
                Limit = 10,
                Offset = 0
            };
        }
    }
}