using Finanzuebersicht.Backend.Generated.Contract.Logic.Modules.Accounting.Categories;
using Finanzuebersicht.Backend.Generated.Contract.Logic.Modules.Accounting.CategorySearchTerms;
using Finanzuebersicht.Backend.Generated.Contract.Persistence.Modules.Accounting.CategorySearchTerms;
using System;

namespace Finanzuebersicht.Backend.Generated.Logic.Modules.Accounting.CategorySearchTerms
{
    internal class CategorySearchTermDetail : ICategorySearchTermDetail
    {
        public Guid Id { get; set; }

        public ICategory Category { get; set; }

        public string Term { get; set; }

        internal static ICategorySearchTermDetail FromDbCategorySearchTermDetail(IDbCategorySearchTermDetail dbCategorySearchTermDetail)
        {
            if (dbCategorySearchTermDetail == null)
            {
                return null;
            }

            return new CategorySearchTermDetail()
            {
                Id = dbCategorySearchTermDetail.Id,
                Category = Accounting.Categories.Category.FromDbCategory(dbCategorySearchTermDetail.Category),
                Term = dbCategorySearchTermDetail.Term,
            };
        }
    }
}