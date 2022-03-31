using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.Accounting.Categories;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.Accounting.Categories;
using System;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Modules.Accounting.Categories
{
    internal class DbCategoryUpdate : IDbCategoryUpdate
    {
        public Guid Id { get; set; }

        public Guid? SuperCategoryId { get; set; }

        public string Title { get; set; }

        public string Color { get; set; }

        internal static IDbCategoryUpdate FromCategoryUpdate(ICategoryUpdate categoryUpdate)
        {
            return new DbCategoryUpdate()
            {
                Id = categoryUpdate.Id,
                SuperCategoryId = categoryUpdate.SuperCategoryId,
                Title = categoryUpdate.Title,
                Color = categoryUpdate.Color,
            };
        }
    }
}