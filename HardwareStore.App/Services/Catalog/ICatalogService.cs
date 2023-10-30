﻿namespace HardwareStore.App.Services.Catalog
{
    using HardwareStore.App.Models.Product;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICatalogService
    {
        int PageSize { get; set; }

        Task<ICollection<ProductExtendedModel>> GetProducts(
            string? searchString,
            string? category,
            ICollection<int> manufacturerIds,
            ICollection<int> selectedSpecsIds,
            string sortOrder = "newest",
            int pageNumber = 1);
    }
}