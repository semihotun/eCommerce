using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.PhotoAggregate.ProductPhotos.ProductPhotoServiceModel
{
    public class GetProductPhoto
    {
        public int Id { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string OrderByText { get; set; }


        public GetProductPhoto(int id = 0, int pageIndex = 1, int pageSize = int.MaxValue, string orderByText = null)
        {
            Id = id;
            PageIndex = pageIndex;
            PageSize = pageSize;
            OrderByText = orderByText;
        }

        public GetProductPhoto()
        {
        }
    }
}
