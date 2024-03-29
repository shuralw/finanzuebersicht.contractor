using System;

namespace Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.Accounting.CategorySearchTerms
{
    public interface ICategorySearchTermUpdate
    {
        Guid Id { get; set; }

        Guid? CategoryId { get; set; }

        string Term { get; set; }
    }
}