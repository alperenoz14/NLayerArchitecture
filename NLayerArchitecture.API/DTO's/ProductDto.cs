using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NLayerArchitecture.API.DTO_s
{
    public class ProductDto
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "{0} attribute is required!")]
        public string Name { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "{0} attribute required and needs to be greater than 1!")]
        public int Stock { get; set; }

        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "{0} attribute required and needs to be greater than 1!")]
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
