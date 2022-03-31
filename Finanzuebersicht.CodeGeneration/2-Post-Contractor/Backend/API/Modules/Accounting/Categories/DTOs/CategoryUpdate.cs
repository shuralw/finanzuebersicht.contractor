using Finanzuebersicht.Backend.Generated.Contract.Logic.Modules.Accounting.Categories;
using System;
using System.ComponentModel.DataAnnotations;

namespace Finanzuebersicht.Backend.Generated.API.Modules.Accounting.Categories
{
    public class CategoryUpdate : ICategoryUpdate
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public Guid SuperCategoryId { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [Required]
        [StringLength(30)]
        public string Color { get; set; }
    }
}