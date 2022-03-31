using Finanzuebersicht.Backend.Generated.Contract.Logic.Modules.Accounting.Categories;
using System;

namespace Finanzuebersicht.Backend.Generated.Contract.Logic.Modules.Accounting.CategorySearchTerms
{
    public interface ICategorySearchTermListItem
    {
        Guid Id { get; set; }

        ICategory Category { get; set; }

        string Term { get; set; }
    }
}