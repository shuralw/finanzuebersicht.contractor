using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.LogicResults;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Tools.Pagination;
using System;

namespace Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.Accounting.CategorySearchTerms
{
    public interface ICategorySearchTermsCrudLogic
    {
        ILogicResult<Guid> CreateCategorySearchTerm(ICategorySearchTermCreate categorySearchTermCreate);

        ILogicResult DeleteCategorySearchTerm(Guid categorySearchTermId);

        ILogicResult<ICategorySearchTermDetail> GetCategorySearchTermDetail(Guid categorySearchTermId);

        ILogicResult<IPagedResult<ICategorySearchTermListItem>> GetPagedCategorySearchTerms();

        ILogicResult UpdateCategorySearchTerm(ICategorySearchTermUpdate categorySearchTermUpdate);
    }
}