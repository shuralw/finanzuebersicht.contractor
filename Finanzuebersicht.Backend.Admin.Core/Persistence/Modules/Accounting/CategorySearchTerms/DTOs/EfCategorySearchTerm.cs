using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.Accounting.Categories;
using System;

namespace Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.Accounting.CategorySearchTerms
{
    public class EfCategorySearchTerm
    {
        public EfCategorySearchTerm()
        {
        }

        public Guid Id { get; set; }

        public Guid EmailUserId { get; set; }

        public Guid? CategoryId { get; set; }

        public virtual EfCategory Category { get; set; }

        public string Term { get; set; }
    }
}