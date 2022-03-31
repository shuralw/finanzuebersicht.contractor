using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.Accounting.AccountingEntries;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.Accounting.Categories;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.Accounting.CategorySearchTerms;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.Accounting.AccountingEntries;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.Accounting.Categories;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.Accounting.CategorySearchTerms;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.Accounting.Categories
{
    internal class DbCategoryDetail : IDbCategoryDetail
    {
        public Guid Id { get; set; }

        public IEnumerable<IDbAccountingEntry> AccountingEntries { get; set; }

        public IEnumerable<IDbCategory> ChildCategories { get; set; }

        public IDbCategory SuperCategory { get; set; }

        public IEnumerable<IDbCategorySearchTerm> CategorySearchTerms { get; set; }

        public string Title { get; set; }

        public string Color { get; set; }

        internal static IDbCategoryDetail FromEfCategory(EfCategory efCategory)
        {
            if (efCategory == null)
            {
                return null;
            }

            return new DbCategoryDetail()
            {
                Id = efCategory.Id,
                AccountingEntries = efCategory.AccountingEntries.Select(efAccountingEntry => DbAccountingEntry.FromEfAccountingEntry(efAccountingEntry)),
                ChildCategories = efCategory.ChildCategories.Select(efCategory => DbCategory.FromEfCategory(efCategory)),
                SuperCategory = DbCategory.FromEfCategory(efCategory.SuperCategory),
                CategorySearchTerms = efCategory.CategorySearchTerms.Select(efCategorySearchTerm => DbCategorySearchTerm.FromEfCategorySearchTerm(efCategorySearchTerm)),
                Title = efCategory.Title,
                Color = efCategory.Color,
            };
        }
    }
}