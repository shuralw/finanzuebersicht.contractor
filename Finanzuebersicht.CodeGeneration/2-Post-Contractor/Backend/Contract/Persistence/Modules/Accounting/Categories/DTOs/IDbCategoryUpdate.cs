using System;

namespace Finanzuebersicht.Backend.Generated.Contract.Persistence.Modules.Accounting.Categories
{
    public interface IDbCategoryUpdate
    {
        Guid Id { get; set; }

        Guid SuperCategoryId { get; set; }

        string Title { get; set; }

        string Color { get; set; }
    }
}