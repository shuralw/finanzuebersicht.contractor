using Finanzuebersicht.Backend.Generated.Contract.Logic.Modules.Accounting.CategorySearchTerms;
using System;
using System.ComponentModel.DataAnnotations;

namespace Finanzuebersicht.Backend.Generated.API.Modules.Accounting.CategorySearchTerms
{
    public class CategorySearchTermUpdate : ICategorySearchTermUpdate
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public Guid CategoryId { get; set; }

        [Required]
        [StringLength(100)]
        public string Term { get; set; }
    }
}