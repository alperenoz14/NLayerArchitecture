using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayerArchitecture.API.DTO_s;
using NLayerArchitecture.API.Filters;
using NLayerArchitecture.Core.Entities;
using NLayerArchitecture.Core.Services;
using NLayerArchitecture.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayerArchitecture.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductsController(IProductService productService,IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllAsync();

            return Ok(_mapper.Map<IEnumerable<ProductDto>>(products));
        }

        [ServiceFilter(typeof(NotFoundFilter))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id);

            return Ok(_mapper.Map<ProductDto>(product));
        }

        [ServiceFilter(typeof(NotFoundFilter))]
        [HttpGet("{id}/category")]
        public async Task<IActionResult> GetWithCategoryById(int id)
        {
            var product = await _productService.GetWithCategoryByIdAsync(id);
            return Ok(_mapper.Map<ProductWithCategoryDto>(product));
        }

        [ValidationFilter]
        [HttpPost]
        public async Task<IActionResult> Add(ProductDto productDto)
        {
            var addedProduct = await _productService.AddAsync(_mapper.Map<Product>(productDto));
            return Ok(_mapper.Map<ProductDto>(addedProduct));
        }

        [ValidationFilter]
        [HttpPut]
        public IActionResult Update(ProductDto productDto)
        {
            var updatedProduct = _productService.Update(_mapper.Map<Product>(productDto));

            return NoContent();
        }

        [ServiceFilter(typeof(NotFoundFilter))]
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var product = _productService.GetByIdAsync(id).Result; //async metotları sync yazmak için .result kullan... 
            _productService.Remove(product);
            return NoContent();
        }
    }
}
