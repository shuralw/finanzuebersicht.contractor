using Finanzuebersicht.Backend.Admin.Core.API.Contexts.Pagination;
using Finanzuebersicht.Backend.Admin.Core.API.Security.Authorization;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.LogicResults;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.Accounting.AccountingEntries;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Tools.Pagination;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Admin.Core.API.Modules.Accounting.Saldos
{
    [ApiController]
    [Route("api/accounting/salden")]
    public class SaldenController : ControllerBase
    {
        private readonly ISaldenLogic saldenLogic;

        public SaldenController(ISaldenLogic saldenLogic)
        {
            this.saldenLogic = saldenLogic;
        }

        [HttpGet]
        [Authorized]
        public ActionResult<IEnumerable<IAccountingEntryListItem>> GetPagedSalden([FromQuery] string fromDate, [FromQuery] string toDate)
        {
            var pagedAccountingEntriesPagedResult = this.saldenLogic.GetBuchungssummeAnTagen(DateTime.Parse(fromDate), DateTime.Parse(toDate));
            return this.FromLogicResult(pagedAccountingEntriesPagedResult);
        }
    }
}