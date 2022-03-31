using System;

namespace Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.Accounting.CategorySearchTerms
{
    public interface IDbCategorySearchTerm
    {
        Guid Id { get; set; }

        Guid? CategoryId { get; set; }

        string Term { get; set; }
    }
}