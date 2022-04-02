 using System;
using System.Collections.Generic;
using System.Text;
using X.PagedList;
using Microsoft.AspNetCore.Mvc;
using Business.Services.SliderAggregate.Sliders;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Business.Services.SliderAggregate.Sliders.SliderServiceModel;
using Entities.Concrete.SliderAggregate; 
 namespace eCommerce.Areas.Api { 
 
 [Route("api/[controller]")] 
 [ApiController] 
 public class SliderServiceController : ControllerBase{ 
 private readonly ISliderService _sliderService; 
 
 public SliderServiceController(ISliderService sliderService){ 
 _sliderService=sliderService; 
 } 
 
 [Produces("application/json", "text/plain")] 
 [HttpPost("deleteslider")] 
 [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> DeleteSlider ([FromBody]DeleteSlider request) { 
 
 var result = await _sliderService.DeleteSlider(request); 
 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 
 } 
 
 [Produces("application/json", "text/plain")] 
 [HttpGet("getallslider")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> GetAllSlider () { 
 
 var result = await _sliderService.GetAllSlider(); 
 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 } 
 
 [Produces("application/json", "text/plain")] 
 [HttpGet("getslider")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> GetSlider (GetSlider request) { 
 
 var result = await _sliderService.GetSlider(request); 
 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 } 
 
 [Produces("application/json", "text/plain")] 
 [HttpPost("insertslider")] 
 [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> InsertSlider ([FromBody]Slider slider) { 
 
 var result = await _sliderService.InsertSlider(slider); 
 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 
 } 
 
 [Produces("application/json", "text/plain")] 
 [HttpPost("updateslider")] 
 [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> UpdateSlider ([FromBody]Slider slider) { 
 
 var result = await _sliderService.UpdateSlider(slider); 
 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 
 } 
 
 } 
 }
