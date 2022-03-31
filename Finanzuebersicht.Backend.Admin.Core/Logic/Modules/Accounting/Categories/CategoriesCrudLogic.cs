using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.LogicResults;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.Accounting.Categories;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.Accounting.CategorySearchTerms;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Tools.Identifier;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Tools.Pagination;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.Accounting.AccountingEntries;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.Accounting.Categories;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Tools.Pagination;
using Finanzuebersicht.Backend.Admin.Core.Logic.LogicResults;
using Finanzuebersicht.Backend.Admin.Core.Logic.Tools.Pagination;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Modules.Accounting.Categories
{
    internal class CategoriesCrudLogic : ICategoriesCrudLogic
    {
        private readonly ICategoriesCrudRepository categoriesCrudRepository;
        private readonly IAccountingEntriesCrudRepository accountingEntriesCrudRepository;
        private readonly ICategoryIdentifyingLogic categoryIdentifyingLogic;

        private readonly IGuidGenerator guidGenerator;
        private readonly ILogger<CategoriesCrudLogic> logger;

        public CategoriesCrudLogic(
            ICategoriesCrudRepository categoriesCrudRepository,
            IAccountingEntriesCrudRepository accountingEntriesCrudRepository,
            ICategoryIdentifyingLogic categoryIdentifyingLogic,
            IGuidGenerator guidGenerator,
            ILogger<CategoriesCrudLogic> logger)
        {
            this.categoriesCrudRepository = categoriesCrudRepository;
            this.accountingEntriesCrudRepository = accountingEntriesCrudRepository;
            this.categoryIdentifyingLogic = categoryIdentifyingLogic;

            this.guidGenerator = guidGenerator;
            this.logger = logger;
        }

        public ILogicResult<Guid> CreateCategory(ICategoryCreate categoryCreate)
        {
            if (categoryCreate.SuperCategoryId.HasValue && !this.categoriesCrudRepository.DoesCategoryExist(categoryCreate.SuperCategoryId.Value))
            {
                this.logger.LogDebug("SuperCategory konnte nicht gefunden werden.");
                return LogicResult<Guid>.NotFound("SuperCategory konnte nicht gefunden werden.");
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

        public ILogicResult<IEnumerable<ICategoryChartItem>> GetAllSummedCategories()
        {
            IEnumerable<IDbAccountingEntryChartItem> dbAccountingEntriesResult =
                this.accountingEntriesCrudRepository.GetAllAccountingEntries();

            dbAccountingEntriesResult = this.GetAccountingEntriesWithIdentifiedCategory(dbAccountingEntriesResult);

            IEnumerable<ICategoryChartItem> summedCategories = dbAccountingEntriesResult
                .Where(accountingEntry => accountingEntry.Category != null)
                .GroupBy(accountingEntry => accountingEntry.Category.Id)
                .Select(accountingEntry => this.GetSummedCategory(accountingEntry));
                //.Where(category => category.Summe < 0);

            this.logger.LogDebug("Categories wurden geladen");
            return LogicResult<IEnumerable<ICategoryChartItem>>.Ok(summedCategories);
        }

        private IEnumerable<IDbAccountingEntryChartItem> GetAccountingEntriesWithIdentifiedCategory(IEnumerable<IDbAccountingEntryChartItem> dbAccountingEntriesResult)
        {
            List<IDbAccountingEntryChartItem> result = new List<IDbAccountingEntryChartItem>();

            foreach (IDbAccountingEntryChartItem accountingEntry in dbAccountingEntriesResult)
            {
                List<string> zuDurchsuchendeProperties = new List<string>()
                    {
                        accountingEntry.Verwendungszweck,
                        accountingEntry.Beguenstigter,
                        accountingEntry.Buchungstext
                    };

                accountingEntry.Category = accountingEntry.Category != null
                    ? accountingEntry.Category
                    : this.categoryIdentifyingLogic.TryGetDbCategory(zuDurchsuchendeProperties);

                result.Add(accountingEntry);
            }

            return result;
        }

        public ILogicResult UpdateCategory(ICategoryUpdate categoryUpdate)
        {
            IDbCategory dbCategoryToUpdate = this.categoriesCrudRepository.GetCategory(categoryUpdate.Id);
            if (dbCategoryToUpdate == null)
            {
                this.logger.LogDebug($"Category ({categoryUpdate.Id}) konnte nicht gefunden werden.");
                return LogicResult.NotFound($"Category ({categoryUpdate.Id}) konnte nicht gefunden werden.");
            }

            if (categoryUpdate.SuperCategoryId.HasValue && !this.categoriesCrudRepository.DoesCategoryExist(categoryUpdate.SuperCategoryId.Value))
            {
                this.logger.LogDebug("SuperCategory konnte nicht gefunden werden.");
                return LogicResult.NotFound("SuperCategory konnte nicht gefunden werden.");
            }

            this.categoriesCrudRepository.UpdateCategory(DbCategoryUpdate
                .FromCategoryUpdate(categoryUpdate));

            this.logger.LogInformation($"Category ({categoryUpdate.Id}) aktualisiert");
            return LogicResult.Ok();
        }

        private ICategoryChartItem GetSummedCategory(IGrouping<Guid, IDbAccountingEntryChartItem> accountinEntryGroup)
        {
            ICategoryChartItem category = CategoryChartItem.FromDbCategoryDetail(this.categoriesCrudRepository.GetCategoryDetail(accountinEntryGroup.First().Category.Id));
            category.Summe = accountinEntryGroup.Sum(accountingEntry => accountingEntry.Betrag) ?? 0;
            return category;
        }
    }
}