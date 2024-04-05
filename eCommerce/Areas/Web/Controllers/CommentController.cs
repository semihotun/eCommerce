using Business.Services.CommentsAggregate.Comments;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.Products;
using Entities.Concrete;
using Entities.Extensions.AutoMapper;
using Entities.RequestModel.CommentsAggregate.Comments;
using Entities.ViewModels.WebViewModel.Home;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
namespace eCommerce.Areas.Web.Controllers
{
    public class CommentController : WebBaseController
    {
        private readonly IProductDAL _productDAL;
        private readonly ICommentService _commentservice;
        public CommentController(IProductDAL productDAL, ICommentService commentservice)
        {
            _productDAL = productDAL;
            _commentservice = commentservice;
        }
        [HttpGet]
        public async Task<IActionResult> AllCommentProduct(int id, int pageindex = 1, int pagesize = 10)
        {
            var model = new AllCommentVM
            {
                ProductCommentDTO = (await _productDAL.GetCommentListDTO(
                new(id, pageindex, pagesize, null, true))).Data
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> CommentAdded(ProductDetailVM entitiy, string Rating = "")
        {
            //var user = await _userManager.GetUserAsync(User);
            var model = entitiy.CommentModel;
            model.IsApproved = false;
            model.CreatedOnUtc = DateTime.Now;
            //model.UserId = user.Id;
            if (Rating != null)
                model.Rating = int.Parse(Rating);

            var data = model.MapTo<AddCommentReqModel>();
            ResponseAlert(await _commentservice.AddComment(data));
            return RedirectToAction("ProductDetail", "ProductDetail", new { productId = model.Productid, combinationId = entitiy.CombinationId });
        }
    }
}
