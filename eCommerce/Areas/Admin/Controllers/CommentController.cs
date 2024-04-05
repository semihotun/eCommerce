using AutoMapper;
using Business.Constants;
using Business.Services.CommentsAggregate.Comments;
using Core.Utilities.Identity;
using DataAccess.DALs.EntitiyFramework.CommentsAggregate.Comments;
using Entities.Concrete.CommentsAggregate;
using Entities.Dtos.CommentDALModels;
using Entities.Others;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
namespace eCommerce.Areas.Admin.Controllers
{
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
            ViewBag.Approve = ConstList.FillCommentApprove();
            return View();
        }
        [HttpPost]
        public IActionResult CommentList(Comment model)
        {
            ViewBag.Approve = ConstList.FillCommentApprove(model.IsApproved);
            return View(model);
        }
        public async Task<IActionResult> CommentEdit(int id)
        {
            var data = (await _commentService.GetComment(new(id))).Data;
            return View(data);
        }
        public async Task<IActionResult> CommentDelete(int id)
        {
            ResponseAlert(await _commentService.DeleteComment(new(id)));
            return RedirectToAction("CommentList", "Comment");
        }
        public async Task<IActionResult> CommentApprove(int id)
        {    
            ResponseAlert(await _commentService.CommentApprove(new(id)));
            return RedirectToAction("CommentList", "Comment");
        }
    }
}