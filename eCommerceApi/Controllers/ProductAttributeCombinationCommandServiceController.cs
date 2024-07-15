using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.PagedList;
using Microsoft.AspNetCore.Mvc;
using Business.Services.ProductAggregate.ProductAttributeCombinations.Commands;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Core.Utilities.Identity;
using Entities.RequestModel.ProductAggregate.ProductAttributeCombinations;

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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Core.Utilities.Results.Result<Entities.Concrete.ProductAttributeCombination>))]
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Core.Utilities.Results.Result))]
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Core.Utilities.Results.Result))]
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Core.Utilities.Results.Result))]
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Core.Utilities.Results.Result))]
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
