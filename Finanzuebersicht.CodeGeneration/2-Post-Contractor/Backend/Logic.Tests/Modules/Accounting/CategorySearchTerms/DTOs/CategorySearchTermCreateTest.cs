using Finanzuebersicht.Backend.Generated.Contract.Logic.Modules.Accounting.CategorySearchTerms;
using System;

namespace Finanzuebersicht.Backend.Generated.Logic.Tests.Modules.Accounting.CategorySearchTerms
{
    internal class CategorySearchTermCreateTest : ICategorySearchTermCreate
    {
        public Guid Id { get; set; }

        public Guid CategoryId { get; set; }

        public string Term { get; set; }

        public static ICategorySearchTermCreate ForCreate()
        {
            return new CategorySearchTermCreateTest()
            {
                Id = CategorySearchTermTestValues.IdForCreate,
                CategoryId = CategorySearchTermTestValues.CategoryIdForCreate,
                Term = CategorySearchTermTestValues.TermForCreate,
            };
        }
    }
}