using Contract.Architecture.Backend.Common.Contract;
using Contract.Architecture.Backend.Common.Contract.Persistence;
using Contract.Architecture.Backend.Common.Persistence;
using Finanzuebersicht.Backend.Generated.Contract.Contexts;
using Finanzuebersicht.Backend.Generated.Contract.Persistence.Modules.Accounting.CategorySearchTerms;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Finanzuebersicht.Backend.Generated.Persistence.Modules.Accounting.CategorySearchTerms
{
    internal class CategorySearchTermsCrudRepository : ICategorySearchTermsCrudRepository
    {
        private readonly ISessionContext sessionContext;
        private readonly IPaginationContext paginationContext;

        private readonly PersistenceDbContext dbContext;

        public CategorySearchTermsCrudRepository(
            ISessionContext sessionContext,
            IPaginationContext paginationContext,
            PersistenceDbContext dbContext)
        {
            this.sessionContext = sessionContext;
            this.paginationContext = paginationContext;

            this.dbContext = dbContext;
        }

        public void CreateCategorySearchTerm(IDbCategorySearchTerm dbCategorySearchTerm)
        {
            this.dbContext.CategorySearchTerms.Add(DbCategorySearchTerm.ToEfCategorySearchTerm(dbCategorySearchTerm, this.sessionContext.EmailUserId));
            this.dbContext.SaveChanges();
        }

        public void DeleteCategorySearchTerm(Guid categorySearchTermId)
        {
            EfCategorySearchTerm efCategorySearchTerm = this.dbContext.CategorySearchTerms
                .Where(efCategorySearchTerm => efCategorySearchTerm.Id == categorySearchTermId)
                .Where(efCategorySearchTerm => efCategorySearchTerm.EmailUserId == this.sessionContext.EmailUserId)
                .Single();

            this.dbContext.CategorySearchTerms.Remove(efCategorySearchTerm);
            this.dbContext.SaveChanges();
        }

        public bool DoesCategorySearchTermExist(Guid categorySearchTermId)
        {
            return this.dbContext.CategorySearchTerms
                .Any(efCategorySearchTerm => efCategorySearchTerm.EmailUserId == this.sessionContext.EmailUserId && efCategorySearchTerm.Id == categorySearchTermId);
        }

        public IDbCategorySearchTerm GetCategorySearchTerm(Guid categorySearchTermId)
        {
            EfCategorySearchTerm efCategorySearchTerm = this.dbContext.CategorySearchTerms
                .Where(efCategorySearchTerm => efCategorySearchTerm.Id == categorySearchTermId)
                .Where(efCategorySearchTerm => efCategorySearchTerm.EmailUserId == this.sessionContext.EmailUserId)
                .SingleOrDefault();

            return DbCategorySearchTerm.FromEfCategorySearchTerm(efCategorySearchTerm);
        }

        public IDbCategorySearchTermDetail GetCategorySearchTermDetail(Guid categorySearchTermId)
        {
            EfCategorySearchTerm efCategorySearchTerm = this.dbContext.CategorySearchTerms
                .Include(efCategorySearchTerm => efCategorySearchTerm.Category)
                .Where(efCategorySearchTerm => efCategorySearchTerm.Id == categorySearchTermId)
                .Where(efCategorySearchTerm => efCategorySearchTerm.EmailUserId == this.sessionContext.EmailUserId)
                .SingleOrDefault();

            return DbCategorySearchTermDetail.FromEfCategorySearchTerm(efCategorySearchTerm);
        }

        public IDbPagedResult<IDbCategorySearchTermListItem> GetPagedCategorySearchTerms()
        {
            var efCategorySearchTerms = this.dbContext.CategorySearchTerms
                .Include(efCategorySearchTerm => efCategorySearchTerm.Category)
                .Where(efCategorySearchTerm => efCategorySearchTerm.EmailUserId == this.sessionContext.EmailUserId);

            return Pagination.Filter(
                efCategorySearchTerms,
                this.paginationContext,
                efCategorySearchTerm => DbCategorySearchTermListItem.FromEfCategorySearchTerm(efCategorySearchTerm));
        }

        public IEnumerable<IDbCategorySearchTerm> GetAllCategorySearchTerms()
        {
            return this.dbContext.CategorySearchTerms
                .Where(efCategorySearchTerm => efCategorySearchTerm.EmailUserId == this.sessionContext.EmailUserId)
                .Select(efCategorySearchTerm => DbCategorySearchTerm.FromEfCategorySearchTerm(efCategorySearchTerm));
        }

        public void UpdateCategorySearchTerm(IDbCategorySearchTermUpdate dbCategorySearchTermUpdate)
        {
            EfCategorySearchTerm efCategorySearchTerm = this.dbContext.CategorySearchTerms
                .Where(efCategorySearchTerm => efCategorySearchTerm.Id == dbCategorySearchTermUpdate.Id)
                .Where(efCategorySearchTerm => efCategorySearchTerm.EmailUserId == this.sessionContext.EmailUserId)
                .SingleOrDefault();

            DbCategorySearchTerm.UpdateEfCategorySearchTerm(efCategorySearchTerm, dbCategorySearchTermUpdate);

            this.dbContext.SaveChanges();
        }
    }
}