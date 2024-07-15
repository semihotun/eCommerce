using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.PagedList;
using Microsoft.AspNetCore.Mvc;
using Business.Services.CommentsAggregate.Comments.Commands;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Core.Utilities.Identity;
using Entities.RequestModel.CommentsAggregate.Comments;

namespace eCommerce.Areas.Api
{
    [AuthorizeControl]
    [Route("api/[controller]")]
    [ApiController]
    public class CommentCommandServiceController : ControllerBase
    {
        private readonly ICommentCommandService _commentCommandService;
        public CommentCommandServiceController(ICommentCommandService commentCommandService)
        {
            _commentCommandService = commentCommandService;
        }

        [Produces("application/json", "text/plain")]
        [HttpPost("addcomment")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Core.Utilities.Results.Result<Entities.Concrete.Comment>))]
        public async Task<IActionResult> AddComment([FromBody] AddCommentReqModel request)
        {
            var result = await _commentCommandService.AddComment(request);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }

        [Produces("application/json", "text/plain")]
        [HttpPost("deletecomment")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Core.Utilities.Results.Result))]
        public async Task<IActionResult> DeleteComment([FromBody] DeleteCommentReqModel request)
        {
            var result = await _commentCommandService.DeleteComment(request);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }

        [Produces("application/json", "text/plain")]
        [HttpPost("updatecomment")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Core.Utilities.Results.Result))]
        public async Task<IActionResult> UpdateComment([FromBody] UpdateCommentReqModel request)
        {
            var result = await _commentCommandService.UpdateComment(request);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }

        [Produces("application/json", "text/plain")]
        [HttpPost("commentapprove")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Core.Utilities.Results.Result))]
        public async Task<IActionResult> CommentApprove([FromBody] CommentApproveReqModel request)
        {
            var result = await _commentCommandService.CommentApprove(request);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }
    }
}
