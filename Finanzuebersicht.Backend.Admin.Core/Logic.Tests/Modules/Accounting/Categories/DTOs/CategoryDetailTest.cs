using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.Accounting.AccountingEntries;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.Accounting.Categories;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.Accounting.CategorySearchTerms;
using Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.Accounting.AccountingEntries;
using Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.Accounting.Categories;
using Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.Accounting.CategorySearchTerms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.Accounting.Categories
{
    internal class CategoryDetailTest : ICategoryDetail
    {
        public Guid Id { get; set; }

        public IEnumerable<IAccountingEntry> AccountingEntries { get; set; }

        public IEnumerable<ICategory> ChildCategories { get; set; }

        public ICategory SuperCategory { get; set; }

        public IEnumerable<ICategorySearchTerm> CategorySearchTerms { get; set; }

        public string Title { get; set; }

        public string Color { get; set; }

        public static ICategoryDetail Default()
        {
            return new CategoryDetailTest()
            {
                Id = CategoryTestValues.IdDefault,
                Title = CategoryTestValues.TitleDefault,
                Color = CategoryTestValues.ColorDefault,
            };
        }

        public static ICategoryDetail Default2()
        {
            return new CategoryDetailTest()
            {
                Id = CategoryTestValues.IdDefault2,
                Title = CategoryTestValues.TitleDefault2,
                Color = CategoryTestValues.ColorDefault2,
            };
        }

        public static void AssertDefault(ICategoryDetail categoryDetail)
        {
            Assert.AreEqual(CategoryTestValues.IdDefault, categoryDetail.Id);
            AccountingEntryTest.AssertDefault(categoryDetail.AccountingEntries.ToArray()[0]);
            CategoryTest.AssertDefault(categoryDetail.ChildCategories.ToArray()[0]);
            CategoryTest.AssertDefault(categoryDetail.SuperCategory);
            CategorySearchTermTest.AssertDefault(categoryDetail.CategorySearchTerms.ToArray()[0]);
            Assert.AreEqual(CategoryTestValues.TitleDefault, categoryDetail.Title);
            Assert.AreEqual(CategoryTestValues.ColorDefault, categoryDetail.Color);
        }

        public static void AssertDefault2(ICategoryDetail categoryDetail)
        {
            Assert.AreEqual(CategoryTestValues.IdDefault2, categoryDetail.Id);
            AccountingEntryTest.AssertDefault2(categoryDetail.AccountingEntries.ToArray()[0]);
            CategoryTest.AssertDefault2(categoryDetail.ChildCategories.ToArray()[0]);
            CategoryTest.AssertDefault2(categoryDetail.SuperCategory);
            CategorySearchTermTest.AssertDefault2(categoryDetail.CategorySearchTerms.ToArray()[0]);
            Assert.AreEqual(CategoryTestValues.TitleDefault2, categoryDetail.Title);
            Assert.AreEqual(CategoryTestValues.ColorDefault2, categoryDetail.Color);
        }
    }
}