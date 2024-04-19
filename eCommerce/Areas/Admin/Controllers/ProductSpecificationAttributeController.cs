using Business.Services.ProductAggregate.ProductSpecificationAttributes.DtoQueries;
using Entities.RequestModel.ProductAggregate.ProductSpecificationAttributes;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
namespace eCommerce.Areas.Admin.Controllers
{
    public class ProductSpecificationAttributeController : AdminBaseController
    {
        private readonly IProductSpecificationAttributeDtoQueryService _productSpecificationAttributeDtoQueryService;
        public ProductSpecificationAttributeController(
            IProductSpecificationAttributeDtoQueryService productSpecificationAttributeDtoQueryService
            )
        {
            _productSpecificationAttributeDtoQueryService = productSpecificationAttributeDtoQueryService;
        }
        public async Task<IActionResult> ProductSpeficationJson(GetProductSpecAttrListReqModel request) =>
             ToDataTableJson(await _productSpecificationAttributeDtoQueryService.GetProductSpecAttrList(request), request);
    }
}
