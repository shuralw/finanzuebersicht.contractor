using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.Accounting.Categories;
using System;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Modules.Accounting.Categories
{
    internal class DbCategory : IDbCategory
    {
        public Guid Id { get; set; }

        public object ParentId { get; set; }

        public string Title { get; set; }

        public string Color { get; set; }

        public decimal Summe { get; set; }
    }
}