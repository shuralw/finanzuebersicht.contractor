using Finanzuebersicht.Backend.Generated.Contract.Persistence.Modules.Accounting.Categories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Generated.Logic.Tests.Modules.Accounting.Categories
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
                Id = CategoryTestValues.IdDefault,
                SuperCategoryId = CategoryTestValues.SuperCategoryIdForUpdate,
                Title = CategoryTestValues.TitleForUpdate,
                Color = CategoryTestValues.ColorForUpdate,
            };
        }

        public static void AssertUpdated(IDbCategoryUpdate dbCategoryUpdate)
        {
            Assert.AreEqual(CategoryTestValues.IdDefault, dbCategoryUpdate.Id);
            Assert.AreEqual(CategoryTestValues.SuperCategoryIdForUpdate, dbCategoryUpdate.SuperCategoryId);
            Assert.AreEqual(CategoryTestValues.TitleForUpdate, dbCategoryUpdate.Title);
            Assert.AreEqual(CategoryTestValues.ColorForUpdate, dbCategoryUpdate.Color);
        }
    }
}