using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.Accounting.Categories;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Tools.Pagination;
using Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.Accounting.Categories;
using Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Tools.Pagination;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.Accounting.Categories
{
    internal class DbCategoryListItemTest : IDbCategoryListItem
    {
        public Guid Id { get; set; }

        public IDbCategory SuperCategory { get; set; }

        public string Title { get; set; }

        public string Color { get; set; }

        public static IDbCategoryListItem Default()
        {
            return new DbCategoryListItemTest()
            {
                Id = CategoryTestValues.IdDefault,
                SuperCategory = DbCategoryTest.Default(),
                Title = CategoryTestValues.TitleDefault,
                Color = CategoryTestValues.ColorDefault,
            };
        }

        public static IDbCategoryListItem Default2()
        {
            return new DbCategoryListItemTest()
            {
                Id = CategoryTestValues.IdDefault2,
                SuperCategory = DbCategoryTest.Default2(),
                Title = CategoryTestValues.TitleDefault2,
                Color = CategoryTestValues.ColorDefault2,
            };
        }

        public static IDbPagedResult<IDbCategoryListItem> ForPaged()
        {
            return new DbPagedResult<IDbCategoryListItem>()
            {
                Data = new List<IDbCategoryListItem>()
                {
                    Default(),
                    Default2()
                },
                TotalCount = 2,
                Count = 2,
                Limit = 10,
                Offset = 0
            };
        }
    }
}