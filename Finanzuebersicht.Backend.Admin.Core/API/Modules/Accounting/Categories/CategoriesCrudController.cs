using Finanzuebersicht.Backend.Admin.Core.API.Contexts.Pagination;
using Finanzuebersicht.Backend.Admin.Core.API.Security.Authorization;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.LogicResults;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.Accounting.Categories;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Tools.Pagination;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Admin.Core.API.Modules.Accounting.Categories
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
        [Pagination(FilterFields = new[] { "SuperCategoryId", "Title" }, SortFields = new[] { "Title" })]
        public ActionResult<IPagedResult<ICategoryListItem>> GetPagedCategories()
        {
            var pagedCategoriesPagedResult = this.categoriesCrudLogic.GetPagedCategories();
            return this.FromLogicResult(pagedCategoriesPagedResult);
        }

        [HttpGet]
        [Authorized]
        [Route("all-summed/supercategoryId")]
        public ActionResult<IEnumerable<ICategory>> GetSummedCategories(Guid categoryId)
        {
            var categoriesResult = this.categoriesCrudLogic.GetAllSummedCategories(categoryId);
            return this.FromLogicResult(categoriesResult);
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