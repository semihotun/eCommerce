using Business.Services.CommentsAggregate.Comments;
using Core.Library;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.Products;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.Products.ProductDALModels;
using Entities.Concrete;
using Entities.ViewModels.WebViewModel.Home;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
namespace eCommerce.Controllers
{
    public class CommentController : BaseController
    {
        private readonly IProductDAL _productDAL;
        private readonly ICommentService _commentservice;
        private readonly UserManager<MyUser> _userManager;
        public CommentController(IProductDAL productDAL, ICommentService commentservice, UserManager<MyUser> userManager)
        {
            _productDAL = productDAL;
            _commentservice = commentservice;
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> AllCommentProduct(int id, int pageindex = 1, int pagesize = 10)
        {
            var model = new AllCommentVM
            {
                ProductCommentDTO = (await _productDAL.GetCommentListDTO(
                new GetCommentListDTO
                (id, pageindex, pagesize, null, true))).Data
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> CommentAdded(ProductDetailVM entitiy, string Rating = "")
        {
            var user = await _userManager.GetUserAsync(User);
            var model = entitiy.CommentModel;
            model.IsApproved = false;
            model.CreatedOnUtc = DateTime.Now;
            model.UserId = user.Id;
            if (Rating != null)
                model.Rating = int.Parse(Rating);
            ResponseAlert(await _commentservice.AddComment(model));
            return RedirectToAction("ProductDetail", "ProductDetail", new { productId = model.Productid, combinationId = entitiy.CombinationId });
        }
    }
}
