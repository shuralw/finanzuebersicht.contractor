using Contract.Architecture.Backend.Common.Contract.Logic;
using Contract.Architecture.Backend.Common.Contract.Persistence;
using Contract.Architecture.Backend.Common.Logic;
using Finanzuebersicht.Backend.Generated.Contract.Logic.Modules.Accounting.StartSalden;
using Finanzuebersicht.Backend.Generated.Contract.Persistence.Modules.Accounting.StartSalden;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;

namespace Finanzuebersicht.Backend.Generated.Logic.Modules.Accounting.StartSalden
{
    internal class StartSaldenCrudLogic : IStartSaldenCrudLogic
    {
        private readonly IStartSaldenCrudRepository startSaldenCrudRepository;

        private readonly IGuidGenerator guidGenerator;
        private readonly ILogger<StartSaldenCrudLogic> logger;

        public StartSaldenCrudLogic(
            IStartSaldenCrudRepository startSaldenCrudRepository,
            IGuidGenerator guidGenerator,
            ILogger<StartSaldenCrudLogic> logger)
        {
            this.startSaldenCrudRepository = startSaldenCrudRepository;

            this.guidGenerator = guidGenerator;
            this.logger = logger;
        }

        public ILogicResult<Guid> CreateStartSaldo(IStartSaldoCreate startSaldoCreate)
        {
            Guid newStartSaldoId = this.guidGenerator.NewGuid();
            IDbStartSaldo dbStartSaldoToCreate = StartSaldo.CreateDbStartSaldo(newStartSaldoId, startSaldoCreate);
            this.startSaldenCrudRepository.CreateStartSaldo(dbStartSaldoToCreate);

            this.logger.LogInformation($"StartSaldo ({newStartSaldoId}) angelegt");
            return LogicResult<Guid>.Ok(newStartSaldoId);
        }

        public ILogicResult DeleteStartSaldo(Guid startSaldoId)
        {
            if (!this.startSaldenCrudRepository.DoesStartSaldoExist(startSaldoId))
            {
                this.logger.LogDebug($"StartSaldo ({startSaldoId}) konnte nicht gefunden werden.");
                return LogicResult.NotFound($"StartSaldo ({startSaldoId}) konnte nicht gefunden werden.");
            }

            // TODO: If relations are implemented, resolve conflict with the FOREIGN KEY constraint
            try
            {
                this.startSaldenCrudRepository.DeleteStartSaldo(startSaldoId);
            }
            catch (DbUpdateException)
            {
                this.logger.LogDebug($"StartSaldo ({startSaldoId}) konnte nicht gelöscht werden.");
                return LogicResult.Conflict($"StartSaldo ({startSaldoId}) konnte nicht gelöscht werden.");
            }

            this.logger.LogInformation($"StartSaldo ({startSaldoId}) gelöscht");
            return LogicResult.Ok();
        }

        public ILogicResult<IStartSaldoDetail> GetStartSaldoDetail(Guid startSaldoId)
        {
            IDbStartSaldoDetail dbStartSaldoDetail = this.startSaldenCrudRepository.GetStartSaldoDetail(startSaldoId);
            if (dbStartSaldoDetail == null)
            {
                this.logger.LogDebug($"StartSaldo ({startSaldoId}) konnte nicht gefunden werden.");
                return LogicResult<IStartSaldoDetail>.NotFound($"StartSaldo ({startSaldoId}) konnte nicht gefunden werden.");
            }

            this.logger.LogDebug($"Details für StartSaldo ({startSaldoId}) wurde geladen");
            return LogicResult<IStartSaldoDetail>.Ok(StartSaldoDetail.FromDbStartSaldoDetail(dbStartSaldoDetail));
        }

        public ILogicResult<IPagedResult<IStartSaldoListItem>> GetPagedStartSalden()
        {
            IDbPagedResult<IDbStartSaldoListItem> dbStartSaldenPagedResult =
                this.startSaldenCrudRepository.GetPagedStartSalden();

            IPagedResult<IStartSaldoListItem> startSaldenPagedResult =
                PagedResult.FromDbPagedResult(
                    dbStartSaldenPagedResult,
                    (dbStartSaldo) => StartSaldoListItem.FromDbStartSaldoListItem(dbStartSaldo));

            this.logger.LogDebug("StartSalden wurden geladen");
            return LogicResult<IPagedResult<IStartSaldoListItem>>.Ok(startSaldenPagedResult);
        }

        public ILogicResult UpdateStartSaldo(IStartSaldoUpdate startSaldoUpdate)
        {
            IDbStartSaldo dbStartSaldoToUpdate = this.startSaldenCrudRepository.GetStartSaldo(startSaldoUpdate.Id);
            if (dbStartSaldoToUpdate == null)
            {
                this.logger.LogDebug($"StartSaldo ({startSaldoUpdate.Id}) konnte nicht gefunden werden.");
                return LogicResult.NotFound($"StartSaldo ({startSaldoUpdate.Id}) konnte nicht gefunden werden.");
            }

            this.startSaldenCrudRepository.UpdateStartSaldo(DbStartSaldoUpdate
                .FromStartSaldoUpdate(startSaldoUpdate));

            this.logger.LogInformation($"StartSaldo ({startSaldoUpdate.Id}) aktualisiert");
            return LogicResult.Ok();
        }
    }
}