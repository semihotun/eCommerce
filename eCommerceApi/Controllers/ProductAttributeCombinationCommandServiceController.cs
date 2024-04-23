using Business.Services.ProductAggregate.ProductAttributeCombinations.Commands;
using Core.Utilities.Identity;
using Entities.RequestModel.ProductAggregate.ProductAttributeCombinations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace eCommerce.Areas.Api
{
    [AuthorizeControl]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductAttributeCombinationCommandServiceController : ControllerBase
    {
        private readonly IProductAttributeCombinationCommandService _productAttributeCombinationCommandService;
        public ProductAttributeCombinationCommandServiceController(IProductAttributeCombinationCommandService productAttributeCombinationCommandService)
        {
            _productAttributeCombinationCommandService = productAttributeCombinationCommandService;
        }

        [Produces("application/json", "text/plain")]
        [HttpPost("insertproductattributecombination")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> InsertProductAttributeCombination([FromBody] InsertProductAttributeCombinationReqModel combination)
        {
            var result = await _productAttributeCombinationCommandService.InsertProductAttributeCombination(combination);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }

        [Produces("application/json", "text/plain")]
        [HttpPost("updateproductattributecombination")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> UpdateProductAttributeCombination([FromBody] UpdateProductAttributeCombinationReqModel combination)
        {
            var result = await _productAttributeCombinationCommandService.UpdateProductAttributeCombination(combination);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }

        [Produces("application/json", "text/plain")]
        [HttpPost("insertpermutationcombination")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> InsertPermutationCombination([FromBody] InsertPermutationCombinationReqModel request)
        {
            var result = await _productAttributeCombinationCommandService.InsertPermutationCombination(request);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }

        [Produces("application/json", "text/plain")]
        [HttpPost("allinsertpermutationcombination")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> AllInsertPermutationCombination([FromBody] AllInsertPermutationCombinationReqModel request)
        {
            var result = await _productAttributeCombinationCommandService.AllInsertPermutationCombination(request);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }

        [Produces("application/json", "text/plain")]
        [HttpPost("deleteproductattributecombination")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> DeleteProductAttributeCombination([FromBody] DeleteProductAttributeCombinationReqModel request)
        {
            var result = await _productAttributeCombinationCommandService.DeleteProductAttributeCombination(request);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }
    }
}
