using System;

namespace Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Tools.Time
{
    public interface IDateTimeProvider
    {
        DateTime Now();
    }
}