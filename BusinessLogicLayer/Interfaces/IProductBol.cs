using GFStore.ApplicationLayer.Dto;
using GFStore.ApplicationLayer.Dto.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GFStore.BusinessLogicLayer.Interfaces
{
    public interface IProductBol
    {
       
        IEnumerable<ProductDto> GetAll();
        ProductDto GetById(int id);

        ProductDto Create(ProductDto product);

        
    }
}
