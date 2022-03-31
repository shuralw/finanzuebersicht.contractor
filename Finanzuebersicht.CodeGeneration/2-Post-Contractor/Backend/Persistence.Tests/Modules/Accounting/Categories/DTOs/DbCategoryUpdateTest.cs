using Finanzuebersicht.Backend.Generated.Contract.Persistence.Modules.Accounting.Categories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Finanzuebersicht.Backend.Generated.Persistence.Tests.Modules.Accounting.Categories
{
    internal class DbCategoryUpdateTest : IDbCategoryUpdate
    {
        public Guid Id { get; set; }

        public Guid SuperCategoryId { get; set; }

        public string Title { get; set; }

        public string Color { get; set; }

        public static IDbCategoryUpdate ForUpdate()
        {
            return new DbCategoryUpdateTest()
            {
                Id = CategoryTestValues.IdDbDefault,
                SuperCategoryId = CategoryTestValues.SuperCategoryIdForUpdate,
                Title = CategoryTestValues.TitleForUpdate,
                Color = CategoryTestValues.ColorForUpdate,
            };
        }
    }
}