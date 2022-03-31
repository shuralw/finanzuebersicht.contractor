using Finanzuebersicht.Backend.Generated.Contract.Persistence.Modules.Accounting.Categories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Finanzuebersicht.Backend.Generated.Persistence.Tests.Modules.Accounting.Categories
{
    internal class DbCategoryTest : IDbCategory
    {
        public Guid Id { get; set; }

        public Guid SuperCategoryId { get; set; }

        public string Title { get; set; }

        public string Color { get; set; }

        public static IDbCategory DbDefault()
        {
            return new DbCategoryTest()
            {
                Id = CategoryTestValues.IdDbDefault,
                SuperCategoryId = CategoryTestValues.SuperCategoryIdDbDefault,
                Title = CategoryTestValues.TitleDbDefault,
                Color = CategoryTestValues.ColorDbDefault,
            };
        }

        public static IDbCategory DbDefault2()
        {
            return new DbCategoryTest()
            {
                Id = CategoryTestValues.IdDbDefault2,
                SuperCategoryId = CategoryTestValues.SuperCategoryIdDbDefault2,
                Title = CategoryTestValues.TitleDbDefault2,
                Color = CategoryTestValues.ColorDbDefault2,
            };
        }

        public static IDbCategory ForCreate()
        {
            return new DbCategoryTest()
            {
                Id = CategoryTestValues.IdForCreate,
                SuperCategoryId = CategoryTestValues.SuperCategoryIdForCreate,
                Title = CategoryTestValues.TitleForCreate,
                Color = CategoryTestValues.ColorForCreate,
            };
        }

        public static void AssertDbDefault(IDbCategory dbCategory)
        {
            Assert.AreEqual(CategoryTestValues.IdDbDefault, dbCategory.Id);
            Assert.AreEqual(CategoryTestValues.SuperCategoryIdDbDefault, dbCategory.SuperCategoryId);
            Assert.AreEqual(CategoryTestValues.TitleDbDefault, dbCategory.Title);
            Assert.AreEqual(CategoryTestValues.ColorDbDefault, dbCategory.Color);
        }

        public static void AssertDbDefault2(IDbCategory dbCategory)
        {
            Assert.AreEqual(CategoryTestValues.IdDbDefault2, dbCategory.Id);
            Assert.AreEqual(CategoryTestValues.SuperCategoryIdDbDefault2, dbCategory.SuperCategoryId);
            Assert.AreEqual(CategoryTestValues.TitleDbDefault2, dbCategory.Title);
            Assert.AreEqual(CategoryTestValues.ColorDbDefault2, dbCategory.Color);
        }

        public static void AssertForCreate(IDbCategory dbCategory)
        {
            Assert.AreEqual(CategoryTestValues.IdForCreate, dbCategory.Id);
            Assert.AreEqual(CategoryTestValues.SuperCategoryIdForCreate, dbCategory.SuperCategoryId);
            Assert.AreEqual(CategoryTestValues.TitleForCreate, dbCategory.Title);
            Assert.AreEqual(CategoryTestValues.ColorForCreate, dbCategory.Color);
        }

        public static void AssertForUpdate(IDbCategory dbCategory)
        {
            Assert.AreEqual(CategoryTestValues.IdDbDefault, dbCategory.Id);
            Assert.AreEqual(CategoryTestValues.SuperCategoryIdForUpdate, dbCategory.SuperCategoryId);
            Assert.AreEqual(CategoryTestValues.TitleForUpdate, dbCategory.Title);
            Assert.AreEqual(CategoryTestValues.ColorForUpdate, dbCategory.Color);
        }
    }
}