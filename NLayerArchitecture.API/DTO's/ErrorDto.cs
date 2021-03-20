using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayerArchitecture.API.DTO_s
{
    public class ErrorDto
    {
        public ErrorDto()
        {
            Errors = new List<string>();
        }
        public List<string> Errors { get; set; }
        public int StatusCode { get; set; }
    }
}
