using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstract.Spefications;
using Entities.ViewModels.Admin;
using Entities.Concrete;
using Entities.Others;
using Newtonsoft.Json;
using eCommerce.Models;

namespace eCommerce.Areas.Admin.Controllers
{
    [Route("[area]/[controller]/[action]")]
    [Kontrol("")]
    [Area("Admin")]
    public class SpeficationAttributeController : AdminBaseController
    {
        #region Method

        private readonly ISpecificationAttributeService _specificationAttributeService;
        private readonly IMapper _mapper;
        private readonly ISpecificationAttributeOptionService _specificationAttributeOptionService;


        #endregion

        #region Ctor

        public SpeficationAttributeController(
            ISpecificationAttributeService specificationAttributeService,
            IMapper mapper, 
            ISpecificationAttributeOptionService specificationAttributeOptionService)
        {
            _specificationAttributeService = specificationAttributeService;
            _mapper = mapper;
            _specificationAttributeOptionService = specificationAttributeOptionService;
        }


        #endregion

        #region Method

        #region SpeficationAttribute

        public async Task<IActionResult> SpeficationAttributeListJson(SpecificationAttributeModel model, DataTablesParam param)
        {
            var query = await _specificationAttributeService.GetSpecificationAttributes(
                pageIndex: param.PageIndex,
                pageSize: param.PageSize
                );

            return ToDataTableJson(query, param);
        }


        public async Task<IActionResult> SpeficationAttributeList()=> View(new SpecificationAttributeModel());

        [HttpPost]
        public async Task<IActionResult> SpeficationAttributeList(SpecificationAttributeModel model)=>View(model);

        public async Task<IActionResult> SpeficationAttributeCreate()=> View();


        [HttpPost]
        public async Task<IActionResult> SpeficationAttributeCreate(SpecificationAttributeModel model)
        {
            var data = _mapper.Map<SpecificationAttributeModel, SpecificationAttribute>(model);
            ResponseAlert(await _specificationAttributeService.InsertSpecificationAttribute(data));

            return RedirectToAction("SpeficationAttributeEdit", "SpeficationAttribute", new { Id = data.Id });
        }


        public async Task<IActionResult> SpeficationAttributeEdit(int id)
        {
            var query = await _specificationAttributeService.GetSpecificationAttributeById(id);
            var data = _mapper.Map<SpecificationAttribute, SpecificationAttributeModel>(query.Data);

            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> SpeficationAttributeEdit(SpecificationAttributeModel model)
        {
            var data = _mapper.Map<SpecificationAttributeModel, SpecificationAttribute>(model);
            ResponseAlert(await _specificationAttributeService.UpdateSpecificationAttribute(data));

            return RedirectToAction(nameof(SpeficationAttributeEdit),new{id= model.Id});
        }

        public async Task<IActionResult> SpeficationAttributeDelete(int id)
        {
            var spefication = await _specificationAttributeService.GetSpecificationAttributeById(id);
            ResponseAlert(await _specificationAttributeService.DeleteSpecificationAttribute(spefication.Data));

            return RedirectToAction("SpeficationAttributeList");
        }

        #endregion

        #region SpeficationAttributeOption



        public async Task<IActionResult> SpeficationAttributeOptionListJson(SpecificationAttributeOptionModel model, DataTablesParam param)
        {
            var query = await _specificationAttributeOptionService.GetSpecificationAttributeOptionsBySpecificationAttribute(
                pageIndex: param.PageIndex,
                pageSize: param.PageSize,
                specificationAttributeIdint: model.SpecificationAttributeId
                );

            return ToDataTableJson(query,param);
        }


        public async Task<IActionResult> SpeficationAttributeOptionCreate() => View();

        [HttpPost]
        public async Task<IActionResult> SpeficationAttributeOptionCreate(SpecificationAttributeModel model)
        {
            var data = _mapper.Map<SpecificationAttributeOptionModel, SpecificationAttributeOption>(model.SpecificationAttributeOptionModel);
            data.SpecificationAttributeId = model.Id;
            ResponseAlert(await _specificationAttributeOptionService.InsertSpecificationAttributeOption(data));

            return RedirectToAction("SpeficationAttributeEdit", "SpeficationAttribute", new { Id = model.Id });
        }

        [HttpGet]
        public async Task<IActionResult> SpeficationAttributeOptionEdit(int id) {

            var query = await _specificationAttributeOptionService.GetSpecificationAttributeOptionById(id);
            var data = _mapper.Map<SpecificationAttributeOption, SpecificationAttributeOptionModel>(query.Data);

            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> SpeficationAttributeOptionEdit(SpecificationAttributeOptionModel model)
        {
            var data = _mapper.Map<SpecificationAttributeOptionModel, SpecificationAttributeOption>(model);
            ResponseAlert(await _specificationAttributeOptionService.UpdateSpecificationAttributeOption(data));

            return RedirectToAction("SpeficationAttributeEdit", "SpeficationAttribute", new { Id = data.SpecificationAttributeId });
        }

        public async Task<IActionResult> SpeficationAttributeOptionDelete(int id)
        {
            var data = await _specificationAttributeOptionService.GetSpecificationAttributeOptionById(id);
            ResponseAlert(await _specificationAttributeOptionService.DeleteSpecificationAttributeOption(data.Data));

            return RedirectToAction("SpeficationAttributeEdit", "SpeficationAttribute", new { Id = data.Data.SpecificationAttributeId });
        }

        #endregion

        #endregion
    }
}
