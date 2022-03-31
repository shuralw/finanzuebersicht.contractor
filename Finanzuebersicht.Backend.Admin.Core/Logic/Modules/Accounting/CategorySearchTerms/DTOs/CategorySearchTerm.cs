using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.Accounting.CategorySearchTerms;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.Accounting.CategorySearchTerms;
using System;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Modules.Accounting.CategorySearchTerms
{
    internal class CategorySearchTerm : ICategorySearchTerm
    {
        public Guid Id { get; set; }

        public Guid? CategoryId { get; set; }

        public string Term { get; set; }

        internal static void UpdateDbCategorySearchTerm(IDbCategorySearchTerm dbCategorySearchTerm, ICategorySearchTermUpdate categorySearchTermUpdate)
        {
            dbCategorySearchTerm.CategoryId = categorySearchTermUpdate.CategoryId;
            dbCategorySearchTerm.Term = categorySearchTermUpdate.Term;
        }

        internal static ICategorySearchTerm FromDbCategorySearchTerm(IDbCategorySearchTerm dbCategorySearchTerm)
        {
            if (dbCategorySearchTerm == null)
            {
                return null;
            }

            return new CategorySearchTerm()
            {
                Id = dbCategorySearchTerm.Id,
                CategoryId = dbCategorySearchTerm.CategoryId,
                Term = dbCategorySearchTerm.Term,
            };
        }

        internal static IDbCategorySearchTerm CreateDbCategorySearchTerm(Guid categorySearchTermId, ICategorySearchTermCreate categorySearchTermCreate)
        {
            return new DbCategorySearchTerm()
            {
                Id = categorySearchTermId,
                CategoryId = categorySearchTermCreate.CategoryId,
                Term = categorySearchTermCreate.Term,
            };
        }
    }
}