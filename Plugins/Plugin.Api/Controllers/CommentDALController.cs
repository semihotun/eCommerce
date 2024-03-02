 using System;
using System.Collections.Generic;
using System.Text;
using X.PagedList;
using Microsoft.AspNetCore.Mvc;
using DataAccess.DALs.EntitiyFramework.CommentsAggregate.Comments;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Core.Utilities.Identity;
using DataAccess.DALs.EntitiyFramework.CommentsAggregate.Comments.CommentDALModels; 
 namespace eCommerce.Areas.Api { 
 [AuthorizeControl] 
 [Route("api/[controller]")] 
 [ApiController] 
 public class CommentDALController : ControllerBase{ 
 private readonly ICommentDAL _commentDAL; 
 public CommentDALController(ICommentDAL commentDAL){ 
 _commentDAL=commentDAL; 
 } 
 [Produces("application/json", "text/plain")] 
 [HttpPost("getcommentdatatable")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> GetCommentDataTable ([FromBody]GetCommentDataTable request) { 
 var result = await _commentDAL.GetCommentDataTable(request); 
 if(result.Success) 
 return Ok(result.Data); 
 else 
 return BadRequest(result.Message); 
 } 
 } 
 }
