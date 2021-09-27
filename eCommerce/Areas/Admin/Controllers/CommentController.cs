using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstract;
using Business.Abstract.Comments;
using DataAccess.Abstract;
using Entities.ViewModels.Admin;
using eCommerce.Helpers;
using Entities.Concrete;
using Entities.DTO.Comment;
using Entities.Others;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using eCommerce.Models;

namespace eCommerce.Areas.Admin.Controllers
{
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
            var query = await _commentDal.GetCommentDataTable(model, param);

            query.Data.Select(x => {
                var pacModel = new Comment
                {
                    Id = x.Id,
                    CommentText = (x.CommentText.Length > 200) ? x.CommentText.Substring(0, 200) + "..." : x.CommentText,
                    CommentTitle = (x.CommentTitle.Length > 200) ? x.CommentTitle.Substring(0, 200) + "..." : x.CommentTitle,
                };
                return pacModel;
             });

            return ToDataTableJson(query,param);
        }
        [HttpGet]
        public IActionResult CommentList()
        {
            ViewBag.Approve = SelectListHelper.fillCommentApprove();
            return View();
        }
        [HttpPost]
        public IActionResult CommentList(CommentModel model)
        {
            ViewBag.Approve = SelectListHelper.fillCommentApprove(model.IsApproved);
            return View(model);
        }

        public async Task<IActionResult> CommentEdit(int id)
        {
            var data = await _commentService.GetComment(id);
            var result = _mapper.Map<Comment, CommentModel>(data.Data);

            return View(result);
        }

        public async Task<IActionResult> CommentDelete(int id)
        {
            var deleteData = await _commentService.GetComment(id);
            ResponseAlert(await _commentService.DeleteComment(deleteData.Data));

            return RedirectToAction("CommentList", "Comment");
        }

        public async Task<IActionResult> CommentApprove(int id)
        {
            var data = await _commentService.GetComment(id);
            data.Data.IsApproved = true;
            ResponseAlert(await _commentService.UpdateComment(data.Data));

            return RedirectToAction("CommentList", "Comment");
        }
    }
}