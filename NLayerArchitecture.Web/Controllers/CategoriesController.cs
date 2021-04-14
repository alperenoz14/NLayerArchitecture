using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayerArchitecture.API.DTO_s;
using NLayerArchitecture.API.Filters;
using NLayerArchitecture.Core.Entities;
using NLayerArchitecture.Web.APIService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayerArchitecture.Web.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly CategoryAPIService _categoryAPIService;
        private readonly IMapper _mapper;
        public CategoriesController(CategoryAPIService categoryAPIService, IMapper mapper)
        {
            _categoryAPIService = categoryAPIService;
            _mapper = mapper;

        }

        public async Task<IActionResult> List()
        {
            var categories = await _categoryAPIService.GetAllAsync();

            return View(_mapper.Map<IEnumerable<CategoryDto>>(categories));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDto categoryDto)
        {
            await _categoryAPIService.AddAsync(categoryDto);

            return RedirectToAction("List");
        }

        public async Task<IActionResult> Update(int id)
        {
            var category = await _categoryAPIService.GetByIdAsync(id);

            return View(_mapper.Map<CategoryDto>(category));
        }

        [HttpPost]
        public async Task<IActionResult> Update(CategoryDto categoryDto)
        {
            await _categoryAPIService.Update(categoryDto);

            return RedirectToAction("List");
        }

        //[ServiceFilter(typeof(NotFoundFilter))]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryAPIService.Remove(id);

            return RedirectToAction("List");
        }
    }
}
