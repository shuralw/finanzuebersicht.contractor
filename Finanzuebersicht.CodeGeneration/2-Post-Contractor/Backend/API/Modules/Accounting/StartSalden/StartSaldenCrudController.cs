using Contract.Architecture.Backend.Common.API;
using Contract.Architecture.Backend.Common.Contract.Logic;
using Finanzuebersicht.Backend.Generated.API.Security.Authorization;
using Finanzuebersicht.Backend.Generated.Contract.Logic.Modules.Accounting.StartSalden;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Generated.API.Modules.Accounting.StartSalden
{
    [ApiController]
    [Route("api/accounting/start-salden")]
    public class StartSaldenCrudController : ControllerBase
    {
        private readonly IStartSaldenCrudLogic startSaldenCrudLogic;

        public StartSaldenCrudController(IStartSaldenCrudLogic startSaldenCrudLogic)
        {
            this.startSaldenCrudLogic = startSaldenCrudLogic;
        }

        [HttpGet]
        [Authorized]
        [Pagination(FilterFields = new[] { "Bezeichnung" }, SortFields = new[] { "Bezeichnung" })]
        public ActionResult<IPagedResult<IStartSaldoListItem>> GetPagedStartSalden()
        {
            var pagedStartSaldenPagedResult = this.startSaldenCrudLogic.GetPagedStartSalden();
            return this.FromLogicResult(pagedStartSaldenPagedResult);
        }

        [HttpGet]
        [Authorized]
        [Route("{startSaldoId}")]
        public ActionResult<IStartSaldoDetail> GetStartSaldoDetail(Guid startSaldoId)
        {
            var getStartSaldoDetailResult = this.startSaldenCrudLogic.GetStartSaldoDetail(startSaldoId);
            return this.FromLogicResult(getStartSaldoDetailResult);
        }

        [HttpPost]
        [Authorized]
        public ActionResult<DataBody<Guid>> CreateStartSaldo([FromBody] StartSaldoCreate startSaldoCreate)
        {
            ILogicResult<Guid> createStartSaldoResult = this.startSaldenCrudLogic.CreateStartSaldo(startSaldoCreate);
            if (!createStartSaldoResult.IsSuccessful)
            {
                return this.FromLogicResult(createStartSaldoResult);
            }

            return this.Ok(new DataBody<Guid>(createStartSaldoResult.Data));
        }

        [HttpPut]
        [Authorized]
        public ActionResult UpdateStartSaldo([FromBody] StartSaldoUpdate startSaldoUpdate)
        {
            ILogicResult updateStartSaldoResult = this.startSaldenCrudLogic.UpdateStartSaldo(startSaldoUpdate);
            return this.FromLogicResult(updateStartSaldoResult);
        }

        [HttpDelete]
        [Authorized]
        [Route("{startSaldoId}")]
        public ActionResult DeleteStartSaldo(Guid startSaldoId)
        {
            ILogicResult deleteStartSaldoResult = this.startSaldenCrudLogic.DeleteStartSaldo(startSaldoId);
            return this.FromLogicResult(deleteStartSaldoResult);
        }
    }
}