using Business.Constants;
using Business.Services.CommentsAggregate.Comments.Commands;
using Business.Services.CommentsAggregate.Comments.DtoQueries;
using Business.Services.CommentsAggregate.Comments.Queries;
using Entities.Concrete;
using Entities.RequestModel.CommentsAggregate.Comments;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
namespace eCommerce.Areas.Admin.Controllers
{
    public class CommentController : AdminBaseController
    {
        #region ctor
        private readonly ICommentCommandService _commentCommandService;
        private readonly ICommentQueryService _commentQueryService;
        private readonly ICommentDtoQueryService _commentDtoQueryService;
        public CommentController(
            ICommentCommandService commentCommandService,
            ICommentQueryService commentQueryService,
            ICommentDtoQueryService commentDtoQueryService)
        {
            _commentCommandService = commentCommandService;
            _commentQueryService = commentQueryService;
            _commentDtoQueryService = commentDtoQueryService;
        }
        #endregion
        public async Task<IActionResult> CommentListJson(GetCommentDataTableReqModel model)
        {
            return ToDataTableJson(await _commentDtoQueryService.GetCommentDataTable(model), model);
        }
        [HttpGet]
        public IActionResult CommentList()
        {
            ViewBag.Approve = ConstList.FillCommentApprove();
            return View();
        }
        [HttpPost]
        public IActionResult CommentList(Comment model)
        {
            ViewBag.Approve = ConstList.FillCommentApprove(model.IsApproved);
            return View(model);
        }
        public async Task<IActionResult> CommentEdit(Guid id)
        {
            var data = (await _commentQueryService.GetComment(new(id))).Data;
            return View(data);
        }
        public async Task<IActionResult> CommentDelete(Guid id)
        {
            ResponseAlert(await _commentCommandService.DeleteComment(new(id)));
            return RedirectToAction("CommentList", "Comment");
        }
        public async Task<IActionResult> CommentApprove(Guid id)
        {
            ResponseAlert(await _commentCommandService.CommentApprove(new(id)));
            return RedirectToAction("CommentList", "Comment");
        }
    }
}