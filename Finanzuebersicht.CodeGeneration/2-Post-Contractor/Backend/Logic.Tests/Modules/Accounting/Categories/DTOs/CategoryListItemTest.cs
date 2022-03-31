using Finanzuebersicht.Backend.Generated.Contract.Logic.Modules.Accounting.Categories;
using Finanzuebersicht.Backend.Generated.Logic.Tests.Modules.Accounting.Categories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Finanzuebersicht.Backend.Generated.Logic.Tests.Modules.Accounting.Categories
{
    internal class CategoryListItemTest : ICategoryListItem
    {
        public Guid Id { get; set; }

        public ICategory SuperCategory { get; set; }

        public string Title { get; set; }

        public string Color { get; set; }

        public static void AssertDefault(ICategoryListItem categoryListItem)
        {
            Assert.AreEqual(CategoryTestValues.IdDefault, categoryListItem.Id);
            CategoryTest.AssertDefault(categoryListItem.SuperCategory);
            Assert.AreEqual(CategoryTestValues.TitleDefault, categoryListItem.Title);
            Assert.AreEqual(CategoryTestValues.ColorDefault, categoryListItem.Color);
        }

        public static void AssertDefault2(ICategoryListItem categoryListItem)
        {
            Assert.AreEqual(CategoryTestValues.IdDefault2, categoryListItem.Id);
            CategoryTest.AssertDefault2(categoryListItem.SuperCategory);
            Assert.AreEqual(CategoryTestValues.TitleDefault2, categoryListItem.Title);
            Assert.AreEqual(CategoryTestValues.ColorDefault2, categoryListItem.Color);
        }
    }
}