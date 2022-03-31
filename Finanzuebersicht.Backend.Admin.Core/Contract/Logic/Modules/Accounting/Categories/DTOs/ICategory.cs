using System;

namespace Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.Accounting.Categories
{
    public interface ICategory
    {
        Guid Id { get; set; }

        Guid? SuperCategoryId { get; set; }

        string Title { get; set; }

        string Color { get; set; }
        decimal Summe { get; set; }
    }
}