using Finanzuebersicht.Backend.Generated.Contract.Logic.Modules.Accounting.Categories;
using System;
using System.ComponentModel.DataAnnotations;

namespace Finanzuebersicht.Backend.Generated.API.Modules.Accounting.Categories
{
    public class CategoryCreate : ICategoryCreate
    {
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