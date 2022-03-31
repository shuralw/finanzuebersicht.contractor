using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.Accounting.Categories;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.Accounting.CategorySearchTerms;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.Accounting.CategorySearchTerms;
using System;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Modules.Accounting.CategorySearchTerms
{
    internal class CategorySearchTermListItem : ICategorySearchTermListItem
    {
        public Guid Id { get; set; }

        public ICategory Category { get; set; }

        public string Term { get; set; }

        internal static ICategorySearchTermListItem FromDbCategorySearchTermListItem(IDbCategorySearchTermListItem dbCategorySearchTermListItem)
        {
            if (dbCategorySearchTermListItem == null)
            {
                return null;
            }

            return new CategorySearchTermListItem()
            {
                Id = dbCategorySearchTermListItem.Id,
                Category = Accounting.Categories.Category.FromDbCategory(dbCategorySearchTermListItem.Category),
                Term = dbCategorySearchTermListItem.Term,
            };
        }
    }
}