using CsvHelper;
using CsvHelper.Configuration;
using Finanzuebersicht.Backend.Admin.Core.API.Contexts.Pagination;
using Finanzuebersicht.Backend.Admin.Core.API.Security.Authorization;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.LogicResults;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.Accounting.AccountingEntries;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Tools.Pagination;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
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

        [HttpPost, DisableRequestSizeLimit]
        //[]
        [Route("multiple")]
        //public async Task<ActionResult> Upload([FromForm] IFormFile file)
        public async Task<ActionResult<DataBody<Guid>>> Upload([FromForm] IFormFile file)
        {
            var BodyReader = this.Request.BodyReader;
            var Body = this.Request.Body;
            //var file = this.Request.Form.Files[0];
            if (file.Length > 0)
            {
                var csvConfiguration = new CsvConfiguration(new CultureInfo("de-DE"));
                csvConfiguration.Delimiter = ";";
                csvConfiguration.HasHeaderRecord = true;

                var x = await this.ReadFormFileAsync(file);
                IEnumerable<AccountingEntryCreate> accountingEntryCreates;

                TextReader textReader = new StreamReader(file.OpenReadStream());
                using (var csv = new CsvReader(textReader, csvConfiguration))
                {
                    csv.Context.RegisterClassMap<FooMap>();
                    accountingEntryCreates = csv.GetRecords<AccountingEntryCreate>().ToList();
                }

                ILogicResult<Guid[]> createAccountingEntryResult = this.accountingEntriesCrudLogic.CreateAccountingEntries(accountingEntryCreates);

                if (!createAccountingEntryResult.IsSuccessful)
                {
                    return this.FromLogicResult(createAccountingEntryResult);
                }

                return this.Ok(new DataBody<Guid[]>(createAccountingEntryResult.Data));
            }
            else
            {
                return this.BadRequest();
            }
        }

        public sealed class FooMap : ClassMap<AccountingEntryCreate>
        {
            public FooMap()
            {
                // Map(m => m.CategoryId).Name("", "CategoryId");
                this.Map(m => m.Auftragskonto).Name("Auftragskonto", "Auftragskonto");
                this.Map(m => m.Buchungsdatum).Name("Buchungstag", "Buchungsdatum");
                this.Map(m => m.ValutaDatum).Name("Valutadatum", "ValutaDatum");
                this.Map(m => m.Buchungstext).Name("Buchungstext", "Buchungstext");
                this.Map(m => m.Verwendungszweck).Name("Verwendungszweck", "Verwendungszweck");
                this.Map(m => m.GlaeubigerId).Name("Glaeubiger ID", "GlaeubigerId");
                this.Map(m => m.Mandatsreferenz).Name("Mandatsreferenz", "Mandatsreferenz");

                // this.Map(m => m.KundenReferenz).Name("Kundenreferenz (End-to-End)", "KundenReferenz   ");
                this.Map(m => m.Sammlerreferenz).Name("Sammlerreferenz", "Sammlerreferenz");
                this.Map(m => m.LastschriftUrsprungsbetrag).Name("Lastschrift Ursprungsbetrag", "LastschriftUrsprungsbetrag");
                this.Map(m => m.AuslagenersatzRuecklastschrift).Name("Auslagenersatz Ruecklastschrift", "AuslagenersatzRuecklastschrift");
                this.Map(m => m.Beguenstigter).Name("Beguenstigter/Zahlungspflichtiger", "Beguenstigter");
                this.Map(m => m.IBAN).Name("Kontonummer/IBAN", "IBAN");
                this.Map(m => m.BIC).Name("BIC (SWIFT-Code)", "BIC");
                this.Map(m => m.Betrag).Name("Betrag", "Betrag");
                this.Map(m => m.Waehrung).Name("Waehrung", "Waehrung");
                this.Map(m => m.Info).Name("Info", "Info");
            }
        }

        public async Task<string> ReadFormFileAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return await Task.FromResult((string)null);
            }

            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                return await reader.ReadToEndAsync();
            }
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