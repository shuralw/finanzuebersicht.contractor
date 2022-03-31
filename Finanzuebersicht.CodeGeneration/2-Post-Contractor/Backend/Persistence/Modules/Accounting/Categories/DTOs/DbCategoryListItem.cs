using Finanzuebersicht.Backend.Generated.Contract.Persistence.Modules.Accounting.Categories;
using Finanzuebersicht.Backend.Generated.Persistence.Modules.Accounting.Categories;
using System;

namespace Finanzuebersicht.Backend.Generated.Persistence.Modules.Accounting.Categories
{
    internal class DbCategoryListItem : IDbCategoryListItem
    {
        public Guid Id { get; set; }

        public IDbCategory SuperCategory { get; set; }

        public string Title { get; set; }

        public string Color { get; set; }

        internal static IDbCategoryListItem FromEfCategory(EfCategory efCategory)
        {
            if (efCategory == null)
            {
                return null;
            }

            return new DbCategoryListItem()
            {
                Id = efCategory.Id,
                SuperCategory = DbCategory.FromEfCategory(efCategory.SuperCategory),
                Title = efCategory.Title,
                Color = efCategory.Color,
            };
        }
    }
}