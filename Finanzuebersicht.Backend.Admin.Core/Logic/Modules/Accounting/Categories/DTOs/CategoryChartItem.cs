using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.Accounting.Categories;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.Accounting.Categories;
using System;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Modules.Accounting.Categories
{
    internal class CategoryChartItem : ICategoryChartItem
    {
        public Guid Id { get; set; }

        public ICategory SuperCategory { get; set; }

        public string Title { get; set; }

        public string Color { get; set; }

        public decimal Summe { get; set; }

        internal static ICategoryChartItem FromDbCategoryChartItem(IDbCategoryChartItem dbCategoryChartItem)
        {
            if (dbCategoryChartItem == null)
            {
                return null;
            }

            return new CategoryChartItem()
            {
                Id = dbCategoryChartItem.Id,
                SuperCategory = Accounting.Categories.Category.FromDbCategory(dbCategoryChartItem.SuperCategory),
                Title = dbCategoryChartItem.Title,
                Color = dbCategoryChartItem.Color,
                Summe = dbCategoryChartItem.Summe
            };
        }

        internal static ICategoryChartItem FromDbCategoryDetail(IDbCategoryDetail dbCategoryDetail)
        {
            if (dbCategoryDetail == null)
            {
                return null;
            }

            return new CategoryChartItem()
            {
                Id = dbCategoryDetail.Id,
                SuperCategory = Accounting.Categories.Category.FromDbCategory(dbCategoryDetail.SuperCategory),
                Title = dbCategoryDetail.Title,
                Color = dbCategoryDetail.Color
            };
        }
    }
}