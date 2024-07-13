using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.PagedList;
using Microsoft.AspNetCore.Mvc;
using Business.Services.SliderAggregate.Sliders.Commands;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Core.Utilities.Identity;
using Entities.RequestModel.SliderAggregate.Sliders;

namespace eCommerce.Areas.Api
{
    [AuthorizeControl]
    [Route("api/[controller]")]
    [ApiController]
    public class SliderCommandServiceController : ControllerBase
    {
        private readonly ISliderCommandService _sliderCommandService;
        public SliderCommandServiceController(ISliderCommandService sliderCommandService)
        {
            _sliderCommandService = sliderCommandService;
        }

        [Produces("application/json", "text/plain")]
        [HttpPost("deleteslider")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> DeleteSlider([FromBody] DeleteSliderReqModel request)
        {
            var result = await _sliderCommandService.DeleteSlider(request);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }

        [Produces("application/json", "text/plain")]
        [HttpPost("insertslider")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> InsertSlider([FromBody] InsertSliderReqModel model)
        {
            var result = await _sliderCommandService.InsertSlider(model);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }

        [Produces("application/json", "text/plain")]
        [HttpPost("updateslider")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> UpdateSlider([FromBody] UpdateSliderReqModel request)
        {
            var result = await _sliderCommandService.UpdateSlider(request);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }
    }
}
