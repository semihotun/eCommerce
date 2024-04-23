using Business.Services.CommentsAggregate.Comments.Queries;
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
    public class CommentQueryServiceController : ControllerBase
    {
        private readonly ICommentQueryService _commentQueryService;
        public CommentQueryServiceController(ICommentQueryService commentQueryService)
        {
            _commentQueryService = commentQueryService;
        }

        [Produces("application/json", "text/plain")]
        [HttpGet("getcommentlist")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetCommentList([FromQuery] GetCommentListReqModel request)
        {
            var result = await _commentQueryService.GetCommentList(request);
            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message);
        }

        [Produces("application/json", "text/plain")]
        [HttpGet("getcomment")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetComment([FromQuery] GetCommentReqModel request)
        {
            var result = await _commentQueryService.GetComment(request);
            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message);
        }

        [Produces("application/json", "text/plain")]
        [HttpGet("getcommentcount")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetCommentCount()
        {
            var result = await _commentQueryService.GetCommentCount();
            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message);
        }
    }
}
