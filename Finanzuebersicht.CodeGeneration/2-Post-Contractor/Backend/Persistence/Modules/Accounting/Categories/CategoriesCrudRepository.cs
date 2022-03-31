using Contract.Architecture.Backend.Common.Contract;
using Contract.Architecture.Backend.Common.Contract.Persistence;
using Contract.Architecture.Backend.Common.Persistence;
using Finanzuebersicht.Backend.Generated.Contract.Contexts;
using Finanzuebersicht.Backend.Generated.Contract.Persistence.Modules.Accounting.Categories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Finanzuebersicht.Backend.Generated.Persistence.Modules.Accounting.Categories
{
    internal class CategoriesCrudRepository : ICategoriesCrudRepository
    {
        private readonly ISessionContext sessionContext;
        private readonly IPaginationContext paginationContext;

        private readonly PersistenceDbContext dbContext;

        public CategoriesCrudRepository(
            ISessionContext sessionContext,
            IPaginationContext paginationContext,
            PersistenceDbContext dbContext)
        {
            this.sessionContext = sessionContext;
            this.paginationContext = paginationContext;

            this.dbContext = dbContext;
        }

        public void CreateCategory(IDbCategory dbCategory)
        {
            this.dbContext.Categories.Add(DbCategory.ToEfCategory(dbCategory, this.sessionContext.EmailUserId));
            this.dbContext.SaveChanges();
        }

        public void DeleteCategory(Guid categoryId)
        {
            EfCategory efCategory = this.dbContext.Categories
                .Where(efCategory => efCategory.Id == categoryId)
                .Where(efCategory => efCategory.EmailUserId == this.sessionContext.EmailUserId)
                .Single();

            this.dbContext.Categories.Remove(efCategory);
            this.dbContext.SaveChanges();
        }

        public bool DoesCategoryExist(Guid categoryId)
        {
            return this.dbContext.Categories
                .Any(efCategory => efCategory.EmailUserId == this.sessionContext.EmailUserId && efCategory.Id == categoryId);
        }

        public IDbCategory GetCategory(Guid categoryId)
        {
            EfCategory efCategory = this.dbContext.Categories
                .Where(efCategory => efCategory.Id == categoryId)
                .Where(efCategory => efCategory.EmailUserId == this.sessionContext.EmailUserId)
                .SingleOrDefault();

            return DbCategory.FromEfCategory(efCategory);
        }

        public IDbCategoryDetail GetCategoryDetail(Guid categoryId)
        {
            EfCategory efCategory = this.dbContext.Categories
                .Include(efCategory => efCategory.AccountingEntries)
                .Include(efCategory => efCategory.ChildCategories)
                .Include(efCategory => efCategory.SuperCategory)
                .Include(efCategory => efCategory.CategorySearchTerms)
                .Where(efCategory => efCategory.Id == categoryId)
                .Where(efCategory => efCategory.EmailUserId == this.sessionContext.EmailUserId)
                .SingleOrDefault();

            return DbCategoryDetail.FromEfCategory(efCategory);
        }

        public IDbPagedResult<IDbCategoryListItem> GetPagedCategories()
        {
            var efCategories = this.dbContext.Categories
                .Include(efCategory => efCategory.SuperCategory)
                .Where(efCategory => efCategory.EmailUserId == this.sessionContext.EmailUserId);

            return Pagination.Filter(
                efCategories,
                this.paginationContext,
                efCategory => DbCategoryListItem.FromEfCategory(efCategory));
        }

        public IEnumerable<IDbCategory> GetAllCategories()
        {
            return this.dbContext.Categories
                .Where(efCategory => efCategory.EmailUserId == this.sessionContext.EmailUserId)
                .Select(efCategory => DbCategory.FromEfCategory(efCategory));
        }

        public void UpdateCategory(IDbCategoryUpdate dbCategoryUpdate)
        {
            EfCategory efCategory = this.dbContext.Categories
                .Where(efCategory => efCategory.Id == dbCategoryUpdate.Id)
                .Where(efCategory => efCategory.EmailUserId == this.sessionContext.EmailUserId)
                .SingleOrDefault();

            DbCategory.UpdateEfCategory(efCategory, dbCategoryUpdate);

            this.dbContext.SaveChanges();
        }
    }
}