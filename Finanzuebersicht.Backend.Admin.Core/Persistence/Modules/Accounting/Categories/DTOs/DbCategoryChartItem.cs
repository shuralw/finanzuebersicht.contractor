using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.Accounting.Categories;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.Accounting.Categories;
using System;
using System.Linq;

namespace Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.Accounting.Categories
{
    internal class DbCategoryChartItem : IDbCategoryChartItem
    {
        public Guid Id { get; set; }

        public IDbCategory SuperCategory { get; set; }

        public string Title { get; set; }

        public string Color { get; set; }

        public decimal Summe { get; set; }

        internal static IDbCategoryChartItem FromEfCategory(EfCategory efCategory)
        {
            if (efCategory == null)
            {
                return null;
            }

            return new DbCategoryChartItem()
            {
                Id = efCategory.Id,
                SuperCategory = DbCategory.FromEfCategory(efCategory.Parent),
                Title = efCategory.Title,
                Color = efCategory.Color,
                Summe = efCategory.AccountingEntries.Sum(accountingEntry => accountingEntry.Betrag) ?? 0
            };
        }
    }
}