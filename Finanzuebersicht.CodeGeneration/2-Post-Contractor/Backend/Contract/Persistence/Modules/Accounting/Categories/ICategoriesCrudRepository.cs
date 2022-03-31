using Contract.Architecture.Backend.Common.Contract.Persistence;
using System;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Generated.Contract.Persistence.Modules.Accounting.Categories
{
    public interface ICategoriesCrudRepository
    {
        void CreateCategory(IDbCategory dbCategory);

        void DeleteCategory(Guid categoryId);

        bool DoesCategoryExist(Guid categoryId);

        IDbCategory GetCategory(Guid categoryId);

        IDbCategoryDetail GetCategoryDetail(Guid categoryId);

        IDbPagedResult<IDbCategoryListItem> GetPagedCategories();

        IEnumerable<IDbCategory> GetAllCategories();

        void UpdateCategory(IDbCategoryUpdate dbCategoryUpdate);
    }
}