using Finanzuebersicht.Backend.Admin.Core.Contract.Contexts;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.Accounting.Categories;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Tools.Pagination;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tools.Pagination;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.Accounting.Categories
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
            this.dbContext.Categories.Add(DbCategory.ToEfCategory(dbCategory, this.sessionContext.AdminEmailUserId.Value));
            this.dbContext.SaveChanges();
        }

        public void DeleteCategory(Guid categoryId)
        {
            EfCategory efCategory = this.dbContext.Categories
                .Where(efCategory => efCategory.Id == categoryId)
                .Where(efCategory => efCategory.EmailUserId == this.sessionContext.AdminEmailUserId)
                .Single();

            this.dbContext.Categories.Remove(efCategory);
            this.dbContext.SaveChanges();
        }

        public bool DoesCategoryExist(Guid categoryId)
        {
            return this.dbContext.Categories
                .Any(efCategory => efCategory.EmailUserId == this.sessionContext.AdminEmailUserId && efCategory.Id == categoryId);
        }

        public IDbCategory GetCategory(Guid categoryId)
        {
            EfCategory efCategory = this.dbContext.Categories
                .Where(efCategory => efCategory.Id == categoryId)
                .Where(efCategory => efCategory.EmailUserId == this.sessionContext.AdminEmailUserId)
                .SingleOrDefault();

            return DbCategory.FromEfCategory(efCategory);
        }

        public IDbCategoryDetail GetCategoryDetail(Guid categoryId)
        {
            EfCategory efCategory = this.dbContext.Categories
                .Include(efCategory => efCategory.AccountingEntries)
                .Include(efCategory => efCategory.ChildCategories)
                .Include(efCategory => efCategory.Parent)
                .Include(efCategory => efCategory.CategorySearchTerms)
                .Where(efCategory => efCategory.Id == categoryId)
                .Where(efCategory => efCategory.EmailUserId == this.sessionContext.AdminEmailUserId)
                .SingleOrDefault();

            return DbCategoryDetail.FromEfCategory(efCategory);
        }

        public IEnumerable<Guid> GetCategoryDescendants(Guid? supercategoryId)
        {
            var supercategoryHierarchyId = this.dbContext.Categories
                .Single(cat => cat.Id == supercategoryId)
                .HierarchyId;

            return this.dbContext.Categories
                .Where(cat => cat.HierarchyId.IsDescendantOf(supercategoryHierarchyId))
                .Select(cat => cat.Id);
        }

        public IDbPagedResult<IDbCategoryListItem> GetPagedCategories()
        {
            var efCategories = this.dbContext.Categories
                .Include(efCategory => efCategory.Parent)
                .Include(efCategory => efCategory.AccountingEntries)
                .Where(efCategory => efCategory.EmailUserId == this.sessionContext.AdminEmailUserId);

            return Pagination.Filter(
                efCategories,
                this.paginationContext,
                efCategory => DbCategoryListItem.FromEfCategory(efCategory));
        }

        public IEnumerable<IDbCategory> GetAllCategories()
        {
            return this.dbContext.Categories
                .Where(efCategory => efCategory.EmailUserId == this.sessionContext.AdminEmailUserId)
                .Select(efCategory => DbCategory.FromEfCategory(efCategory));
        }

        public void UpdateCategory(IDbCategoryUpdate dbCategoryUpdate)
        {
            EfCategory efCategory = this.dbContext.Categories
                .Where(efCategory => efCategory.Id == dbCategoryUpdate.Id)
                .Where(efCategory => efCategory.EmailUserId == this.sessionContext.AdminEmailUserId)
                .SingleOrDefault();

            //var parentHierarchyId = efCategory.HierarchyId.GetAncestor(1);

            //var parentHierarchyId = this.dbContext.Categories
            //    .SingleOrDefault(cat => cat == efCategory.HierarchyId.GetAncestor())?
            //    .HierarchyId;

            //dbCategoryUpdate.ParentHierarchyId = this.dbContext.Categories
            //    .Single(cat => cat.Id == dbCategoryUpdate.SuperCategoryId);

            DbCategory.UpdateEfCategory(efCategory, dbCategoryUpdate);

            this.dbContext.SaveChanges();
        }
    }
}