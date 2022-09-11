using System;

namespace Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.Accounting.Categories
{
    public interface ICategory
    {
        Guid Id { get; set; }

        object ParentId { get; set; }

        string Title { get; set; }

        string Color { get; set; }

        decimal Summe { get; set; }
    }
}