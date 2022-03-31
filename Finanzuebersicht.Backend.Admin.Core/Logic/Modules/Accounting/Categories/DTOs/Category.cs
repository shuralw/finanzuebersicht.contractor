using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.Accounting.Categories;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.Accounting.Categories;
using System;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Modules.Accounting.Categories
{
    internal class Category : ICategory
    {
        public Guid Id { get; set; }

        public Guid? SuperCategoryId { get; set; }

        public string Title { get; set; }

        public string Color { get; set; }

        public decimal Summe { get; set; }

        internal static void UpdateDbCategory(IDbCategory dbCategory, ICategoryUpdate categoryUpdate)
        {
            dbCategory.SuperCategoryId = categoryUpdate.SuperCategoryId;
            dbCategory.Title = categoryUpdate.Title;
            dbCategory.Color = categoryUpdate.Color;
        }

        internal static ICategory FromDbCategory(IDbCategory dbCategory)
        {
            if (dbCategory == null)
            {
                return null;
            }

            return new Category()
            {
                Id = dbCategory.Id,
                SuperCategoryId = dbCategory.SuperCategoryId,
                Title = dbCategory.Title,
                Color = dbCategory.Color,
            };
        }

        internal static IDbCategory CreateDbCategory(Guid categoryId, ICategoryCreate categoryCreate)
        {
            return new DbCategory()
            {
                Id = categoryId,
                SuperCategoryId = categoryCreate.SuperCategoryId,
                Title = categoryCreate.Title,
                Color = categoryCreate.Color,
            };
        }
    }
}