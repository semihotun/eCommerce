using Core.Utilities.Infrastructure.Filter;
namespace Entities.Dtos.CommentDALModels
{
    public class CommentDataTableFilter : IFilterable
    {
        [Filter(FilterOperators.Equals)]
        public bool IsApproved { get; set; }
    }
}
