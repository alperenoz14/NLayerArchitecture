using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NLayerArchitecture.API.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayerArchitecture.API.Filters
{
    public class ValidationFilter:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                ErrorDto errorDto = new ErrorDto();

                errorDto.StatusCode = 400;

                IEnumerable<ModelError> modelErrors = context.ModelState.Values.SelectMany(x => x.Errors);

                foreach (var error in modelErrors.ToList())
                {
                    errorDto.Errors.Add(error.ErrorMessage);
                }

                context.Result = new BadRequestObjectResult(errorDto);
            }
        }
    }
}
