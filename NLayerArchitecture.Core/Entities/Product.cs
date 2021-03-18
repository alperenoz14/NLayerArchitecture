using System;
using System.Collections.Generic;
using System.Text;

namespace NLayerArchitecture.Core.Entities
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public bool IsDeleted { get; set; }
        public string InnerBarcode { get; set; }
        public virtual Category Category { get; set; }      //virtual??

    }
}
