using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.PagedList;
using Microsoft.AspNetCore.Mvc;
using Business.Services.ProductAggregate.PredefinedProductAttributeValues.Commands;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Core.Utilities.Identity;
using Entities.RequestModel.ProductAggregate.PredefinedProductAttributeValues;

namespace eCommerce.Areas.Api
{
    [AuthorizeControl]
    [Route("api/[controller]")]
    [ApiController]
    public class PredefinedProductAttributeValueCommandServiceController : ControllerBase
    {
        private readonly IPredefinedProductAttributeValueCommandService _predefinedProductAttributeValueCommandService;
        public PredefinedProductAttributeValueCommandServiceController(IPredefinedProductAttributeValueCommandService predefinedProductAttributeValueCommandService)
        {
            _predefinedProductAttributeValueCommandService = predefinedProductAttributeValueCommandService;
        }

        [Produces("application/json", "text/plain")]
        [HttpPost("insertpredefinedproductattributevalue")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Core.Utilities.Results.Result<Entities.Concrete.PredefinedProductAttributeValue>))]
        public async Task<IActionResult> InsertPredefinedProductAttributeValue([FromBody] InsertPredefinedProductAttributeValueReqModel ppav)
        {
            var result = await _predefinedProductAttributeValueCommandService.InsertPredefinedProductAttributeValue(ppav);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }

        [Produces("application/json", "text/plain")]
        [HttpPost("updatepredefinedproductattributevalue")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Core.Utilities.Results.Result))]
        public async Task<IActionResult> UpdatePredefinedProductAttributeValue([FromBody] UpdatePredefinedProductAttributeValueReqModel ppav)
        {
            var result = await _predefinedProductAttributeValueCommandService.UpdatePredefinedProductAttributeValue(ppav);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }

        [Produces("application/json", "text/plain")]
        [HttpPost("deletepredefinedproductattributevalue")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Core.Utilities.Results.Result))]
        public async Task<IActionResult> DeletePredefinedProductAttributeValue([FromBody] DeletePredefinedProductAttributeValueReqModel ppav)
        {
            var result = await _predefinedProductAttributeValueCommandService.DeletePredefinedProductAttributeValue(ppav);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }
    }
}
