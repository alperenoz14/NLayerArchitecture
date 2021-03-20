using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NLayerArchitecture.API.DTO_s;
using NLayerArchitecture.Core.Entities;
using NLayerArchitecture.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayerArchitecture.API.Filters
{
    public class NotFoundFilter : ActionFilterAttribute
    {
        private readonly IService<Product> _productService;           //Iservice üzerinden nasıl yapardım??
        public NotFoundFilter(IService<Product> productService)
        {
            _productService = productService;
        }
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            int id = Convert.ToInt32(context.ActionArguments.Values.FirstOrDefault());

            var product = await _productService.GetByIdAsync(id);

            if (product != null)
            {
                await next();           //next ??
            }
            else
            {
                ErrorDto errorDto = new ErrorDto();

                errorDto.StatusCode = 404;

                errorDto.Errors.Add($"Product not found with id number {id}");
                context.Result = new NotFoundObjectResult(errorDto);
            }
        }
    }
}
