﻿namespace Business.Services.BrandAggregate.Brands.BrandServiceModel
{
    public class GetBrandDropdown
    {
        public int? SelectedId { get; set; }
        public GetBrandDropdown(int? selectedId = null)
        {
            SelectedId = selectedId;
        }
        public GetBrandDropdown()
        {
        }
    }
}
