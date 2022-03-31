using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.Accounting.Categories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.Accounting.Categories
{
    internal class CategoryTest : ICategory
    {
        public Guid Id { get; set; }

        public Guid? SuperCategoryId { get; set; }

        public string Title { get; set; }

        public string Color { get; set; }

        public static ICategory Default()
        {
            return new CategoryTest()
            {
                Id = CategoryTestValues.IdDefault,
                SuperCategoryId = CategoryTestValues.SuperCategoryIdDefault,
                Title = CategoryTestValues.TitleDefault,
                Color = CategoryTestValues.ColorDefault,
            };
        }

        public static ICategory Default2()
        {
            return new CategoryTest()
            {
                Id = CategoryTestValues.IdDefault2,
                SuperCategoryId = CategoryTestValues.SuperCategoryIdDefault2,
                Title = CategoryTestValues.TitleDefault2,
                Color = CategoryTestValues.ColorDefault2,
            };
        }

        public static void AssertDefault(ICategory category)
        {
            Assert.AreEqual(CategoryTestValues.IdDefault, category.Id);
            Assert.AreEqual(CategoryTestValues.SuperCategoryIdDefault, category.SuperCategoryId);
            Assert.AreEqual(CategoryTestValues.TitleDefault, category.Title);
            Assert.AreEqual(CategoryTestValues.ColorDefault, category.Color);
        }

        public static void AssertDefault2(ICategory category)
        {
            Assert.AreEqual(CategoryTestValues.IdDefault2, category.Id);
            Assert.AreEqual(CategoryTestValues.SuperCategoryIdDefault2, category.SuperCategoryId);
            Assert.AreEqual(CategoryTestValues.TitleDefault2, category.Title);
            Assert.AreEqual(CategoryTestValues.ColorDefault2, category.Color);
        }
    }
}