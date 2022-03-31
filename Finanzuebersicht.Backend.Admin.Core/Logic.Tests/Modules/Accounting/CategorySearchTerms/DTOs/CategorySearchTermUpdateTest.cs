using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.Accounting.CategorySearchTerms;
using System;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.Accounting.CategorySearchTerms
{
    internal class CategorySearchTermUpdateTest : ICategorySearchTermUpdate
    {
        public Guid Id { get; set; }

        public Guid? CategoryId { get; set; }

        public string Term { get; set; }

        public static ICategorySearchTermUpdate ForUpdate()
        {
            return new CategorySearchTermUpdateTest()
            {
                Id = CategorySearchTermTestValues.IdDefault,
                CategoryId = CategorySearchTermTestValues.CategoryIdForUpdate,
                Term = CategorySearchTermTestValues.TermForUpdate,
            };
        }
    }
}