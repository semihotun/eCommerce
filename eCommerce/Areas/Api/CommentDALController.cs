 using System;
using System.Collections.Generic;
using System.Text;
using X.PagedList;
using Microsoft.AspNetCore.Mvc;
using DataAccess.DALs.EntitiyFramework.CommentsAggregate.Comments;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using DataAccess.DALs.EntitiyFramework.CommentsAggregate.Comments.CommentDALModels; 
 namespace eCommerce.Areas.Api { 
 
 [Route("api/[controller]")] 
 [ApiController] 
 public class CommentDALController : ControllerBase{ 
 private readonly ICommentDAL _commentDAL; 
 
 public CommentDALController(ICommentDAL commentDAL){ 
 _commentDAL=commentDAL; 
 } 
 
 [Produces("application/json", "text/plain")] 
 [HttpPost("getcommentdatatable")] 
 [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> GetCommentDataTable ([FromBody]GetCommentDataTable request) { 
 
 var result = await _commentDAL.GetCommentDataTable(request); 
 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 
 } 
 
 } 
 }
