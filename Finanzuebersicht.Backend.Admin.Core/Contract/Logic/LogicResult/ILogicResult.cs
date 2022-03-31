﻿namespace Finanzuebersicht.Backend.Admin.Core.Contract.Logic.LogicResults
{
    public interface ILogicResult
    {
        LogicResultState State { get; set; }

        string Message { get; set; }

        bool IsSuccessful { get; }
    }
}