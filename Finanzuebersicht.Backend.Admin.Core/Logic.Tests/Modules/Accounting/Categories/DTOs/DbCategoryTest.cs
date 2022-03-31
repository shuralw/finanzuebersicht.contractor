using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.Accounting.Categories;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Tools.Pagination;
using Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Tools.Pagination;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.Accounting.Categories
{
    internal class DbCategoryTest : IDbCategory
    {
        public Guid Id { get; set; }

        public Guid? SuperCategoryId { get; set; }

        public string Title { get; set; }

        public string Color { get; set; }

        public static IDbCategory Default()
        {
            return new DbCategoryTest()
            {
                Id = CategoryTestValues.IdDefault,
                SuperCategoryId = CategoryTestValues.SuperCategoryIdDefault,
                Title = CategoryTestValues.TitleDefault,
                Color = CategoryTestValues.ColorDefault,
            };
        }

        public static IDbCategory Default2()
        {
            return new DbCategoryTest()
            {
                Id = CategoryTestValues.IdDefault2,
                SuperCategoryId = CategoryTestValues.SuperCategoryIdDefault2,
                Title = CategoryTestValues.TitleDefault2,
                Color = CategoryTestValues.ColorDefault2,
            };
        }

        public static void AssertDefault(IDbCategory dbCategory)
        {
            Assert.AreEqual(CategoryTestValues.IdDefault, dbCategory.Id);
            Assert.AreEqual(CategoryTestValues.SuperCategoryIdDefault, dbCategory.SuperCategoryId);
            Assert.AreEqual(CategoryTestValues.TitleDefault, dbCategory.Title);
            Assert.AreEqual(CategoryTestValues.ColorDefault, dbCategory.Color);
        }

        public static void AssertDefault2(IDbCategory dbCategory)
        {
            Assert.AreEqual(CategoryTestValues.IdDefault2, dbCategory.Id);
            Assert.AreEqual(CategoryTestValues.SuperCategoryIdDefault2, dbCategory.SuperCategoryId);
            Assert.AreEqual(CategoryTestValues.TitleDefault2, dbCategory.Title);
            Assert.AreEqual(CategoryTestValues.ColorDefault2, dbCategory.Color);
        }

        public static void AssertCreated(IDbCategory dbCategory)
        {
            Assert.AreEqual(CategoryTestValues.IdForCreate, dbCategory.Id);
            Assert.AreEqual(CategoryTestValues.SuperCategoryIdForCreate, dbCategory.SuperCategoryId);
            Assert.AreEqual(CategoryTestValues.TitleForCreate, dbCategory.Title);
            Assert.AreEqual(CategoryTestValues.ColorForCreate, dbCategory.Color);
        }
    }
}