using AutoMapper;
using Business.Services.CommentsAggregate.Comments;
using Business.Services.CommentsAggregate.Comments.CommentServiceModel;
using Core.Utilities.Identity;
using DataAccess.DALs.EntitiyFramework.CommentsAggregate.Comments;
using DataAccess.DALs.EntitiyFramework.CommentsAggregate.Comments.CommentDALModels;
using eCommerce.Helpers;
using Entities.Concrete.CommentsAggregate;
using Entities.DTO.Comment;
using Entities.Others;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
namespace eCommerce.Areas.Admin.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("[area]/[controller]/[action]")]
    [AuthorizeControl("")]
    [Area("Admin")]
    public class CommentController : AdminBaseController
    {
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;
        private readonly ICommentDAL _commentDal;
        public CommentController(ICommentService commentService,
            IMapper mapper,
            ICommentDAL commentDal)
        {
            this._commentService = commentService;
            this._mapper = mapper;
            this._commentDal = commentDal;
        }
        public async Task<IActionResult> CommentListJson(CommentDataTableFilter model, DataTablesParam param)
        {
            return ToDataTableJson(await _commentDal.GetCommentDataTable(new GetCommentDataTable(model, param)), param);
        }
        [HttpGet]
        public IActionResult CommentList()
        {
            ViewBag.Approve = SelectListHelper.FillCommentApprove();
            return View();
        }
        [HttpPost]
        public IActionResult CommentList(Comment model)
        {
            ViewBag.Approve = SelectListHelper.FillCommentApprove(model.IsApproved);
            return View(model);
        }
        public async Task<IActionResult> CommentEdit(int id)
        {
            return View((await _commentService.GetComment(new GetComment(id))).Data);
        }
        public async Task<IActionResult> CommentDelete(int id)
        {
            ResponseAlert(await _commentService.DeleteComment((await _commentService.GetComment(new GetComment(id))).Data));
            return RedirectToAction("CommentList", "Comment");
        }
        public async Task<IActionResult> CommentApprove(int id)
        {
            var data = await _commentService.GetComment(new GetComment(id));
            data.Data.IsApproved = true;
            ResponseAlert(await _commentService.UpdateComment(data.Data));
            return RedirectToAction("CommentList", "Comment");
        }
    }
}