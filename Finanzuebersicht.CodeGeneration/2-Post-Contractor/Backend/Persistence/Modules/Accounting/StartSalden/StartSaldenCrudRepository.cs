using Contract.Architecture.Backend.Common.Contract;
using Contract.Architecture.Backend.Common.Contract.Persistence;
using Contract.Architecture.Backend.Common.Persistence;
using Finanzuebersicht.Backend.Generated.Contract.Contexts;
using Finanzuebersicht.Backend.Generated.Contract.Persistence.Modules.Accounting.StartSalden;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Finanzuebersicht.Backend.Generated.Persistence.Modules.Accounting.StartSalden
{
    internal class StartSaldenCrudRepository : IStartSaldenCrudRepository
    {
        private readonly ISessionContext sessionContext;
        private readonly IPaginationContext paginationContext;

        private readonly PersistenceDbContext dbContext;

        public StartSaldenCrudRepository(
            ISessionContext sessionContext,
            IPaginationContext paginationContext,
            PersistenceDbContext dbContext)
        {
            this.sessionContext = sessionContext;
            this.paginationContext = paginationContext;

            this.dbContext = dbContext;
        }

        public void CreateStartSaldo(IDbStartSaldo dbStartSaldo)
        {
            this.dbContext.StartSalden.Add(DbStartSaldo.ToEfStartSaldo(dbStartSaldo, this.sessionContext.EmailUserId));
            this.dbContext.SaveChanges();
        }

        public void DeleteStartSaldo(Guid startSaldoId)
        {
            EfStartSaldo efStartSaldo = this.dbContext.StartSalden
                .Where(efStartSaldo => efStartSaldo.Id == startSaldoId)
                .Where(efStartSaldo => efStartSaldo.EmailUserId == this.sessionContext.EmailUserId)
                .Single();

            this.dbContext.StartSalden.Remove(efStartSaldo);
            this.dbContext.SaveChanges();
        }

        public bool DoesStartSaldoExist(Guid startSaldoId)
        {
            return this.dbContext.StartSalden
                .Any(efStartSaldo => efStartSaldo.EmailUserId == this.sessionContext.EmailUserId && efStartSaldo.Id == startSaldoId);
        }

        public IDbStartSaldo GetStartSaldo(Guid startSaldoId)
        {
            EfStartSaldo efStartSaldo = this.dbContext.StartSalden
                .Where(efStartSaldo => efStartSaldo.Id == startSaldoId)
                .Where(efStartSaldo => efStartSaldo.EmailUserId == this.sessionContext.EmailUserId)
                .SingleOrDefault();

            return DbStartSaldo.FromEfStartSaldo(efStartSaldo);
        }

        public IDbStartSaldoDetail GetStartSaldoDetail(Guid startSaldoId)
        {
            EfStartSaldo efStartSaldo = this.dbContext.StartSalden
                .Where(efStartSaldo => efStartSaldo.Id == startSaldoId)
                .Where(efStartSaldo => efStartSaldo.EmailUserId == this.sessionContext.EmailUserId)
                .SingleOrDefault();

            return DbStartSaldoDetail.FromEfStartSaldo(efStartSaldo);
        }

        public IDbPagedResult<IDbStartSaldoListItem> GetPagedStartSalden()
        {
            var efStartSalden = this.dbContext.StartSalden
                .Where(efStartSaldo => efStartSaldo.EmailUserId == this.sessionContext.EmailUserId);

            return Pagination.Filter(
                efStartSalden,
                this.paginationContext,
                efStartSaldo => DbStartSaldoListItem.FromEfStartSaldo(efStartSaldo));
        }

        public IEnumerable<IDbStartSaldo> GetAllStartSalden()
        {
            return this.dbContext.StartSalden
                .Where(efStartSaldo => efStartSaldo.EmailUserId == this.sessionContext.EmailUserId)
                .Select(efStartSaldo => DbStartSaldo.FromEfStartSaldo(efStartSaldo));
        }

        public void UpdateStartSaldo(IDbStartSaldoUpdate dbStartSaldoUpdate)
        {
            EfStartSaldo efStartSaldo = this.dbContext.StartSalden
                .Where(efStartSaldo => efStartSaldo.Id == dbStartSaldoUpdate.Id)
                .Where(efStartSaldo => efStartSaldo.EmailUserId == this.sessionContext.EmailUserId)
                .SingleOrDefault();

            DbStartSaldo.UpdateEfStartSaldo(efStartSaldo, dbStartSaldoUpdate);

            this.dbContext.SaveChanges();
        }
    }
}