using GFShop.ApplicationLayer.Dto.Base;
using GFShop.ApplicationLayer.Dto.Request.Products;
using GFShop.ApplicationLayer.Dto.Response.Products;
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
       
        IEnumerable<FullProductResponse> GetAll(ProductParamsDto productParams);
        ProductDto GetById(int id);

        ProductDto Create(ProductDto product);
        void Delete(int id);

        void UpdatePrice(double price, int id);
        void AddLike(int id);
        void InventoryMove(InventoryMoveRequest inventoryMove, int ProductId);
        void BuyProduct(BuyProductRequest inventoryMove, int ProductId);
    }
}
