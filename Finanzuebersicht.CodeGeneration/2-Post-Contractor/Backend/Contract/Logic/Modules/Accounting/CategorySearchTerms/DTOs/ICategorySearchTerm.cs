using System;

namespace Finanzuebersicht.Backend.Generated.Contract.Logic.Modules.Accounting.CategorySearchTerms
{
    public interface ICategorySearchTerm
    {
        Guid Id { get; set; }

        Guid CategoryId { get; set; }

        string Term { get; set; }
    }
}