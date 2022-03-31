using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.Accounting.AccountingEntries;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.Accounting.Categories;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.Accounting.CategorySearchTerms;
using System;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.Accounting.Categories
{
    public interface IDbCategoryDetail
    {
        Guid Id { get; set; }

        IEnumerable<IDbAccountingEntry> AccountingEntries { get; set; }

        IEnumerable<IDbCategory> ChildCategories { get; set; }

        IDbCategory SuperCategory { get; set; }

        IEnumerable<IDbCategorySearchTerm> CategorySearchTerms { get; set; }

        string Title { get; set; }

        string Color { get; set; }
    }
}