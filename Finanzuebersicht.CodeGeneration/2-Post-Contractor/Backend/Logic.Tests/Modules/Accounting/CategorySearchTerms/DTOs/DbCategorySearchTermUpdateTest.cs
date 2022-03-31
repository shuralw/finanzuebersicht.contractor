using Finanzuebersicht.Backend.Generated.Contract.Persistence.Modules.Accounting.CategorySearchTerms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Generated.Logic.Tests.Modules.Accounting.CategorySearchTerms
{
    internal class DbCategorySearchTermUpdateTest : IDbCategorySearchTermUpdate
    {
        public Guid Id { get; set; }

        public Guid CategoryId { get; set; }

        public string Term { get; set; }

        public static IDbCategorySearchTermUpdate ForUpdate()
        {
            return new DbCategorySearchTermUpdateTest()
            {
                Id = CategorySearchTermTestValues.IdDefault,
                CategoryId = CategorySearchTermTestValues.CategoryIdForUpdate,
                Term = CategorySearchTermTestValues.TermForUpdate,
            };
        }

        public static void AssertUpdated(IDbCategorySearchTermUpdate dbCategorySearchTermUpdate)
        {
            Assert.AreEqual(CategorySearchTermTestValues.IdDefault, dbCategorySearchTermUpdate.Id);
            Assert.AreEqual(CategorySearchTermTestValues.CategoryIdForUpdate, dbCategorySearchTermUpdate.CategoryId);
            Assert.AreEqual(CategorySearchTermTestValues.TermForUpdate, dbCategorySearchTermUpdate.Term);
        }
    }
}