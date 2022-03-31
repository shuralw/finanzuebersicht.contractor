using Finanzuebersicht.Backend.Generated.Contract.Logic.Modules.Accounting.Categories;
using System;

namespace Finanzuebersicht.Backend.Generated.Logic.Tests.Modules.Accounting.Categories
{
    internal class CategoryCreateTest : ICategoryCreate
    {
        public Guid Id { get; set; }

        public Guid SuperCategoryId { get; set; }

        public string Title { get; set; }

        public string Color { get; set; }

        public static ICategoryCreate ForCreate()
        {
            return new CategoryCreateTest()
            {
                Id = CategoryTestValues.IdForCreate,
                SuperCategoryId = CategoryTestValues.SuperCategoryIdForCreate,
                Title = CategoryTestValues.TitleForCreate,
                Color = CategoryTestValues.ColorForCreate,
            };
        }
    }
}