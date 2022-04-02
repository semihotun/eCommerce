using AutoMapper;
using Business.Services.CommentsAggregate.Comments;
using Business.Services.CommentsAggregate.Comments.CommentServiceModel;
using DataAccess.DALs.EntitiyFramework.CommentsAggregate.Comments;
using DataAccess.DALs.EntitiyFramework.CommentsAggregate.Comments.CommentDALModels;
using eCommerce.Helpers;
using eCommerce.Models;
using Entities.Concrete.CommentsAggregate;
using Entities.DTO.Comment;
using Entities.Others;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace eCommerce.Areas.Admin.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("[area]/[controller]/[action]")]
    [Kontrol("")]
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
            var query = await _commentDal.GetCommentDataTable(new GetCommentDataTable(model, param));

            return ToDataTableJson(query,param);
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
            var data = await _commentService.GetComment(new GetComment(id));
            return View(data.Data);
        }

        public async Task<IActionResult> CommentDelete(int id)
        {
            var deleteData = await _commentService.GetComment(new GetComment(id));
            ResponseAlert(await _commentService.DeleteComment(deleteData.Data));

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