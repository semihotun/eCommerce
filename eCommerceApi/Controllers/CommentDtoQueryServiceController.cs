using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.PagedList;
using Microsoft.AspNetCore.Mvc;
using Business.Services.CommentsAggregate.Comments.DtoQueries;
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
