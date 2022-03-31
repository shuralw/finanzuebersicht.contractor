using System;

namespace Finanzuebersicht.Backend.Generated.Contract.Persistence.Modules.Accounting.CategorySearchTerms
{
    public interface IDbCategorySearchTermUpdate
    {
        Guid Id { get; set; }

        Guid CategoryId { get; set; }

        string Term { get; set; }
    }
}