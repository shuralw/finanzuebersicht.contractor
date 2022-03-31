using Finanzuebersicht.Backend.Generated.Contract.Logic.Modules.Accounting.StartSalden;
using System;
using System.ComponentModel.DataAnnotations;

namespace Finanzuebersicht.Backend.Generated.API.Modules.Accounting.StartSalden
{
    public class StartSaldoCreate : IStartSaldoCreate
    {
        [Required]
        public double Betrag { get; set; }

        [Required]
        public DateTime DatumAm { get; set; }
    }
}