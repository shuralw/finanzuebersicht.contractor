using Finanzuebersicht.Backend.Generated.Contract.Logic.Modules.Accounting.Categories;
using Finanzuebersicht.Backend.Generated.Contract.Persistence.Modules.Accounting.Categories;
using System;

namespace Finanzuebersicht.Backend.Generated.Logic.Modules.Accounting.Categories
{
    internal class CategoryListItem : ICategoryListItem
    {
        public Guid Id { get; set; }

        public ICategory SuperCategory { get; set; }

        public string Title { get; set; }

        public string Color { get; set; }

        internal static ICategoryListItem FromDbCategoryListItem(IDbCategoryListItem dbCategoryListItem)
        {
            if (dbCategoryListItem == null)
            {
                return null;
            }

            return new CategoryListItem()
            {
                Id = dbCategoryListItem.Id,
                SuperCategory = Accounting.Categories.Category.FromDbCategory(dbCategoryListItem.SuperCategory),
                Title = dbCategoryListItem.Title,
                Color = dbCategoryListItem.Color,
            };
        }
    }
}