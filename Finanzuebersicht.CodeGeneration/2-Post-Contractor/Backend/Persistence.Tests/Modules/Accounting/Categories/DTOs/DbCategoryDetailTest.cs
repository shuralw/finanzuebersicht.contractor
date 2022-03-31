using Finanzuebersicht.Backend.Generated.Contract.Persistence.Modules.Accounting.AccountingEntries;
using Finanzuebersicht.Backend.Generated.Contract.Persistence.Modules.Accounting.Categories;
using Finanzuebersicht.Backend.Generated.Contract.Persistence.Modules.Accounting.CategorySearchTerms;
using Finanzuebersicht.Backend.Generated.Persistence.Tests.Modules.Accounting.AccountingEntries;
using Finanzuebersicht.Backend.Generated.Persistence.Tests.Modules.Accounting.Categories;
using Finanzuebersicht.Backend.Generated.Persistence.Tests.Modules.Accounting.CategorySearchTerms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Finanzuebersicht.Backend.Generated.Persistence.Tests.Modules.Accounting.Categories
{
    internal class DbCategoryDetailTest : IDbCategoryDetail
    {
        public Guid Id { get; set; }

        public IEnumerable<IDbAccountingEntry> AccountingEntries { get; set; }

        public IEnumerable<IDbCategory> ChildCategories { get; set; }

        public IDbCategory SuperCategory { get; set; }

        public IEnumerable<IDbCategorySearchTerm> CategorySearchTerms { get; set; }

        public string Title { get; set; }

        public string Color { get; set; }

        public static void AssertDbDefault(IDbCategoryDetail dbCategoryDetail)
        {
            Assert.AreEqual(CategoryTestValues.IdDbDefault, dbCategoryDetail.Id);
            DbAccountingEntryTest.AssertDbDefault(dbCategoryDetail.AccountingEntries.ToArray()[0]);
            DbCategoryTest.AssertDbDefault(dbCategoryDetail.ChildCategories.ToArray()[0]);
            DbCategoryTest.AssertDbDefault(dbCategoryDetail.SuperCategory);
            DbCategorySearchTermTest.AssertDbDefault(dbCategoryDetail.CategorySearchTerms.ToArray()[0]);
            Assert.AreEqual(CategoryTestValues.TitleDbDefault, dbCategoryDetail.Title);
            Assert.AreEqual(CategoryTestValues.ColorDbDefault, dbCategoryDetail.Color);
        }
    }
}