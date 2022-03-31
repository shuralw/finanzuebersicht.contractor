using System;

namespace Finanzuebersicht.Backend.Generated.Contract.Logic.Modules.Accounting.Categories
{
    public interface ICategoryCreate
    {
        Guid SuperCategoryId { get; set; }

        string Title { get; set; }

        string Color { get; set; }
    }
}