using Contract.Architecture.Backend.Common.Contract.Persistence;
using System;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Generated.Contract.Persistence.Modules.Accounting.StartSalden
{
    public interface IStartSaldenCrudRepository
    {
        void CreateStartSaldo(IDbStartSaldo dbStartSaldo);

        void DeleteStartSaldo(Guid startSaldoId);

        bool DoesStartSaldoExist(Guid startSaldoId);

        IDbStartSaldo GetStartSaldo(Guid startSaldoId);

        IDbStartSaldoDetail GetStartSaldoDetail(Guid startSaldoId);

        IDbPagedResult<IDbStartSaldoListItem> GetPagedStartSalden();

        IEnumerable<IDbStartSaldo> GetAllStartSalden();

        void UpdateStartSaldo(IDbStartSaldoUpdate dbStartSaldoUpdate);
    }
}