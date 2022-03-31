using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.Accounting.Categories;
using System;

namespace Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.Accounting.CategorySearchTerms
{
    public interface IDbCategorySearchTermListItem
    {
        Guid Id { get; set; }

        IDbCategory Category { get; set; }

        string Term { get; set; }
    }
}