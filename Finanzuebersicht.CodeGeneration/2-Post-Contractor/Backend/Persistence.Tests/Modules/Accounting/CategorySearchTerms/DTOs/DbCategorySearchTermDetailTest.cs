using Finanzuebersicht.Backend.Generated.Contract.Persistence.Modules.Accounting.Categories;
using Finanzuebersicht.Backend.Generated.Contract.Persistence.Modules.Accounting.CategorySearchTerms;
using Finanzuebersicht.Backend.Generated.Persistence.Tests.Modules.Accounting.Categories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Finanzuebersicht.Backend.Generated.Persistence.Tests.Modules.Accounting.CategorySearchTerms
{
    internal class DbCategorySearchTermDetailTest : IDbCategorySearchTermDetail
    {
        public Guid Id { get; set; }

        public IDbCategory Category { get; set; }

        public string Term { get; set; }

        public static void AssertDbDefault(IDbCategorySearchTermDetail dbCategorySearchTermDetail)
        {
            Assert.AreEqual(CategorySearchTermTestValues.IdDbDefault, dbCategorySearchTermDetail.Id);
            DbCategoryTest.AssertDbDefault(dbCategorySearchTermDetail.Category);
            Assert.AreEqual(CategorySearchTermTestValues.TermDbDefault, dbCategorySearchTermDetail.Term);
        }
    }
}