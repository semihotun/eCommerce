using System;
using System.Collections.Generic;
using System.Text;
namespace Business.Services.CategoriesAggregate.Categories.CategoryServiceModel
{
    public class ChangeNodePosition
    {
        public ChangeNodePosition(int ıd, int? parentId)
        {
            Id = ıd;
            ParentId = parentId;
        }
        public ChangeNodePosition()
        {
        }
        public int Id { get; set; }
        public int? ParentId { get; set; }
    }
}
