using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.Accounting.Categories;
using Microsoft.EntityFrameworkCore;
using System;

namespace Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.Accounting.Categories
{
    internal class DbCategory : IDbCategory
    {
        public Guid Id { get; set; }

        public object ParentId { get; set; }

        public string Title { get; set; }

        public string Color { get; set; }

        public decimal Summe { get; set; }

        internal static void UpdateEfCategory(EfCategory efCategory, IDbCategoryUpdate dbCategoryUpdate)
        {
            efCategory.ParentId = (HierarchyId)dbCategoryUpdate.ParentId;
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
                ParentId = efCategory.ParentId,
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
                ParentId = (HierarchyId)dbCategory.ParentId,
                Title = dbCategory.Title,
                Color = dbCategory.Color,
            };
        }
    }
}