using System;

namespace Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.Accounting.Categories
{
    public interface IDbCategory
    {
        Guid Id { get; set; }

        object ParentId { get; set; }

        string Title { get; set; }

        string Color { get; set; }

        decimal Summe { get; set; }
    }
}