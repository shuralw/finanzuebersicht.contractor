using Finanzuebersicht.Backend.Generated.Contract.Logic.Modules.Accounting.StartSalden;
using System;
using System.ComponentModel.DataAnnotations;

namespace Finanzuebersicht.Backend.Generated.API.Modules.Accounting.StartSalden
{
    public class StartSaldoUpdate : IStartSaldoUpdate
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public double Betrag { get; set; }

        [Required]
        public DateTime DatumAm { get; set; }
    }
}