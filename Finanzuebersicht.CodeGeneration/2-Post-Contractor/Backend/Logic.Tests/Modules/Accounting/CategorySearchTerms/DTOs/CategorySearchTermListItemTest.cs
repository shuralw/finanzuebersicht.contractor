using Finanzuebersicht.Backend.Generated.Contract.Logic.Modules.Accounting.Categories;
using Finanzuebersicht.Backend.Generated.Contract.Logic.Modules.Accounting.CategorySearchTerms;
using Finanzuebersicht.Backend.Generated.Logic.Tests.Modules.Accounting.Categories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Finanzuebersicht.Backend.Generated.Logic.Tests.Modules.Accounting.CategorySearchTerms
{
    internal class CategorySearchTermListItemTest : ICategorySearchTermListItem
    {
        public Guid Id { get; set; }

        public ICategory Category { get; set; }

        public string Term { get; set; }

        public static void AssertDefault(ICategorySearchTermListItem categorySearchTermListItem)
        {
            Assert.AreEqual(CategorySearchTermTestValues.IdDefault, categorySearchTermListItem.Id);
            CategoryTest.AssertDefault(categorySearchTermListItem.Category);
            Assert.AreEqual(CategorySearchTermTestValues.TermDefault, categorySearchTermListItem.Term);
        }

        public static void AssertDefault2(ICategorySearchTermListItem categorySearchTermListItem)
        {
            Assert.AreEqual(CategorySearchTermTestValues.IdDefault2, categorySearchTermListItem.Id);
            CategoryTest.AssertDefault2(categorySearchTermListItem.Category);
            Assert.AreEqual(CategorySearchTermTestValues.TermDefault2, categorySearchTermListItem.Term);
        }
    }
}