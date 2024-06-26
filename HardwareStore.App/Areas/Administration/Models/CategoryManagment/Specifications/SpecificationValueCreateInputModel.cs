﻿namespace HardwareStore.App.Areas.Administration.Models.CategoryManagment.Specifications
{
    using System.ComponentModel.DataAnnotations;

    public class SpecificationValueCreateInputModel
    {
        public int ValueId { get; set; }

        public int? CategoryId { get; set; }

        public int SpecificationId { get; set; }

        [StringLength(maximumLength: 100, MinimumLength = 1, ErrorMessage = "{0} must be {2}-{1} characters long")]
        [Required]
        public string Value { get; set; }

        [StringLength(maximumLength: 20, MinimumLength = 1)]
        public string? Metric { get; set; }
    }
}
