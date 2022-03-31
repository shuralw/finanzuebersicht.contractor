using Finanzuebersicht.Backend.Generated.Contract.Logic.Modules.Accounting.AccountingEntries;
using Finanzuebersicht.Backend.Generated.Contract.Logic.Modules.Accounting.Categories;
using Finanzuebersicht.Backend.Generated.Contract.Logic.Modules.Accounting.CategorySearchTerms;
using Finanzuebersicht.Backend.Generated.Contract.Persistence.Modules.Accounting.Categories;
using Finanzuebersicht.Backend.Generated.Logic.Modules.Accounting.AccountingEntries;
using Finanzuebersicht.Backend.Generated.Logic.Modules.Accounting.Categories;
using Finanzuebersicht.Backend.Generated.Logic.Modules.Accounting.CategorySearchTerms;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Finanzuebersicht.Backend.Generated.Logic.Modules.Accounting.Categories
{
    internal class CategoryDetail : ICategoryDetail
    {
        public Guid Id { get; set; }

        public IEnumerable<IAccountingEntry> AccountingEntries { get; set; }

        public IEnumerable<ICategory> ChildCategories { get; set; }

        public ICategory SuperCategory { get; set; }

        public IEnumerable<ICategorySearchTerm> CategorySearchTerms { get; set; }

        public string Title { get; set; }

        public string Color { get; set; }

        internal static ICategoryDetail FromDbCategoryDetail(IDbCategoryDetail dbCategoryDetail)
        {
            if (dbCategoryDetail == null)
            {
                return null;
            }

            return new CategoryDetail()
            {
                Id = dbCategoryDetail.Id,
                AccountingEntries = dbCategoryDetail.AccountingEntries.Select(dbAccountingEntry => AccountingEntry.FromDbAccountingEntry(dbAccountingEntry)),
                ChildCategories = dbCategoryDetail.ChildCategories.Select(dbCategory => Category.FromDbCategory(dbCategory)),
                SuperCategory = Accounting.Categories.Category.FromDbCategory(dbCategoryDetail.SuperCategory),
                CategorySearchTerms = dbCategoryDetail.CategorySearchTerms.Select(dbCategorySearchTerm => CategorySearchTerm.FromDbCategorySearchTerm(dbCategorySearchTerm)),
                Title = dbCategoryDetail.Title,
                Color = dbCategoryDetail.Color,
            };
        }
    }
}