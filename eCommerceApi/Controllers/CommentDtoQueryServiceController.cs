using Business.Services.CommentsAggregate.Comments.DtoQueries;
using Core.Utilities.Identity;
using Entities.RequestModel.CommentsAggregate.Comments;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace eCommerce.Areas.Api
{
    [AuthorizeControl]
    [Route("api/[controller]")]
    [ApiController]
    public class CommentDtoQueryServiceController : ControllerBase
    {
        private readonly ICommentDtoQueryService _commentDtoQueryService;
        public CommentDtoQueryServiceController(ICommentDtoQueryService commentDtoQueryService)
        {
            _commentDtoQueryService = commentDtoQueryService;
        }

        [Produces("application/json", "text/plain")]
        [HttpPost("getcommentdatatable")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetCommentDataTable([FromBody] GetCommentDataTableReqModel request)
        {
            var result = await _commentDtoQueryService.GetCommentDataTable(request);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }
    }
}
