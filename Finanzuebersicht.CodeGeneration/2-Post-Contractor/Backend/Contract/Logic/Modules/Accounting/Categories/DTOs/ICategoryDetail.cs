using Finanzuebersicht.Backend.Generated.Contract.Logic.Modules.Accounting.AccountingEntries;
using Finanzuebersicht.Backend.Generated.Contract.Logic.Modules.Accounting.Categories;
using Finanzuebersicht.Backend.Generated.Contract.Logic.Modules.Accounting.CategorySearchTerms;
using System;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Generated.Contract.Logic.Modules.Accounting.Categories
{
    public interface ICategoryDetail
    {
        Guid Id { get; set; }

        IEnumerable<IAccountingEntry> AccountingEntries { get; set; }

        IEnumerable<ICategory> ChildCategories { get; set; }

        ICategory SuperCategory { get; set; }

        IEnumerable<ICategorySearchTerm> CategorySearchTerms { get; set; }

        string Title { get; set; }

        string Color { get; set; }
    }
}