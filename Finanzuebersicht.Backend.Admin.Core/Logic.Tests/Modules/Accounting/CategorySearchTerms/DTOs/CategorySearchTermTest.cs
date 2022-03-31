using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.Accounting.CategorySearchTerms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.Accounting.CategorySearchTerms
{
    internal class CategorySearchTermTest : ICategorySearchTerm
    {
        public Guid Id { get; set; }

        public Guid? CategoryId { get; set; }

        public string Term { get; set; }

        public static ICategorySearchTerm Default()
        {
            return new CategorySearchTermTest()
            {
                Id = CategorySearchTermTestValues.IdDefault,
                CategoryId = CategorySearchTermTestValues.CategoryIdDefault,
                Term = CategorySearchTermTestValues.TermDefault,
            };
        }

        public static ICategorySearchTerm Default2()
        {
            return new CategorySearchTermTest()
            {
                Id = CategorySearchTermTestValues.IdDefault2,
                CategoryId = CategorySearchTermTestValues.CategoryIdDefault2,
                Term = CategorySearchTermTestValues.TermDefault2,
            };
        }

        public static void AssertDefault(ICategorySearchTerm categorySearchTerm)
        {
            Assert.AreEqual(CategorySearchTermTestValues.IdDefault, categorySearchTerm.Id);
            Assert.AreEqual(CategorySearchTermTestValues.CategoryIdDefault, categorySearchTerm.CategoryId);
            Assert.AreEqual(CategorySearchTermTestValues.TermDefault, categorySearchTerm.Term);
        }

        public static void AssertDefault2(ICategorySearchTerm categorySearchTerm)
        {
            Assert.AreEqual(CategorySearchTermTestValues.IdDefault2, categorySearchTerm.Id);
            Assert.AreEqual(CategorySearchTermTestValues.CategoryIdDefault2, categorySearchTerm.CategoryId);
            Assert.AreEqual(CategorySearchTermTestValues.TermDefault2, categorySearchTerm.Term);
        }
    }
}