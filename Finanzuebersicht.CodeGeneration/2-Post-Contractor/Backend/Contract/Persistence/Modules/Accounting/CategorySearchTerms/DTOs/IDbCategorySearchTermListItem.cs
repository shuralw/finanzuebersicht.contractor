using Finanzuebersicht.Backend.Generated.Contract.Persistence.Modules.Accounting.Categories;
using System;

namespace Finanzuebersicht.Backend.Generated.Contract.Persistence.Modules.Accounting.CategorySearchTerms
{
    public interface IDbCategorySearchTermListItem
    {
        Guid Id { get; set; }

        IDbCategory Category { get; set; }

        string Term { get; set; }
    }
}