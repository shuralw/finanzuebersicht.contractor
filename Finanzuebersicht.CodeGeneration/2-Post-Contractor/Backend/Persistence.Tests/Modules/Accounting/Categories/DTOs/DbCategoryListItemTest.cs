using Finanzuebersicht.Backend.Generated.Contract.Persistence.Modules.Accounting.Categories;
using Finanzuebersicht.Backend.Generated.Persistence.Tests.Modules.Accounting.Categories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Finanzuebersicht.Backend.Generated.Persistence.Tests.Modules.Accounting.Categories
{
    internal class DbCategoryListItemTest : IDbCategoryListItem
    {
        public Guid Id { get; set; }

        public IDbCategory SuperCategory { get; set; }

        public string Title { get; set; }

        public string Color { get; set; }

        public static void AssertDbDefault(IDbCategoryListItem dbCategoryListItem)
        {
            Assert.AreEqual(CategoryTestValues.IdDbDefault, dbCategoryListItem.Id);
            DbCategoryTest.AssertDbDefault(dbCategoryListItem.SuperCategory);
            Assert.AreEqual(CategoryTestValues.TitleDbDefault, dbCategoryListItem.Title);
            Assert.AreEqual(CategoryTestValues.ColorDbDefault, dbCategoryListItem.Color);
        }

        public static void AssertDbDefault2(IDbCategoryListItem dbCategoryListItem)
        {
            Assert.AreEqual(CategoryTestValues.IdDbDefault2, dbCategoryListItem.Id);
            DbCategoryTest.AssertDbDefault2(dbCategoryListItem.SuperCategory);
            Assert.AreEqual(CategoryTestValues.TitleDbDefault2, dbCategoryListItem.Title);
            Assert.AreEqual(CategoryTestValues.ColorDbDefault2, dbCategoryListItem.Color);
        }
    }
}