using Finanzuebersicht.Backend.Admin.Core.API.Contexts.Pagination;
using Finanzuebersicht.Backend.Admin.Core.API.Security.Authorization;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.LogicResults;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.Accounting.CategorySearchTerms;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Tools.Pagination;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Admin.Core.API.Modules.Accounting.CategorySearchTerms
{
    [ApiController]
    [Route("api/accounting/category-search-terms")]
    public class CategorySearchTermsCrudController : ControllerBase
    {
        private readonly ICategorySearchTermsCrudLogic categorySearchTermsCrudLogic;

        public CategorySearchTermsCrudController(ICategorySearchTermsCrudLogic categorySearchTermsCrudLogic)
        {
            this.categorySearchTermsCrudLogic = categorySearchTermsCrudLogic;
        }

        [HttpGet]
        [Authorized]
        [Pagination(FilterFields = new[] { "CategoryId", "Bezeichnung" }, SortFields = new[] { "Bezeichnung" })]
        public ActionResult<IPagedResult<ICategorySearchTermListItem>> GetPagedCategorySearchTerms()
        {
            var pagedCategorySearchTermsPagedResult = this.categorySearchTermsCrudLogic.GetPagedCategorySearchTerms();
            return this.FromLogicResult(pagedCategorySearchTermsPagedResult);
        }

        [HttpGet]
        [Authorized]
        [Route("{categorySearchTermId}")]
        public ActionResult<ICategorySearchTermDetail> GetCategorySearchTermDetail(Guid categorySearchTermId)
        {
            var getCategorySearchTermDetailResult = this.categorySearchTermsCrudLogic.GetCategorySearchTermDetail(categorySearchTermId);
            return this.FromLogicResult(getCategorySearchTermDetailResult);
        }

        [HttpPost]
        [Authorized]
        public ActionResult<DataBody<Guid>> CreateCategorySearchTerm([FromBody] CategorySearchTermCreate categorySearchTermCreate)
        {
            ILogicResult<Guid> createCategorySearchTermResult = this.categorySearchTermsCrudLogic.CreateCategorySearchTerm(categorySearchTermCreate);
            if (!createCategorySearchTermResult.IsSuccessful)
            {
                return this.FromLogicResult(createCategorySearchTermResult);
            }

            return this.Ok(new DataBody<Guid>(createCategorySearchTermResult.Data));
        }

        [HttpPut]
        [Authorized]
        public ActionResult UpdateCategorySearchTerm([FromBody] CategorySearchTermUpdate categorySearchTermUpdate)
        {
            ILogicResult updateCategorySearchTermResult = this.categorySearchTermsCrudLogic.UpdateCategorySearchTerm(categorySearchTermUpdate);
            return this.FromLogicResult(updateCategorySearchTermResult);
        }

        [HttpDelete]
        [Authorized]
        [Route("{categorySearchTermId}")]
        public ActionResult DeleteCategorySearchTerm(Guid categorySearchTermId)
        {
            ILogicResult deleteCategorySearchTermResult = this.categorySearchTermsCrudLogic.DeleteCategorySearchTerm(categorySearchTermId);
            return this.FromLogicResult(deleteCategorySearchTermResult);
        }
    }
}