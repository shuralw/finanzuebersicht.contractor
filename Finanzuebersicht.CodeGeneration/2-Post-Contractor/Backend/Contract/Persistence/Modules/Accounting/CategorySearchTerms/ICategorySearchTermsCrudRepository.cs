using Contract.Architecture.Backend.Common.Contract.Persistence;
using System;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Generated.Contract.Persistence.Modules.Accounting.CategorySearchTerms
{
    public interface ICategorySearchTermsCrudRepository
    {
        void CreateCategorySearchTerm(IDbCategorySearchTerm dbCategorySearchTerm);

        void DeleteCategorySearchTerm(Guid categorySearchTermId);

        bool DoesCategorySearchTermExist(Guid categorySearchTermId);

        IDbCategorySearchTerm GetCategorySearchTerm(Guid categorySearchTermId);

        IDbCategorySearchTermDetail GetCategorySearchTermDetail(Guid categorySearchTermId);

        IDbPagedResult<IDbCategorySearchTermListItem> GetPagedCategorySearchTerms();

        IEnumerable<IDbCategorySearchTerm> GetAllCategorySearchTerms();

        void UpdateCategorySearchTerm(IDbCategorySearchTermUpdate dbCategorySearchTermUpdate);
    }
}