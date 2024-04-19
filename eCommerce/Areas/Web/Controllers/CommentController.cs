using Business.Services.CommentsAggregate.Comments.Commands;
using Business.Services.ProductAggregate.Products.DtoQueries;
using Entities.Extensions.AutoMapper;
using Entities.RequestModel.CommentsAggregate.Comments;
using Entities.ViewModels.WebViewModel.Home;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
namespace eCommerce.Areas.Web.Controllers
{
    public class CommentController : WebBaseController
    {
        private readonly IProductDtoQuery _productDtoQuery;
        private readonly ICommentCommandService _commentCommandService;
        public CommentController(IProductDtoQuery productDtoQuery)
        {
            _productDtoQuery = productDtoQuery;
        }
        [HttpGet]
        public async Task<IActionResult> AllCommentProduct(Guid id, int pageindex = 1, int pagesize = 10)
        {
            var model = new AllCommentVM
            {
                ProductCommentDTO = (await _productDtoQuery.GetCommentListDTO(
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
            ResponseAlert(await _commentCommandService.AddComment(data));
            return RedirectToAction("ProductDetail", "ProductDetail", new { productId = model.Productid, combinationId = entitiy.CombinationId });
        }
    }
}
