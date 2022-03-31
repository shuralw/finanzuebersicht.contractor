using System;

namespace Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.Accounting.Categories
{
    public interface ICategoryUpdate
    {
        Guid Id { get; set; }

        Guid? SuperCategoryId { get; set; }

        string Title { get; set; }

        string Color { get; set; }
    }
}