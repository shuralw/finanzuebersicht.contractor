using Finanzuebersicht.Backend.Generated.Contract.Persistence.Modules.Accounting.Categories;
using System;

namespace Finanzuebersicht.Backend.Generated.Persistence.Modules.Accounting.Categories
{
    internal class DbCategory : IDbCategory
    {
        public Guid Id { get; set; }

        public Guid SuperCategoryId { get; set; }

        public string Title { get; set; }

        public string Color { get; set; }

        internal static void UpdateEfCategory(EfCategory efCategory, IDbCategoryUpdate dbCategoryUpdate)
        {
            efCategory.SuperCategoryId = dbCategoryUpdate.SuperCategoryId;
            efCategory.Title = dbCategoryUpdate.Title;
            efCategory.Color = dbCategoryUpdate.Color;
        }

        internal static IDbCategory FromEfCategory(EfCategory efCategory)
        {
            if (efCategory == null)
            {
                return null;
            }

            return new DbCategory()
            {
                Id = efCategory.Id,
                SuperCategoryId = efCategory.SuperCategoryId,
                Title = efCategory.Title,
                Color = efCategory.Color,
            };
        }

        internal static EfCategory ToEfCategory(IDbCategory dbCategory, Guid emailUserId)
        {
            return new EfCategory()
            {
                Id = dbCategory.Id,
                EmailUserId = emailUserId,
                SuperCategoryId = dbCategory.SuperCategoryId,
                Title = dbCategory.Title,
                Color = dbCategory.Color,
            };
        }
    }
}