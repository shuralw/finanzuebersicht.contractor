using Contract.Architecture.Backend.Common.Contract.Logic;
using System;

namespace Finanzuebersicht.Backend.Generated.Contract.Logic.Modules.Accounting.CategorySearchTerms
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