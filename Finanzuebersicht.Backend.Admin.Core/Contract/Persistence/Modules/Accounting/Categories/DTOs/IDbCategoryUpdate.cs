using System;

namespace Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.Accounting.Categories
{
    public interface IDbCategoryUpdate
    {
        Guid Id { get; set; }

        string Title { get; set; }

        string Color { get; set; }

        object ParentId { get; set; }
    }
}