using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.Accounting.CategorySearchTerms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.Accounting.CategorySearchTerms
{
    internal class DbCategorySearchTermUpdateTest : IDbCategorySearchTermUpdate
    {
        public Guid Id { get; set; }

        public Guid? CategoryId { get; set; }

        public string Term { get; set; }

        public static IDbCategorySearchTermUpdate ForUpdate()
        {
            return new DbCategorySearchTermUpdateTest()
            {
                Id = CategorySearchTermTestValues.IdDbDefault,
                CategoryId = CategorySearchTermTestValues.CategoryIdForUpdate,
                Term = CategorySearchTermTestValues.TermForUpdate,
            };
        }
    }
}