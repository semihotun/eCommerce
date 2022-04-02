using Business.Services.CommentsAggregate.Comments;
using Core.Library;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.Products;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.Products.ProductDALModels;
using Entities.ViewModels.WebViewModel.Home;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace eCommerce.Controllers
{
    public class CommentController : Controller
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
            var model = new AllCommentVM();
            model.ProductCommentDTO = (await _productDAL.GetCommentListDTO(
                new GetCommentListDTO
                (id, pageindex, pagesize,null,true))).Data;

            return View(model);
        }
        [HttpPost]
        public IActionResult CommentAdded(ProductDetailVM entitiy, string Rating = "")
        {
            var user = _userManager.GetUserAsync(User);

            var model = entitiy.CommentModel;
            model.IsApproved = false;
            model.CreatedOnUtc = DateTime.Now;
            model.UserId = user.Result.Id;

            if (Rating != null)
                model.Rating = int.Parse(Rating);

            _commentservice.CommentAdd(model);
            return RedirectToAction("ProductDetail", "Home", new { productId = model.Productid, combinationId = entitiy.CombinationId });
        }
    }
}
