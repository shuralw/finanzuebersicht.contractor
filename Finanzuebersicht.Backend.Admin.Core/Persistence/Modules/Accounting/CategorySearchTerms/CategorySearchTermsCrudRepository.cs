using Finanzuebersicht.Backend.Admin.Core.Contract.Contexts;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.Accounting.CategorySearchTerms;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Tools.Pagination;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tools.Pagination;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.Accounting.CategorySearchTerms
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
            this.dbContext.CategorySearchTerms.Add(DbCategorySearchTerm.ToEfCategorySearchTerm(dbCategorySearchTerm, this.sessionContext.AdminEmailUserId.Value));
            this.dbContext.SaveChanges();
        }

        public void DeleteCategorySearchTerm(Guid categorySearchTermId)
        {
            EfCategorySearchTerm efCategorySearchTerm = this.dbContext.CategorySearchTerms
                .Where(efCategorySearchTerm => efCategorySearchTerm.Id == categorySearchTermId)
                .Where(efCategorySearchTerm => efCategorySearchTerm.EmailUserId == this.sessionContext.AdminEmailUserId)
                .Single();

            this.dbContext.CategorySearchTerms.Remove(efCategorySearchTerm);
            this.dbContext.SaveChanges();
        }

        public bool DoesCategorySearchTermExist(Guid categorySearchTermId)
        {
            return this.dbContext.CategorySearchTerms
                .Any(efCategorySearchTerm => efCategorySearchTerm.EmailUserId == this.sessionContext.AdminEmailUserId && efCategorySearchTerm.Id == categorySearchTermId);
        }

        public IDbCategorySearchTerm GetCategorySearchTerm(Guid categorySearchTermId)
        {
            EfCategorySearchTerm efCategorySearchTerm = this.dbContext.CategorySearchTerms
                .Where(efCategorySearchTerm => efCategorySearchTerm.Id == categorySearchTermId)
                .Where(efCategorySearchTerm => efCategorySearchTerm.EmailUserId == this.sessionContext.AdminEmailUserId)
                .SingleOrDefault();

            return DbCategorySearchTerm.FromEfCategorySearchTerm(efCategorySearchTerm);
        }

        public IDbCategorySearchTermDetail GetCategorySearchTermDetail(Guid categorySearchTermId)
        {
            EfCategorySearchTerm efCategorySearchTerm = this.dbContext.CategorySearchTerms
                .Include(efCategorySearchTerm => efCategorySearchTerm.Category)
                .Where(efCategorySearchTerm => efCategorySearchTerm.Id == categorySearchTermId)
                .Where(efCategorySearchTerm => efCategorySearchTerm.EmailUserId == this.sessionContext.AdminEmailUserId)
                .SingleOrDefault();

            return DbCategorySearchTermDetail.FromEfCategorySearchTerm(efCategorySearchTerm);
        }

        public IDbPagedResult<IDbCategorySearchTermListItem> GetPagedCategorySearchTerms()
        {
            var efCategorySearchTerms = this.dbContext.CategorySearchTerms
                .Include(efCategorySearchTerm => efCategorySearchTerm.Category)
                .Where(efCategorySearchTerm => efCategorySearchTerm.EmailUserId == this.sessionContext.AdminEmailUserId);

            return Pagination.Filter(
                efCategorySearchTerms,
                this.paginationContext,
                efCategorySearchTerm => DbCategorySearchTermListItem.FromEfCategorySearchTerm(efCategorySearchTerm));
        }

        public IEnumerable<IDbCategorySearchTerm> GetAllCategorySearchTerms()
        {
            return this.dbContext.CategorySearchTerms
                .Where(efCategorySearchTerm => efCategorySearchTerm.EmailUserId == this.sessionContext.AdminEmailUserId)
                .Select(efCategorySearchTerm => DbCategorySearchTerm.FromEfCategorySearchTerm(efCategorySearchTerm));
        }

        public void UpdateCategorySearchTerm(IDbCategorySearchTermUpdate dbCategorySearchTermUpdate)
        {
            EfCategorySearchTerm efCategorySearchTerm = this.dbContext.CategorySearchTerms
                .Where(efCategorySearchTerm => efCategorySearchTerm.Id == dbCategorySearchTermUpdate.Id)
                .Where(efCategorySearchTerm => efCategorySearchTerm.EmailUserId == this.sessionContext.AdminEmailUserId)
                .SingleOrDefault();

            DbCategorySearchTerm.UpdateEfCategorySearchTerm(efCategorySearchTerm, dbCategorySearchTermUpdate);

            this.dbContext.SaveChanges();
        }
    }
}