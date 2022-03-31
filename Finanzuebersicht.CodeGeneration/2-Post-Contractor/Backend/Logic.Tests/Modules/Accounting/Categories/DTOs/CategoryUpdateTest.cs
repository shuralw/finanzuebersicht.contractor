using Finanzuebersicht.Backend.Generated.Contract.Logic.Modules.Accounting.Categories;
using System;

namespace Finanzuebersicht.Backend.Generated.Logic.Tests.Modules.Accounting.Categories
{
    internal class CategoryUpdateTest : ICategoryUpdate
    {
        public Guid Id { get; set; }

        public Guid SuperCategoryId { get; set; }

        public string Title { get; set; }

        public string Color { get; set; }

        public static ICategoryUpdate ForUpdate()
        {
            return new CategoryUpdateTest()
            {
                Id = CategoryTestValues.IdDefault,
                SuperCategoryId = CategoryTestValues.SuperCategoryIdForUpdate,
                Title = CategoryTestValues.TitleForUpdate,
                Color = CategoryTestValues.ColorForUpdate,
            };
        }
    }
}