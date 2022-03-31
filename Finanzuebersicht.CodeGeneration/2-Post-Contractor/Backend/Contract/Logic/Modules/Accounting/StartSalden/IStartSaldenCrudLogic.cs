using Contract.Architecture.Backend.Common.Contract.Logic;
using System;

namespace Finanzuebersicht.Backend.Generated.Contract.Logic.Modules.Accounting.StartSalden
{
    public interface IStartSaldenCrudLogic
    {
        ILogicResult<Guid> CreateStartSaldo(IStartSaldoCreate startSaldoCreate);

        ILogicResult DeleteStartSaldo(Guid startSaldoId);

        ILogicResult<IStartSaldoDetail> GetStartSaldoDetail(Guid startSaldoId);

        ILogicResult<IPagedResult<IStartSaldoListItem>> GetPagedStartSalden();

        ILogicResult UpdateStartSaldo(IStartSaldoUpdate startSaldoUpdate);
    }
}