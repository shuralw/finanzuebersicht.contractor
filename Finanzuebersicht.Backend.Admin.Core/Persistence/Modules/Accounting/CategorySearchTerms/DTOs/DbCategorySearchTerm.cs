using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.Accounting.CategorySearchTerms;
using System;

namespace Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.Accounting.CategorySearchTerms
{
    internal class DbCategorySearchTerm : IDbCategorySearchTerm
    {
        public Guid Id { get; set; }

        public Guid? CategoryId { get; set; }

        public string Term { get; set; }

        internal static void UpdateEfCategorySearchTerm(EfCategorySearchTerm efCategorySearchTerm, IDbCategorySearchTermUpdate dbCategorySearchTermUpdate)
        {
            efCategorySearchTerm.CategoryId = dbCategorySearchTermUpdate.CategoryId;
            efCategorySearchTerm.Term = dbCategorySearchTermUpdate.Term;
        }

        internal static IDbCategorySearchTerm FromEfCategorySearchTerm(EfCategorySearchTerm efCategorySearchTerm)
        {
            if (efCategorySearchTerm == null)
            {
                return null;
            }

            return new DbCategorySearchTerm()
            {
                Id = efCategorySearchTerm.Id,
                CategoryId = efCategorySearchTerm.CategoryId,
                Term = efCategorySearchTerm.Term,
            };
        }

        internal static EfCategorySearchTerm ToEfCategorySearchTerm(IDbCategorySearchTerm dbCategorySearchTerm, Guid emailUserId)
        {
            return new EfCategorySearchTerm()
            {
                Id = dbCategorySearchTerm.Id,
                EmailUserId = emailUserId,
                CategoryId = dbCategorySearchTerm.CategoryId,
                Term = dbCategorySearchTerm.Term,
            };
        }
    }
}