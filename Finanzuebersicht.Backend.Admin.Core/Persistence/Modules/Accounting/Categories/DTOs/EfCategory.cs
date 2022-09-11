using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.Accounting.AccountingEntries;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.Accounting.Categories;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.Accounting.CategorySearchTerms;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.Accounting.Categories
{
    public class EfCategory
    {
        public EfCategory()
        {
            this.AccountingEntries = new HashSet<EfAccountingEntry>();
            this.ChildCategories = new HashSet<EfCategory>();
            this.CategorySearchTerms = new HashSet<EfCategorySearchTerm>();
        }

        public Guid Id { get; set; }

        public Guid EmailUserId { get; set; }

        public virtual ICollection<EfAccountingEntry> AccountingEntries { get; set; }

        public virtual ICollection<EfCategory> ChildCategories { get; set; }

        public HierarchyId HierarchyId { get; set; }

        public EfCategory Parent { get; set; }

        public HierarchyId ParentId { get; set; }

        public virtual ICollection<EfCategorySearchTerm> CategorySearchTerms { get; set; }

        public string Title { get; set; }

        public string Color { get; set; }
    }
}