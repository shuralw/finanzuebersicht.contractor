using System;

namespace Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.Accounting.Categories
{
    public interface ICategoryCreate
    {
        Guid? SuperCategoryId { get; set; }

        string Title { get; set; }

        string Color { get; set; }
    }
}