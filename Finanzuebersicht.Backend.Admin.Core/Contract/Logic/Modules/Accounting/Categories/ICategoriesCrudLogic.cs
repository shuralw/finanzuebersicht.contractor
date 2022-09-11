using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.LogicResults;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Tools.Pagination;
using System;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.Accounting.Categories
{
    public interface ICategoriesCrudLogic
    {
        ILogicResult<Guid> CreateCategory(ICategoryCreate categoryCreate);

        ILogicResult DeleteCategory(Guid categoryId);

        ILogicResult<IEnumerable<ICategoryChartItem>> GetAllSummedCategories(Guid? supercategoryId);

        ILogicResult<ICategoryDetail> GetCategoryDetail(Guid categoryId);

        ILogicResult<IPagedResult<ICategoryListItem>> GetPagedCategories();

        ILogicResult UpdateCategory(ICategoryUpdate categoryUpdate);
    }
}