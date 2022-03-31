using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Tools.Time;
using System;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Tools.Time
{
    internal class DateTimeProvider : IDateTimeProvider
    {
        public DateTime Now()
        {
            return DateTime.Now;
        }
    }
}