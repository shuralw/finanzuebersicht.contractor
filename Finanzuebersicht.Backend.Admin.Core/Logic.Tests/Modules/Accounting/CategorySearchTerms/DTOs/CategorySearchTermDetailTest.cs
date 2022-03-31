using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.Accounting.Categories;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.Accounting.CategorySearchTerms;
using Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.Accounting.Categories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.Accounting.CategorySearchTerms
{
    internal class CategorySearchTermDetailTest : ICategorySearchTermDetail
    {
        public Guid Id { get; set; }

        public ICategory Category { get; set; }

        public string Term { get; set; }

        public static ICategorySearchTermDetail Default()
        {
            return new CategorySearchTermDetailTest()
            {
                Id = CategorySearchTermTestValues.IdDefault,
                Term = CategorySearchTermTestValues.TermDefault,
            };
        }

        public static ICategorySearchTermDetail Default2()
        {
            return new CategorySearchTermDetailTest()
            {
                Id = CategorySearchTermTestValues.IdDefault2,
                Term = CategorySearchTermTestValues.TermDefault2,
            };
        }

        public static void AssertDefault(ICategorySearchTermDetail categorySearchTermDetail)
        {
            Assert.AreEqual(CategorySearchTermTestValues.IdDefault, categorySearchTermDetail.Id);
            CategoryTest.AssertDefault(categorySearchTermDetail.Category);
            Assert.AreEqual(CategorySearchTermTestValues.TermDefault, categorySearchTermDetail.Term);
        }

        public static void AssertDefault2(ICategorySearchTermDetail categorySearchTermDetail)
        {
            Assert.AreEqual(CategorySearchTermTestValues.IdDefault2, categorySearchTermDetail.Id);
            CategoryTest.AssertDefault2(categorySearchTermDetail.Category);
            Assert.AreEqual(CategorySearchTermTestValues.TermDefault2, categorySearchTermDetail.Term);
        }
    }
}