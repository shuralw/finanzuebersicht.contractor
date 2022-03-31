using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.Accounting.CategorySearchTerms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.Accounting.CategorySearchTerms
{
    internal class DbCategorySearchTermTest : IDbCategorySearchTerm
    {
        public Guid Id { get; set; }

        public Guid? CategoryId { get; set; }

        public string Term { get; set; }

        public static IDbCategorySearchTerm DbDefault()
        {
            return new DbCategorySearchTermTest()
            {
                Id = CategorySearchTermTestValues.IdDbDefault,
                CategoryId = CategorySearchTermTestValues.CategoryIdDbDefault,
                Term = CategorySearchTermTestValues.TermDbDefault,
            };
        }

        public static IDbCategorySearchTerm DbDefault2()
        {
            return new DbCategorySearchTermTest()
            {
                Id = CategorySearchTermTestValues.IdDbDefault2,
                CategoryId = CategorySearchTermTestValues.CategoryIdDbDefault2,
                Term = CategorySearchTermTestValues.TermDbDefault2,
            };
        }

        public static IDbCategorySearchTerm ForCreate()
        {
            return new DbCategorySearchTermTest()
            {
                Id = CategorySearchTermTestValues.IdForCreate,
                CategoryId = CategorySearchTermTestValues.CategoryIdForCreate,
                Term = CategorySearchTermTestValues.TermForCreate,
            };
        }

        public static void AssertDbDefault(IDbCategorySearchTerm dbCategorySearchTerm)
        {
            Assert.AreEqual(CategorySearchTermTestValues.IdDbDefault, dbCategorySearchTerm.Id);
            Assert.AreEqual(CategorySearchTermTestValues.CategoryIdDbDefault, dbCategorySearchTerm.CategoryId);
            Assert.AreEqual(CategorySearchTermTestValues.TermDbDefault, dbCategorySearchTerm.Term);
        }

        public static void AssertDbDefault2(IDbCategorySearchTerm dbCategorySearchTerm)
        {
            Assert.AreEqual(CategorySearchTermTestValues.IdDbDefault2, dbCategorySearchTerm.Id);
            Assert.AreEqual(CategorySearchTermTestValues.CategoryIdDbDefault2, dbCategorySearchTerm.CategoryId);
            Assert.AreEqual(CategorySearchTermTestValues.TermDbDefault2, dbCategorySearchTerm.Term);
        }

        public static void AssertForCreate(IDbCategorySearchTerm dbCategorySearchTerm)
        {
            Assert.AreEqual(CategorySearchTermTestValues.IdForCreate, dbCategorySearchTerm.Id);
            Assert.AreEqual(CategorySearchTermTestValues.CategoryIdForCreate, dbCategorySearchTerm.CategoryId);
            Assert.AreEqual(CategorySearchTermTestValues.TermForCreate, dbCategorySearchTerm.Term);
        }

        public static void AssertForUpdate(IDbCategorySearchTerm dbCategorySearchTerm)
        {
            Assert.AreEqual(CategorySearchTermTestValues.IdDbDefault, dbCategorySearchTerm.Id);
            Assert.AreEqual(CategorySearchTermTestValues.CategoryIdForUpdate, dbCategorySearchTerm.CategoryId);
            Assert.AreEqual(CategorySearchTermTestValues.TermForUpdate, dbCategorySearchTerm.Term);
        }
    }
}