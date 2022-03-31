using Contract.Architecture.Backend.Common.API;
using Contract.Architecture.Backend.Common.Contract.Logic;
using Finanzuebersicht.Backend.Generated.API.Security.Authorization;
using Finanzuebersicht.Backend.Generated.Contract.Logic.Modules.Accounting.Categories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Generated.API.Modules.Accounting.Categories
{
    [ApiController]
    [Route("api/accounting/categories")]
    public class CategoriesCrudController : ControllerBase
    {
        private readonly ICategoriesCrudLogic categoriesCrudLogic;

        public CategoriesCrudController(ICategoriesCrudLogic categoriesCrudLogic)
        {
            this.categoriesCrudLogic = categoriesCrudLogic;
        }

        [HttpGet]
        [Authorized]
        [Pagination(FilterFields = new[] { "SuperCategoryId", "Bezeichnung" }, SortFields = new[] { "Bezeichnung" })]
        public ActionResult<IPagedResult<ICategoryListItem>> GetPagedCategories()
        {
            var pagedCategoriesPagedResult = this.categoriesCrudLogic.GetPagedCategories();
            return this.FromLogicResult(pagedCategoriesPagedResult);
        }

        [HttpGet]
        [Authorized]
        [Route("{categoryId}")]
        public ActionResult<ICategoryDetail> GetCategoryDetail(Guid categoryId)
        {
            var getCategoryDetailResult = this.categoriesCrudLogic.GetCategoryDetail(categoryId);
            return this.FromLogicResult(getCategoryDetailResult);
        }

        [HttpPost]
        [Authorized]
        public ActionResult<DataBody<Guid>> CreateCategory([FromBody] CategoryCreate categoryCreate)
        {
            ILogicResult<Guid> createCategoryResult = this.categoriesCrudLogic.CreateCategory(categoryCreate);
            if (!createCategoryResult.IsSuccessful)
            {
                return this.FromLogicResult(createCategoryResult);
            }

            return this.Ok(new DataBody<Guid>(createCategoryResult.Data));
        }

        [HttpPut]
        [Authorized]
        public ActionResult UpdateCategory([FromBody] CategoryUpdate categoryUpdate)
        {
            ILogicResult updateCategoryResult = this.categoriesCrudLogic.UpdateCategory(categoryUpdate);
            return this.FromLogicResult(updateCategoryResult);
        }

        [HttpDelete]
        [Authorized]
        [Route("{categoryId}")]
        public ActionResult DeleteCategory(Guid categoryId)
        {
            ILogicResult deleteCategoryResult = this.categoriesCrudLogic.DeleteCategory(categoryId);
            return this.FromLogicResult(deleteCategoryResult);
        }
    }
}