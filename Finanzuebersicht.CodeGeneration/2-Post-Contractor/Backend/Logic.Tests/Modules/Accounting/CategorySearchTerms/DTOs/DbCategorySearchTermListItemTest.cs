using Contract.Architecture.Backend.Common.Contract.Persistence;
using Contract.Architecture.Backend.Common.Persistence;
using Finanzuebersicht.Backend.Generated.Contract.Persistence.Modules.Accounting.Categories;
using Finanzuebersicht.Backend.Generated.Contract.Persistence.Modules.Accounting.CategorySearchTerms;
using Finanzuebersicht.Backend.Generated.Logic.Tests.Modules.Accounting.Categories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Generated.Logic.Tests.Modules.Accounting.CategorySearchTerms
{
    internal class DbCategorySearchTermListItemTest : IDbCategorySearchTermListItem
    {
        public Guid Id { get; set; }

        public IDbCategory Category { get; set; }

        public string Term { get; set; }

        public static IDbCategorySearchTermListItem Default()
        {
            return new DbCategorySearchTermListItemTest()
            {
                Id = CategorySearchTermTestValues.IdDefault,
                Category = DbCategoryTest.Default(),
                Term = CategorySearchTermTestValues.TermDefault,
            };
        }

        public static IDbCategorySearchTermListItem Default2()
        {
            return new DbCategorySearchTermListItemTest()
            {
                Id = CategorySearchTermTestValues.IdDefault2,
                Category = DbCategoryTest.Default2(),
                Term = CategorySearchTermTestValues.TermDefault2,
            };
        }

        public static IDbPagedResult<IDbCategorySearchTermListItem> ForPaged()
        {
            return new DbPagedResult<IDbCategorySearchTermListItem>()
            {
                Data = new List<IDbCategorySearchTermListItem>()
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