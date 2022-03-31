using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.Accounting.Categories;
using System;

public interface IDbCategoryChartItem
{
    Guid Id { get; set; }

    IDbCategory SuperCategory { get; set; }

    string Title { get; set; }

    string Color { get; set; }

    decimal Summe { get; set; }
}