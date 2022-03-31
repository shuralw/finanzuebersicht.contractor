using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.Accounting.Categories;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.Accounting.CategorySearchTerms
{
    public interface ICategoryIdentifyingLogic
    {
        IDbCategory TryGetDbCategory(List<string> zuDurchsuchendePropertiesEinesAccountingEntries);
    }
}