using Finanzuebersicht.Backend.Generated.Contract.Persistence.Modules.Accounting.AccountingEntries;
using Finanzuebersicht.Backend.Generated.Contract.Persistence.Modules.Accounting.Categories;
using Finanzuebersicht.Backend.Generated.Contract.Persistence.Modules.Accounting.CategorySearchTerms;
using Finanzuebersicht.Backend.Generated.Logic.Tests.Modules.Accounting.AccountingEntries;
using Finanzuebersicht.Backend.Generated.Logic.Tests.Modules.Accounting.Categories;
using Finanzuebersicht.Backend.Generated.Logic.Tests.Modules.Accounting.CategorySearchTerms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Finanzuebersicht.Backend.Generated.Logic.Tests.Modules.Accounting.Categories
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

        public static IDbCategoryDetail Default()
        {
            return new DbCategoryDetailTest()
            {
                Id = CategoryTestValues.IdDefault,
                AccountingEntries = new List<IDbAccountingEntry> { DbAccountingEntryTest.Default() },
                ChildCategories = new List<IDbCategory> { DbCategoryTest.Default() },
                SuperCategory = DbCategoryTest.Default(),
                CategorySearchTerms = new List<IDbCategorySearchTerm> { DbCategorySearchTermTest.Default() },
                Title = CategoryTestValues.TitleDefault,
                Color = CategoryTestValues.ColorDefault,
            };
        }

        public static IDbCategoryDetail Default2()
        {
            return new DbCategoryDetailTest()
            {
                Id = CategoryTestValues.IdDefault,
                AccountingEntries = new List<IDbAccountingEntry> { DbAccountingEntryTest.Default2() },
                ChildCategories = new List<IDbCategory> { DbCategoryTest.Default2() },
                SuperCategory = DbCategoryTest.Default2(),
                CategorySearchTerms = new List<IDbCategorySearchTerm> { DbCategorySearchTermTest.Default2() },
                Title = CategoryTestValues.TitleDefault2,
                Color = CategoryTestValues.ColorDefault2,
            };
        }

        public static void AssertDefault(IDbCategoryDetail dbCategoryDetail)
        {
            Assert.AreEqual(CategoryTestValues.IdDefault, dbCategoryDetail.Id);
            DbAccountingEntryTest.AssertDefault(dbCategoryDetail.AccountingEntries.ToArray()[0]);
            DbCategoryTest.AssertDefault(dbCategoryDetail.ChildCategories.ToArray()[0]);
            DbCategoryTest.AssertDefault(dbCategoryDetail.SuperCategory);
            DbCategorySearchTermTest.AssertDefault(dbCategoryDetail.CategorySearchTerms.ToArray()[0]);
        }

        public static void AssertDefault2(IDbCategoryDetail dbCategoryDetail)
        {
            Assert.AreEqual(CategoryTestValues.IdDefault2, dbCategoryDetail.Id);
            DbAccountingEntryTest.AssertDefault2(dbCategoryDetail.AccountingEntries.ToArray()[0]);
            DbCategoryTest.AssertDefault2(dbCategoryDetail.ChildCategories.ToArray()[0]);
            DbCategoryTest.AssertDefault2(dbCategoryDetail.SuperCategory);
            DbCategorySearchTermTest.AssertDefault2(dbCategoryDetail.CategorySearchTerms.ToArray()[0]);
            Assert.AreEqual(CategoryTestValues.TitleDefault2, dbCategoryDetail.Title);
            Assert.AreEqual(CategoryTestValues.ColorDefault2, dbCategoryDetail.Color);
        }
    }
}