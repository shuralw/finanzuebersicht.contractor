using System;

namespace Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.Accounting.CategorySearchTerms
{
    public interface ICategorySearchTermCreate
    {
        Guid? CategoryId { get; set; }

        string Term { get; set; }
    }
}