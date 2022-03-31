using System;

namespace Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.Accounting.Categories
{
    public interface ICategoryChartItem
    {
        Guid Id { get; set; }

        ICategory SuperCategory { get; set; }

        string Title { get; set; }

        string Color { get; set; }

        decimal Summe { get; set; }
    }
}