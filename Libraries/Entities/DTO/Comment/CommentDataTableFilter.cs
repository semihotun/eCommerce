using Core.Utilities.Infrastructure.Filter;
namespace Entities.DTO.Comment
{
    public class CommentDataTableFilter:IFilterable
    {
        [Filter(FilterOperators.Equals)]
        public bool IsApproved { get; set; }
    }
}
