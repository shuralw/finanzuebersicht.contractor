using System;

namespace Finanzuebersicht.Backend.Generated.Contract.Logic.Modules.Accounting.Categories
{
    public interface ICategory
    {
        Guid Id { get; set; }

        Guid SuperCategoryId { get; set; }

        string Title { get; set; }

        string Color { get; set; }
    }
}