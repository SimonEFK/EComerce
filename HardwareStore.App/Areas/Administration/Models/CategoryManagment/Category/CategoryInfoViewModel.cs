﻿namespace HardwareStore.App.Areas.Administration.Models.CategoryManagment.Category
{
    using HardwareStore.App.Areas.Administration.Models.CategoryManagment.Specifications;
    using HardwareStore.App.Services.Data.Category;

    public class CategoryInfoViewModel
    {
        public CategoryEditInputModel CategoryEditModel { get; set; }

        public SpecificationCreateInputModel SpecificationCreateForm { get; set; }

        public CategoryInfoDTO CategoryInfoModel { get; set; }
    }
}
