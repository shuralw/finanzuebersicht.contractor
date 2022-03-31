using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.Accounting.CategorySearchTerms;
using System;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Modules.Accounting.CategorySearchTerms
{
    internal class DbCategorySearchTerm : IDbCategorySearchTerm
    {
        public Guid Id { get; set; }

        public Guid? CategoryId { get; set; }

        public string Term { get; set; }
    }
}