using Finanzuebersicht.Backend.Admin.Core.API.Contexts.Pagination;
using Finanzuebersicht.Backend.Admin.Core.API.Security.Authorization;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.LogicResults;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.Accounting.AccountingEntries;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Tools.Pagination;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Finanzuebersicht.Backend.Admin.Core.API.Modules.Accounting.AccountingEntries
{
    [ApiController]
    [Route("api/accounting/accounting-entries")]
    public class AccountingEntriesCrudController : ControllerBase
    {
        private readonly IAccountingEntriesCrudLogic accountingEntriesCrudLogic;

        public AccountingEntriesCrudController(IAccountingEntriesCrudLogic accountingEntriesCrudLogic)
        {
            this.accountingEntriesCrudLogic = accountingEntriesCrudLogic;
        }

        [HttpGet]
        [Authorized]
        [Pagination(FilterFields = new[] { "CategoryId", "Bezeichnung" }, SortFields = new[] { "Bezeichnung" })]
        public ActionResult<IPagedResult<IAccountingEntryListItem>> GetPagedAccountingEntries()
        {
            var pagedAccountingEntriesPagedResult = this.accountingEntriesCrudLogic.GetPagedAccountingEntries();
            return this.FromLogicResult(pagedAccountingEntriesPagedResult);
        }

        [HttpGet]
        [Authorized]
        [Route("{accountingEntryId}")]
        public ActionResult<IAccountingEntryDetail> GetAccountingEntryDetail(Guid accountingEntryId)
        {
            var getAccountingEntryDetailResult = this.accountingEntriesCrudLogic.GetAccountingEntryDetail(accountingEntryId);
            return this.FromLogicResult(getAccountingEntryDetailResult);
        }

        [HttpPost]
        public ActionResult<DataBody<Guid>> CreateAccountingEntry([FromBody] AccountingEntryCreate accountingEntryCreate)
        {
            ILogicResult<Guid> createAccountingEntryResult = this.accountingEntriesCrudLogic.CreateAccountingEntry(accountingEntryCreate);
            if (!createAccountingEntryResult.IsSuccessful)
            {
                return this.FromLogicResult(createAccountingEntryResult);
            }

            return this.Ok(new DataBody<Guid>(createAccountingEntryResult.Data));
        }

        [HttpPost]
        [Route("multiple")]
        public ActionResult<DataBody<Guid[]>> CreateAccountingEntriesFromCsv([FromBody] AccountingEntryCreate[] accountingEntryCreates)
        {

            ILogicResult<Guid[]> createAccountingEntriesResult = this.accountingEntriesCrudLogic.CreateAccountingEntries(accountingEntryCreates);
            if (!createAccountingEntriesResult.IsSuccessful)
            {
                return this.FromLogicResult(createAccountingEntriesResult);
            }

            return this.Ok(new DataBody<Guid[]>(createAccountingEntriesResult.Data));
        }

        [HttpPut]
        [Authorized]
        public ActionResult UpdateAccountingEntry([FromBody] AccountingEntryUpdate accountingEntryUpdate)
        {
            ILogicResult updateAccountingEntryResult = this.accountingEntriesCrudLogic.UpdateAccountingEntry(accountingEntryUpdate);
            return this.FromLogicResult(updateAccountingEntryResult);
        }

        [HttpDelete]
        [Authorized]
        [Route("{accountingEntryId}")]
        public ActionResult DeleteAccountingEntry(Guid accountingEntryId)
        {
            ILogicResult deleteAccountingEntryResult = this.accountingEntriesCrudLogic.DeleteAccountingEntry(accountingEntryId);
            return this.FromLogicResult(deleteAccountingEntryResult);
        }
    }
}