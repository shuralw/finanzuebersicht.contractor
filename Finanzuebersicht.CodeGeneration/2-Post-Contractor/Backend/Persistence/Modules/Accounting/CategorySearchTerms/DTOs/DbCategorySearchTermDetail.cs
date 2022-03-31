using Finanzuebersicht.Backend.Generated.Contract.Persistence.Modules.Accounting.Categories;
using Finanzuebersicht.Backend.Generated.Contract.Persistence.Modules.Accounting.CategorySearchTerms;
using Finanzuebersicht.Backend.Generated.Persistence.Modules.Accounting.Categories;
using System;

namespace Finanzuebersicht.Backend.Generated.Persistence.Modules.Accounting.CategorySearchTerms
{
    internal class DbCategorySearchTermDetail : IDbCategorySearchTermDetail
    {
        public Guid Id { get; set; }

        public IDbCategory Category { get; set; }

        public string Term { get; set; }

        internal static IDbCategorySearchTermDetail FromEfCategorySearchTerm(EfCategorySearchTerm efCategorySearchTerm)
        {
            if (efCategorySearchTerm == null)
            {
                return null;
            }

            return new DbCategorySearchTermDetail()
            {
                Id = efCategorySearchTerm.Id,
                Category = DbCategory.FromEfCategory(efCategorySearchTerm.Category),
                Term = efCategorySearchTerm.Term,
            };
        }
    }
}