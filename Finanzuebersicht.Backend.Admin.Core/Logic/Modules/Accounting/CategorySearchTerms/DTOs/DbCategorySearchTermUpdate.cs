using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.Accounting.CategorySearchTerms;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.Accounting.CategorySearchTerms;
using System;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Modules.Accounting.CategorySearchTerms
{
    internal class DbCategorySearchTermUpdate : IDbCategorySearchTermUpdate
    {
        public Guid Id { get; set; }

        public Guid? CategoryId { get; set; }

        public string Term { get; set; }

        internal static IDbCategorySearchTermUpdate FromCategorySearchTermUpdate(ICategorySearchTermUpdate categorySearchTermUpdate)
        {
            return new DbCategorySearchTermUpdate()
            {
                Id = categorySearchTermUpdate.Id,
                CategoryId = categorySearchTermUpdate.CategoryId,
                Term = categorySearchTermUpdate.Term,
            };
        }
    }
}