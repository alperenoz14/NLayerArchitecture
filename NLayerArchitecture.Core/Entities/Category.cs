using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace NLayerArchitecture.Core.Entities
{
    public class Category
    {
        public Category()
        {
            Products = new Collection<Product>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
