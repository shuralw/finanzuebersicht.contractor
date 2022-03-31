using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.LogicResults;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.Accounting.Categories;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.Accounting.CategorySearchTerms;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Tools.Identifier;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Tools.Pagination;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.Accounting.Categories;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.Accounting.CategorySearchTerms;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Tools.Pagination;
using Finanzuebersicht.Backend.Admin.Core.Logic.LogicResults;
using Finanzuebersicht.Backend.Admin.Core.Logic.Modules.Accounting.Categories;
using Finanzuebersicht.Backend.Admin.Core.Logic.Tools.Pagination;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Modules.Accounting.CategorySearchTerms
{
    internal class CategoryIdentifyingLogic : ICategoryIdentifyingLogic
    {
        private readonly ICategorySearchTermsCrudRepository categorySearchTermsCrudRepository;
        private readonly ICategoriesCrudRepository categoriesCrudRepository;

        private readonly ILogger<CategorySearchTermsCrudLogic> logger;

        public CategoryIdentifyingLogic(
            ICategorySearchTermsCrudRepository categorySearchTermsCrudRepository,
            ICategoriesCrudRepository categoriesCrudRepository,
            ILogger<CategorySearchTermsCrudLogic> logger)
        {
            this.categorySearchTermsCrudRepository = categorySearchTermsCrudRepository;
            this.categoriesCrudRepository = categoriesCrudRepository;

            this.logger = logger;
        }

        public IDbCategory TryGetDbCategory(List<string> zuDurchsuchendePropertiesEinesAccountingEntries)
        {
            zuDurchsuchendePropertiesEinesAccountingEntries = zuDurchsuchendePropertiesEinesAccountingEntries
                .Select(property => property.ToLower())
                .ToList();

            IEnumerable<IDbCategorySearchTerm> searchTerms = this.categorySearchTermsCrudRepository.GetAllCategorySearchTerms();

            IDbCategorySearchTerm searchTerm = searchTerms.FirstOrDefault(term => zuDurchsuchendePropertiesEinesAccountingEntries
                .Any(property => property.Contains(term.Term.ToLower())));

            return searchTerm == null ? null : this.categoriesCrudRepository.GetCategory(searchTerm.CategoryId.Value);
        }
    }
}