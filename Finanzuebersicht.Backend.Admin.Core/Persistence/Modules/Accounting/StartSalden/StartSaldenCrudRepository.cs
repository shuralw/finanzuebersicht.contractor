using Finanzuebersicht.Backend.Admin.Core.Contract.Contexts;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.Accounting.StartSalden;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Tools.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.Accounting.StartSalden
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
            this.dbContext.StartSalden.Add(DbStartSaldo.ToEfStartSaldo(dbStartSaldo, this.sessionContext.AdminEmailUserId.Value));
            this.dbContext.SaveChanges();
        }

        public void DeleteStartSaldo(Guid startSaldoId)
        {
            EfStartSaldo efStartSaldo = this.dbContext.StartSalden
                .Where(efStartSaldo => efStartSaldo.Id == startSaldoId)
                .Where(efStartSaldo => efStartSaldo.EmailUserId == this.sessionContext.AdminEmailUserId)
                .Single();

            this.dbContext.StartSalden.Remove(efStartSaldo);
            this.dbContext.SaveChanges();
        }

        public bool DoesStartSaldoExist(Guid startSaldoId)
        {
            return this.dbContext.StartSalden
                .Any(efStartSaldo => efStartSaldo.EmailUserId == this.sessionContext.AdminEmailUserId && efStartSaldo.Id == startSaldoId);
        }

        public IDbStartSaldo GetStartSaldo()
        {
            EfStartSaldo efStartSaldo = this.dbContext.StartSalden
                .Where(efStartSaldo => efStartSaldo.EmailUserId == this.sessionContext.AdminEmailUserId)
                .SingleOrDefault();

            return DbStartSaldo.FromEfStartSaldo(efStartSaldo);
        }

        public IDbStartSaldoDetail GetStartSaldoDetail(Guid startSaldoId)
        {
            EfStartSaldo efStartSaldo = this.dbContext.StartSalden
                .Where(efStartSaldo => efStartSaldo.Id == startSaldoId)
                .Where(efStartSaldo => efStartSaldo.EmailUserId == this.sessionContext.AdminEmailUserId)
                .SingleOrDefault();

            return DbStartSaldoDetail.FromEfStartSaldo(efStartSaldo);
        }

        public IDbPagedResult<IDbStartSaldoListItem> GetPagedStartSalden()
        {
            var efStartSalden = this.dbContext.StartSalden
                .Where(efStartSaldo => efStartSaldo.EmailUserId == this.sessionContext.AdminEmailUserId);

            return Pagination.Filter(
                efStartSalden,
                this.paginationContext,
                efStartSaldo => DbStartSaldoListItem.FromEfStartSaldo(efStartSaldo));
        }

        public IEnumerable<IDbStartSaldo> GetAllStartSalden()
        {
            return this.dbContext.StartSalden
                .Where(efStartSaldo => efStartSaldo.EmailUserId == this.sessionContext.AdminEmailUserId)
                .Select(efStartSaldo => DbStartSaldo.FromEfStartSaldo(efStartSaldo));
        }

        public void UpdateStartSaldo(IDbStartSaldoUpdate dbStartSaldoUpdate)
        {
            EfStartSaldo efStartSaldo = this.dbContext.StartSalden
                .Where(efStartSaldo => efStartSaldo.Id == dbStartSaldoUpdate.Id)
                .Where(efStartSaldo => efStartSaldo.EmailUserId == this.sessionContext.AdminEmailUserId)
                .SingleOrDefault();

            DbStartSaldo.UpdateEfStartSaldo(efStartSaldo, dbStartSaldoUpdate);

            this.dbContext.SaveChanges();
        }

        public DateTime GetFromDate()
        {
            return new DateTime(2022, 03, 01);
            return Convert.ToDateTime(this.paginationContext.Filter["fromDate"]);
        }

        public DateTime GetToDate()
        {
            return new DateTime(2022, 03, 22);
            return Convert.ToDateTime(this.paginationContext.Filter["toDate"]);
        }
    }
}