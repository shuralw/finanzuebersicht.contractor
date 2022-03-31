using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.Accounting.Categories;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.Accounting.CategorySearchTerms;
using Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.Accounting.Categories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.Accounting.CategorySearchTerms
{
    internal class DbCategorySearchTermDetailTest : IDbCategorySearchTermDetail
    {
        public Guid Id { get; set; }

        public IDbCategory Category { get; set; }

        public string Term { get; set; }

        public static IDbCategorySearchTermDetail Default()
        {
            return new DbCategorySearchTermDetailTest()
            {
                Id = CategorySearchTermTestValues.IdDefault,
                Category = DbCategoryTest.Default(),
                Term = CategorySearchTermTestValues.TermDefault,
            };
        }

        public static IDbCategorySearchTermDetail Default2()
        {
            return new DbCategorySearchTermDetailTest()
            {
                Id = CategorySearchTermTestValues.IdDefault,
                Category = DbCategoryTest.Default2(),
                Term = CategorySearchTermTestValues.TermDefault2,
            };
        }

        public static void AssertDefault(IDbCategorySearchTermDetail dbCategorySearchTermDetail)
        {
            Assert.AreEqual(CategorySearchTermTestValues.IdDefault, dbCategorySearchTermDetail.Id);
            DbCategoryTest.AssertDefault(dbCategorySearchTermDetail.Category);
        }

        public static void AssertDefault2(IDbCategorySearchTermDetail dbCategorySearchTermDetail)
        {
            Assert.AreEqual(CategorySearchTermTestValues.IdDefault2, dbCategorySearchTermDetail.Id);
            DbCategoryTest.AssertDefault2(dbCategorySearchTermDetail.Category);
            Assert.AreEqual(CategorySearchTermTestValues.TermDefault2, dbCategorySearchTermDetail.Term);
        }
    }
}