using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GFStore.ApplicationLayer.Dto
{
    public class ProductDto
    {
        
        public string Name { get; set; }
        public double Price { get; set; }
        public int Likes { get; set; }
        public string Category { get; set; }
        public int Stock { get; set; }

    }
}
