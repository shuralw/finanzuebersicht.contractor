using Contract.Architecture.Backend.Common.Contract.Logic;
using Contract.Architecture.Backend.Common.Contract.Persistence;
using Contract.Architecture.Backend.Common.Logic;
using Finanzuebersicht.Backend.Generated.Contract.Logic.Modules.Accounting.Categories;
using Finanzuebersicht.Backend.Generated.Contract.Persistence.Modules.Accounting.Categories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;

namespace Finanzuebersicht.Backend.Generated.Logic.Modules.Accounting.Categories
{
    internal class CategoriesCrudLogic : ICategoriesCrudLogic
    {
        private readonly ICategoriesCrudRepository categoriesCrudRepository;

        private readonly IGuidGenerator guidGenerator;
        private readonly ILogger<CategoriesCrudLogic> logger;

        public CategoriesCrudLogic(
            ICategoriesCrudRepository categoriesCrudRepository,
            IGuidGenerator guidGenerator,
            ILogger<CategoriesCrudLogic> logger)
        {
            this.categoriesCrudRepository = categoriesCrudRepository;

            this.guidGenerator = guidGenerator;
            this.logger = logger;
        }

        public ILogicResult<Guid> CreateCategory(ICategoryCreate categoryCreate)
        {
            if (!this.categoriesCrudRepository.DoesCategoryExist(categoryCreate.SuperCategoryId))
            {
                this.logger.LogDebug($"SuperCategory ({categoryCreate.SuperCategoryId}) konnte nicht gefunden werden.");
                return LogicResult<Guid>.NotFound($"SuperCategory ({categoryCreate.SuperCategoryId}) konnte nicht gefunden werden.");
            }

            Guid newCategoryId = this.guidGenerator.NewGuid();
            IDbCategory dbCategoryToCreate = Category.CreateDbCategory(newCategoryId, categoryCreate);
            this.categoriesCrudRepository.CreateCategory(dbCategoryToCreate);

            this.logger.LogInformation($"Category ({newCategoryId}) angelegt");
            return LogicResult<Guid>.Ok(newCategoryId);
        }

        public ILogicResult DeleteCategory(Guid categoryId)
        {
            if (!this.categoriesCrudRepository.DoesCategoryExist(categoryId))
            {
                this.logger.LogDebug($"Category ({categoryId}) konnte nicht gefunden werden.");
                return LogicResult.NotFound($"Category ({categoryId}) konnte nicht gefunden werden.");
            }

            // TODO: If relations are implemented, resolve conflict with the FOREIGN KEY constraint
            try
            {
                this.categoriesCrudRepository.DeleteCategory(categoryId);
            }
            catch (DbUpdateException)
            {
                this.logger.LogDebug($"Category ({categoryId}) konnte nicht gelöscht werden.");
                return LogicResult.Conflict($"Category ({categoryId}) konnte nicht gelöscht werden.");
            }

            this.logger.LogInformation($"Category ({categoryId}) gelöscht");
            return LogicResult.Ok();
        }

        public ILogicResult<ICategoryDetail> GetCategoryDetail(Guid categoryId)
        {
            IDbCategoryDetail dbCategoryDetail = this.categoriesCrudRepository.GetCategoryDetail(categoryId);
            if (dbCategoryDetail == null)
            {
                this.logger.LogDebug($"Category ({categoryId}) konnte nicht gefunden werden.");
                return LogicResult<ICategoryDetail>.NotFound($"Category ({categoryId}) konnte nicht gefunden werden.");
            }

            this.logger.LogDebug($"Details für Category ({categoryId}) wurde geladen");
            return LogicResult<ICategoryDetail>.Ok(CategoryDetail.FromDbCategoryDetail(dbCategoryDetail));
        }

        public ILogicResult<IPagedResult<ICategoryListItem>> GetPagedCategories()
        {
            IDbPagedResult<IDbCategoryListItem> dbCategoriesPagedResult =
                this.categoriesCrudRepository.GetPagedCategories();

            IPagedResult<ICategoryListItem> categoriesPagedResult =
                PagedResult.FromDbPagedResult(
                    dbCategoriesPagedResult,
                    (dbCategory) => CategoryListItem.FromDbCategoryListItem(dbCategory));

            this.logger.LogDebug("Categories wurden geladen");
            return LogicResult<IPagedResult<ICategoryListItem>>.Ok(categoriesPagedResult);
        }

        public ILogicResult UpdateCategory(ICategoryUpdate categoryUpdate)
        {
            IDbCategory dbCategoryToUpdate = this.categoriesCrudRepository.GetCategory(categoryUpdate.Id);
            if (dbCategoryToUpdate == null)
            {
                this.logger.LogDebug($"Category ({categoryUpdate.Id}) konnte nicht gefunden werden.");
                return LogicResult.NotFound($"Category ({categoryUpdate.Id}) konnte nicht gefunden werden.");
            }

            if (!this.categoriesCrudRepository.DoesCategoryExist(categoryUpdate.SuperCategoryId))
            {
                this.logger.LogDebug($"SuperCategory ({categoryUpdate.SuperCategoryId}) konnte nicht gefunden werden.");
                return LogicResult.NotFound($"SuperCategory ({categoryUpdate.SuperCategoryId}) konnte nicht gefunden werden.");
            }

            this.categoriesCrudRepository.UpdateCategory(DbCategoryUpdate
                .FromCategoryUpdate(categoryUpdate));

            this.logger.LogInformation($"Category ({categoryUpdate.Id}) aktualisiert");
            return LogicResult.Ok();
        }
    }
}