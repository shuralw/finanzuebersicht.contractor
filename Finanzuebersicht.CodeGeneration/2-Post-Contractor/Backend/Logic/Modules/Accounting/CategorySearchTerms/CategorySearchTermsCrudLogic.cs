using Contract.Architecture.Backend.Common.Contract.Logic;
using Contract.Architecture.Backend.Common.Contract.Persistence;
using Contract.Architecture.Backend.Common.Logic;
using Finanzuebersicht.Backend.Generated.Contract.Logic.Modules.Accounting.CategorySearchTerms;
using Finanzuebersicht.Backend.Generated.Contract.Persistence.Modules.Accounting.Categories;
using Finanzuebersicht.Backend.Generated.Contract.Persistence.Modules.Accounting.CategorySearchTerms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;

namespace Finanzuebersicht.Backend.Generated.Logic.Modules.Accounting.CategorySearchTerms
{
    internal class CategorySearchTermsCrudLogic : ICategorySearchTermsCrudLogic
    {
        private readonly ICategorySearchTermsCrudRepository categorySearchTermsCrudRepository;
        private readonly ICategoriesCrudRepository categoriesCrudRepository;

        private readonly IGuidGenerator guidGenerator;
        private readonly ILogger<CategorySearchTermsCrudLogic> logger;

        public CategorySearchTermsCrudLogic(
            ICategorySearchTermsCrudRepository categorySearchTermsCrudRepository,
            ICategoriesCrudRepository categoriesCrudRepository,
            IGuidGenerator guidGenerator,
            ILogger<CategorySearchTermsCrudLogic> logger)
        {
            this.categorySearchTermsCrudRepository = categorySearchTermsCrudRepository;
            this.categoriesCrudRepository = categoriesCrudRepository;

            this.guidGenerator = guidGenerator;
            this.logger = logger;
        }

        public ILogicResult<Guid> CreateCategorySearchTerm(ICategorySearchTermCreate categorySearchTermCreate)
        {
            if (!this.categoriesCrudRepository.DoesCategoryExist(categorySearchTermCreate.CategoryId))
            {
                this.logger.LogDebug($"Category ({categorySearchTermCreate.CategoryId}) konnte nicht gefunden werden.");
                return LogicResult<Guid>.NotFound($"Category ({categorySearchTermCreate.CategoryId}) konnte nicht gefunden werden.");
            }

            Guid newCategorySearchTermId = this.guidGenerator.NewGuid();
            IDbCategorySearchTerm dbCategorySearchTermToCreate = CategorySearchTerm.CreateDbCategorySearchTerm(newCategorySearchTermId, categorySearchTermCreate);
            this.categorySearchTermsCrudRepository.CreateCategorySearchTerm(dbCategorySearchTermToCreate);

            this.logger.LogInformation($"CategorySearchTerm ({newCategorySearchTermId}) angelegt");
            return LogicResult<Guid>.Ok(newCategorySearchTermId);
        }

        public ILogicResult DeleteCategorySearchTerm(Guid categorySearchTermId)
        {
            if (!this.categorySearchTermsCrudRepository.DoesCategorySearchTermExist(categorySearchTermId))
            {
                this.logger.LogDebug($"CategorySearchTerm ({categorySearchTermId}) konnte nicht gefunden werden.");
                return LogicResult.NotFound($"CategorySearchTerm ({categorySearchTermId}) konnte nicht gefunden werden.");
            }

            // TODO: If relations are implemented, resolve conflict with the FOREIGN KEY constraint
            try
            {
                this.categorySearchTermsCrudRepository.DeleteCategorySearchTerm(categorySearchTermId);
            }
            catch (DbUpdateException)
            {
                this.logger.LogDebug($"CategorySearchTerm ({categorySearchTermId}) konnte nicht gelöscht werden.");
                return LogicResult.Conflict($"CategorySearchTerm ({categorySearchTermId}) konnte nicht gelöscht werden.");
            }

            this.logger.LogInformation($"CategorySearchTerm ({categorySearchTermId}) gelöscht");
            return LogicResult.Ok();
        }

        public ILogicResult<ICategorySearchTermDetail> GetCategorySearchTermDetail(Guid categorySearchTermId)
        {
            IDbCategorySearchTermDetail dbCategorySearchTermDetail = this.categorySearchTermsCrudRepository.GetCategorySearchTermDetail(categorySearchTermId);
            if (dbCategorySearchTermDetail == null)
            {
                this.logger.LogDebug($"CategorySearchTerm ({categorySearchTermId}) konnte nicht gefunden werden.");
                return LogicResult<ICategorySearchTermDetail>.NotFound($"CategorySearchTerm ({categorySearchTermId}) konnte nicht gefunden werden.");
            }

            this.logger.LogDebug($"Details für CategorySearchTerm ({categorySearchTermId}) wurde geladen");
            return LogicResult<ICategorySearchTermDetail>.Ok(CategorySearchTermDetail.FromDbCategorySearchTermDetail(dbCategorySearchTermDetail));
        }

        public ILogicResult<IPagedResult<ICategorySearchTermListItem>> GetPagedCategorySearchTerms()
        {
            IDbPagedResult<IDbCategorySearchTermListItem> dbCategorySearchTermsPagedResult =
                this.categorySearchTermsCrudRepository.GetPagedCategorySearchTerms();

            IPagedResult<ICategorySearchTermListItem> categorySearchTermsPagedResult =
                PagedResult.FromDbPagedResult(
                    dbCategorySearchTermsPagedResult,
                    (dbCategorySearchTerm) => CategorySearchTermListItem.FromDbCategorySearchTermListItem(dbCategorySearchTerm));

            this.logger.LogDebug("CategorySearchTerms wurden geladen");
            return LogicResult<IPagedResult<ICategorySearchTermListItem>>.Ok(categorySearchTermsPagedResult);
        }

        public ILogicResult UpdateCategorySearchTerm(ICategorySearchTermUpdate categorySearchTermUpdate)
        {
            IDbCategorySearchTerm dbCategorySearchTermToUpdate = this.categorySearchTermsCrudRepository.GetCategorySearchTerm(categorySearchTermUpdate.Id);
            if (dbCategorySearchTermToUpdate == null)
            {
                this.logger.LogDebug($"CategorySearchTerm ({categorySearchTermUpdate.Id}) konnte nicht gefunden werden.");
                return LogicResult.NotFound($"CategorySearchTerm ({categorySearchTermUpdate.Id}) konnte nicht gefunden werden.");
            }

            if (!this.categoriesCrudRepository.DoesCategoryExist(categorySearchTermUpdate.CategoryId))
            {
                this.logger.LogDebug($"Category ({categorySearchTermUpdate.CategoryId}) konnte nicht gefunden werden.");
                return LogicResult.NotFound($"Category ({categorySearchTermUpdate.CategoryId}) konnte nicht gefunden werden.");
            }

            this.categorySearchTermsCrudRepository.UpdateCategorySearchTerm(DbCategorySearchTermUpdate
                .FromCategorySearchTermUpdate(categorySearchTermUpdate));

            this.logger.LogInformation($"CategorySearchTerm ({categorySearchTermUpdate.Id}) aktualisiert");
            return LogicResult.Ok();
        }
    }
}