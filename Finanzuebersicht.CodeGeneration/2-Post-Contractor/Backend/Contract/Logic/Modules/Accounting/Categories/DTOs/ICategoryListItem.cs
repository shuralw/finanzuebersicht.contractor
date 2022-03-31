using Finanzuebersicht.Backend.Generated.Contract.Logic.Modules.Accounting.Categories;
using System;

namespace Finanzuebersicht.Backend.Generated.Contract.Logic.Modules.Accounting.Categories
{
    public interface ICategoryListItem
    {
        Guid Id { get; set; }

        ICategory SuperCategory { get; set; }

        string Title { get; set; }

        string Color { get; set; }
    }
}