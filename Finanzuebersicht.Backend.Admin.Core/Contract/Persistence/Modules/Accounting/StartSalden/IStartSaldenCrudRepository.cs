using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Tools.Pagination;
using System;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.Accounting.StartSalden
{
    public interface IStartSaldenCrudRepository
    {
        void CreateStartSaldo(IDbStartSaldo dbStartSaldo);

        void DeleteStartSaldo(Guid startSaldoId);

        bool DoesStartSaldoExist(Guid startSaldoId);

        IDbStartSaldo GetStartSaldo();

        IDbStartSaldoDetail GetStartSaldoDetail(Guid startSaldoId);

        IDbPagedResult<IDbStartSaldoListItem> GetPagedStartSalden();

        IEnumerable<IDbStartSaldo> GetAllStartSalden();

        void UpdateStartSaldo(IDbStartSaldoUpdate dbStartSaldoUpdate);

        DateTime GetFromDate();
        DateTime GetToDate();
    }
}