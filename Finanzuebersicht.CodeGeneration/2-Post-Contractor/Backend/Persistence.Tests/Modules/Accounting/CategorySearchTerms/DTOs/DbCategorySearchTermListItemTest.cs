using Finanzuebersicht.Backend.Generated.Contract.Persistence.Modules.Accounting.Categories;
using Finanzuebersicht.Backend.Generated.Contract.Persistence.Modules.Accounting.CategorySearchTerms;
using Finanzuebersicht.Backend.Generated.Persistence.Tests.Modules.Accounting.Categories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Finanzuebersicht.Backend.Generated.Persistence.Tests.Modules.Accounting.CategorySearchTerms
{
    internal class DbCategorySearchTermListItemTest : IDbCategorySearchTermListItem
    {
        public Guid Id { get; set; }

        public IDbCategory Category { get; set; }

        public string Term { get; set; }

        public static void AssertDbDefault(IDbCategorySearchTermListItem dbCategorySearchTermListItem)
        {
            Assert.AreEqual(CategorySearchTermTestValues.IdDbDefault, dbCategorySearchTermListItem.Id);
            DbCategoryTest.AssertDbDefault(dbCategorySearchTermListItem.Category);
            Assert.AreEqual(CategorySearchTermTestValues.TermDbDefault, dbCategorySearchTermListItem.Term);
        }

        public static void AssertDbDefault2(IDbCategorySearchTermListItem dbCategorySearchTermListItem)
        {
            Assert.AreEqual(CategorySearchTermTestValues.IdDbDefault2, dbCategorySearchTermListItem.Id);
            DbCategoryTest.AssertDbDefault2(dbCategorySearchTermListItem.Category);
            Assert.AreEqual(CategorySearchTermTestValues.TermDbDefault2, dbCategorySearchTermListItem.Term);
        }
    }
}